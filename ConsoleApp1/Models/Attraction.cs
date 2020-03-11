using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Attraction
    {
        public int Capacity { get; set; }

        /// <summary>
        /// Ride time in seconds
        /// </summary>
        public int RideTime { get; set; }

        public Queue<Visitor> VisitorsQueue { get; set; }

        /// <summary>
        /// Estimated wait time in seconds
        /// </summary>
        public int EstimatedWaitTime { get; }

        public int PopularityRank { get; set; }

        public AttractionCategory AttractionCategory { get; set; }
    }
}
