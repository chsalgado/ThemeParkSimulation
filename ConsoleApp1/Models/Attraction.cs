using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Attraction
    {
        public int Capacity { get; set; }

        /// <summary>
        /// Ride time in minutes
        /// </summary>
        public int RideTime { get; set; }

        public Queue<Visitor> VisitorsQueue { get; set; }

        /// <summary>
        /// Estimated wait time in minutes
        /// </summary>
        public int EstimatedWaitTime 
        {
            get
            {
                return (int)Math.Ceiling((double)VisitorsQueue.Count / (double)Capacity) * RideTime;
            } 
        }

        public int PopularityRank { get; set; }

        public AttractionCategory AttractionCategory { get; set; }

        public Point Location { get; set; }

        public void Init()
        {
            this.VisitorsQueue = new Queue<Visitor>();
        }

        public bool CanTakeVisitors(int elapsedMinutes)
        {
            return elapsedMinutes % this.RideTime == 0;
        }
    }
}
