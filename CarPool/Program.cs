using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPool
{
    class Trip
    {
        public int PassengerCount { get; set; }
        public int Start { get; set; }
        public int End { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var inputTrips = new int[][] { new int[] { 3, 2, 7 }, new int[] { 3, 7, 9 }, new int[] { 8, 3, 9 } };
            var capacity = 11;
            Console.Write(CarPooling(inputTrips, capacity));
            Console.Read();
        }

        public static bool CarPooling(int[][] trips, int capacity)
        {
            var timeStamp = new int[1001];
            foreach (var trip in trips)
            {
                timeStamp[trip[1]] += trip[0];
                timeStamp[trip[2]] -= trip[0];
            }

            foreach (var number in timeStamp)
            {
                capacity -= number;
                if (capacity < 0) return false;
            }

            return true;
        }

        public static bool CarPoolingOld(int[][] trips, int capacity)
        {
            if (trips.Count() == 1) return true;
            //Setup trips collection.
            var tripsCollection = new List<Trip>();
            foreach (var trip in trips)
                tripsCollection.Add(new Trip { PassengerCount = trip[0], Start = trip[1], End = trip[2] });

            var orderedTripsCollection = tripsCollection.OrderBy(p => p.Start).ToList();
            var startIndex = 0;
            for (int i = 0; i < orderedTripsCollection.Count; i++)
            {
                var exclusiveTrips = orderedTripsCollection.Where(p => p != orderedTripsCollection[startIndex]);

                if (exclusiveTrips.Any(p => (p.Start >= orderedTripsCollection[startIndex].Start && p.Start < orderedTripsCollection[startIndex].End) || (p.End >= orderedTripsCollection[startIndex].Start && p.End <= orderedTripsCollection[startIndex].End)))
                {
                    var intersectingTrips = exclusiveTrips.Where(p => (p.Start >= orderedTripsCollection[startIndex].Start && p.Start < orderedTripsCollection[startIndex].End) || (p.End >= orderedTripsCollection[startIndex].Start && p.End <= orderedTripsCollection[startIndex].End));
                    if (!intersectingTrips.All(p => p.Start >= orderedTripsCollection[startIndex].Start)) return false;
                    if (orderedTripsCollection[startIndex].PassengerCount + intersectingTrips.Sum(p => p.PassengerCount) > capacity) return false;
                }
                orderedTripsCollection.RemoveAt(startIndex);
            }
            return true;

            //foreach (var trip in tripsCollection)
            //{                
            //    var exclusiveTrips = tripsCollection.Where(p => p != trip);
            //    if (exclusiveTrips.Any(p => (p.Start >= trip.Start && p.Start < trip.End) || (p.End >= trip.Start && p.End <= trip.End)))
            //    {
            //        var intersectingTrips = exclusiveTrips.Where(p => (p.Start >= trip.Start && p.Start < trip.End) || (p.End >= trip.Start && p.End <= trip.End));
            //        if (trip.PassengerCount + intersectingTrips.Sum(p => p.PassengerCount) > capacity)
            //            return false;
            //    }
            //}
        }
    }
}
