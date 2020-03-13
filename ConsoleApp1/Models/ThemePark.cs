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
        public IEnumerable<Attraction> Attractions { get; }

        public int OperationHours { get; set; }

        /// <summary>
        /// How many? Research six flags?
        /// </summary>
        public int NumberOfVisitors { get; set; }

        public List<Visitor> Visitors { get; set; }

        public double TicketPrice { get; set; }

        public double IncentivesBudget { get; set; }

        public Point Dimensions { get; set; }

        public ThemePark()
        {
            this.Attractions = ATTRACTION_LIST;
            this.Dimensions = new Point(this.Attractions.Max(a => a.Location.X), this.Attractions.Max(a => a.Location.Y));
            this.Visitors = new List<Visitor>();
        }

        public void GenerateIncentive()
        {
            // When to generate one
            // Which one to generate
            // How many people to offer it to
            // What is the target queue
        }

        private static IEnumerable<Attraction> ATTRACTION_LIST = new List<Attraction>
        {
            // hardcode a semi realistic theme park
            // for each attraction set Location to row, column
            // this may be just an array or a list
            new Attraction {
                RideTime = 15,
                Capacity = 10,
                AttractionCategory = AttractionCategory.Extreme,
                Location = new Point(3, 2)
            },
            new Attraction {
                RideTime = 15,
                Capacity = 10,
                AttractionCategory = AttractionCategory.Family,
                Location = new Point(5, 5)
            },
            new Attraction {
                RideTime = 15,
                Capacity = 10,
                AttractionCategory = AttractionCategory.Kids,
                Location = new Point(4, 5)
            },
            new Attraction {
                RideTime = 15,
                Capacity = 10,
                AttractionCategory = AttractionCategory.LiveShow,
                Location = new Point(1, 2)
            }
        };
    }
}
