using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        public IList<Visitor> VisitorsQueue { get; set; }

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
            this.VisitorsQueue = new List<Visitor>();
        }

        public bool CanTakeVisitors(int elapsedMinutes)
        {
            return elapsedMinutes % this.RideTime == 0;
        }

        public void DrainQueue(int currentTime)
        {
            // first n visitors in line get to enjoy it
            // if can take more visitors
            if (this.CanTakeVisitors(currentTime))
            {
                for (int i = 0; i < this.Capacity; i++)
                {
                    if (this.VisitorsQueue.Count == 0)
                    {
                        break;
                    }

                    var visitor = this.VisitorsQueue.ElementAt(0);
                    visitor.EnjoyAttraction(this);

                    this.VisitorsQueue.Remove(visitor);
                }
            }
        }
    }
}
