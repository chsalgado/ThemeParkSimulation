using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Attraction
    {
        int Capacity { get; set; }

        /// <summary>
        /// Ride time in seconds
        /// </summary>
        int RideTime { get; set; }

        Queue<Visitor> VisitorsQueue { get; set; }

        /// <summary>
        /// Estimated wait time in seconds
        /// </summary>
        int EstimatedWaitTime { get; }

        int PopularityRank { get; set; }

        AttractionCategory AttractionCategory { get; set; }
    }
}
