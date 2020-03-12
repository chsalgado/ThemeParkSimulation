using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConsoleApp1.Models
{
    public class ThemePark
    {
        /// <summary>
        /// A theme park has attractions uniformly distributed in a grid
        /// </summary>
        public IEnumerable<Attraction> Attractions { get; set; }

        public int OperationHours { get; set; }

        /// <summary>
        /// How many? Research six flags?
        /// </summary>
        public int NumberOfVisitors { get; set; }

        public IEnumerable<Visitor> Visitors { get; set; }

        public int TicketPrice { get; set; }

        public int IncentivesBudget { get; set; }

        public Point Dimensions { get; set; }

        public void GenerateIncentive()
        {
            // When to generate one
            // Which one to generate
            // How many people to offer it to
            // What is the target queue
        }

        public void Init()
        {
            this.Attractions = AttractionList;
            this.Dimensions = new Point(this.Attractions.Max(a => a.Location.X), this.Attractions.Max(a => a.Location.Y));
            this.Visitors = new List<Visitor>();
        }

        private static IEnumerable<Attraction> AttractionList = new List<Attraction>
        {
            // hardcode a semi realistic theme park
            // for each attraction set Location to row, column
            // this may be just an array or a list
            new Attraction { }, 
            new Attraction { },
        };
    }
}
