using ConsumerVehicleRegistration;
using CommercialRegistration;
using LiveryRegistration;
using System;

namespace CSharpNewFeatures
{
    public static class Patterns
    {
        public static void Demo()
        {
            var soloDriver = new Car();
            var twoRideShare = new Car { Passengers = 1 };
            var threeRideShare = new Car { Passengers = 2 };
            var fullVan = new Car { Passengers = 5 };

            var emptyTaxi = new Taxi();
            var singleFare = new Taxi { Fares = 1 };
            var doubleFare = new Taxi { Fares = 2 };
            var fullVanPool = new Taxi { Fares = 5 };

            var lowOccupantBus = new Bus { Capacity = 90, Riders = 15 };
            var normalBus = new Bus { Capacity = 90, Riders = 75 };
            var fullBus = new Bus { Capacity = 90, Riders = 85 };

            var heavyTruck = new DeliveryTruck { GrossWeightClass = 7500 };
            var truck = new DeliveryTruck { GrossWeightClass = 4000 };
            var lightTruck = new DeliveryTruck { GrossWeightClass = 2500 };

            Console.WriteLine($"The toll for a solo driver is {CalculateToll(soloDriver)}");
            Console.WriteLine($"The toll for a two ride share is {CalculateToll(twoRideShare)}");
            Console.WriteLine($"The toll for a three ride share is {CalculateToll(threeRideShare)}");
            Console.WriteLine($"The toll for a fullVan is {CalculateToll(fullVan)}");

            Console.WriteLine($"The toll for an empty taxi is {CalculateToll(emptyTaxi)}");
            Console.WriteLine($"The toll for a single fare taxi is {CalculateToll(singleFare)}");
            Console.WriteLine($"The toll for a double fare taxi is {CalculateToll(doubleFare)}");
            Console.WriteLine($"The toll for a full van taxi is {CalculateToll(fullVanPool)}");

            Console.WriteLine($"The toll for a low-occupant bus is {CalculateToll(lowOccupantBus)}");
            Console.WriteLine($"The toll for a regular bus is {CalculateToll(normalBus)}");
            Console.WriteLine($"The toll for a bus is {CalculateToll(fullBus)}");

            Console.WriteLine($"The toll for a truck is {CalculateToll(heavyTruck)}");
            Console.WriteLine($"The toll for a truck is {CalculateToll(truck)}");
            Console.WriteLine($"The toll for a truck is {CalculateToll(lightTruck)}");

            try
            {
                CalculateToll("this will fail");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Caught an ArgumentException when using the wrong type.");
            }

            try
            {
                CalculateToll(null);
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Caught an ArgumentNullException when using null.");
            }
        }

        static decimal CalculateToll(object? vehicle) =>

            vehicle switch
            {
                Car { Passengers: 3 } => 1.00m,
                Car { Passengers: 2 } => 1.50m,
                Car _ => 2.00m,
                Taxi _ => 3.50m,
                Bus _ => 5.00m,
                DeliveryTruck _ => 10.00m,
                { } => throw new ArgumentException(message: "Not a known vehicle type", paramName: null),
                null => throw new ArgumentNullException(nameof(vehicle)),
            };

        #region Advanced

        static bool IsWeekDay(DateTime timeOfToll) =>

            timeOfToll.DayOfWeek switch
            {
                DayOfWeek.Saturday => false,
                DayOfWeek.Sunday => false,
                _ => true,
            };

        enum TimeBand
        {
            MorningRush,
            Daytime,
            EveningRush,
            Overnight
        }

        static TimeBand GetTimeBand(DateTime timeOfToll)
        {
            var hour = timeOfToll.Hour;
            if (hour < 6) return TimeBand.Overnight;
            else if (hour < 10) return TimeBand.MorningRush;
            else if (hour < 16) return TimeBand.Daytime;
            else if (hour < 20) return TimeBand.EveningRush;
            else return TimeBand.Overnight;
        }

        static decimal PeakTimePremium(DateTime timeOfToll, bool inbound) =>

            (IsWeekDay(timeOfToll), GetTimeBand(timeOfToll), inbound) switch
            {
                (true, TimeBand.Overnight, _) => 0.75m,
                (true, TimeBand.Daytime, _) => 1.5m,
                (true, TimeBand.MorningRush, true) => 2.0m,
                (true, TimeBand.EveningRush, false) => 2.0m,
                (_, _, _) => 1.0m,
            };

        #endregion
    }
}

/// <summary>
/// 非营运车辆
/// </summary>
namespace ConsumerVehicleRegistration
{
    /// <summary>
    /// 家用轿车
    /// </summary>
    public class Car
    {
        /// <summary>
        /// 乘客人数
        /// </summary>
        public int Passengers { get; set; }
    }
}

/// <summary>
/// 商业车辆
/// </summary>
namespace CommercialRegistration
{
    /// <summary>
    /// 运货卡车
    /// </summary>
    public class DeliveryTruck
    {
        /// <summary>
        /// 车辆毛重
        /// </summary>
        public int GrossWeightClass { get; set; }
    }
}

/// <summary>
/// 载客车辆
/// </summary>
namespace LiveryRegistration
{
    /// <summary>
    /// 出租车
    /// </summary>
    public class Taxi
    {
        /// <summary>
        /// 乘客数量
        /// </summary>
        public int Fares { get; set; }
    }

    /// <summary>
    /// 公交车
    /// </summary>
    public class Bus
    {
        /// <summary>
        /// 核定载客人数
        /// </summary>
        public int Capacity { get; set; }

        /// <summary>
        /// 实际载客人数
        /// </summary>
        public int Riders { get; set; }
    }
}