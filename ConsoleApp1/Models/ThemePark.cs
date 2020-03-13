﻿using System;
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
        public List<Attraction> Attractions { get; }

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
            this.Attractions = getAttractionList();
            this.Dimensions = new Point(this.Attractions.Max(a => a.Location.X), this.Attractions.Max(a => a.Location.Y));
            this.Visitors = new List<Visitor>();
        }

        public Incentive GenerateIncentive()
        {
            // When to generate one
            // Which one to generate
            // How many people to offer it to
            // What is the target queue
            return null;
        }

        #region AttractionList
        private static List<Attraction> getAttractionList()
        {
            return new List<Attraction>
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
                },
                // Real attractions
                //new Attraction {
                //    RideTime = 6,
                //    Capacity = 28,
                //    AttractionCategory = AttractionCategory.Family,
                //    Location = new Point(0, 0)
                //},
                //new Attraction {
                //    RideTime = 4,
                //    Capacity = 32,
                //    AttractionCategory = AttractionCategory.Family,
                //    Location = new Point(0, 1)
                //},
                //new Attraction {
                //    RideTime = 7,
                //    Capacity = 36,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(0, 2)
                //},
                //new Attraction {
                //    RideTime = 6,
                //    Capacity = 64,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(0, 3)
                //},
                //new Attraction {
                //    RideTime = 25,
                //    Capacity = 50,
                //    AttractionCategory = AttractionCategory.LiveShow,
                //    Location = new Point(0, 4)
                //},
                //new Attraction {
                //    RideTime = 5,
                //    Capacity = 12,
                //    AttractionCategory = AttractionCategory.Kids,
                //    Location = new Point(0, 5)
                //},
                //new Attraction {
                //    RideTime = 4,
                //    Capacity = 12,
                //    AttractionCategory = AttractionCategory.Kids,
                //    Location = new Point(1, 0)
                //},
                //new Attraction {
                //    RideTime = 6,
                //    Capacity = 12,
                //    AttractionCategory = AttractionCategory.Family,
                //    Location = new Point(1, 1)
                //},
                //new Attraction {
                //    RideTime = 5,
                //    Capacity = 56,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(1, 2)
                //},
                //new Attraction {
                //    RideTime = 6,
                //    Capacity = 15,
                //    AttractionCategory = AttractionCategory.Kids,
                //    Location = new Point(1, 3)
                //},
                //new Attraction {
                //    RideTime = 25,
                //    Capacity = 100,
                //    AttractionCategory = AttractionCategory.Family,
                //    Location = new Point(1, 4)
                //},
                //new Attraction {
                //    RideTime = 35,
                //    Capacity = 100,
                //    AttractionCategory = AttractionCategory.LiveShow,
                //    Location = new Point(1, 5)
                //},
                //new Attraction {
                //    RideTime = 5,
                //    Capacity = 24,
                //    AttractionCategory = AttractionCategory.Kids,
                //    Location = new Point(2, 0)
                //},
                //new Attraction {
                //    RideTime = 6,
                //    Capacity = 32,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(2, 1)
                //},
                //new Attraction {
                //    RideTime = 7,
                //    Capacity = 24,
                //    AttractionCategory = AttractionCategory.Family,
                //    Location = new Point(2, 2)
                //},
                //new Attraction {
                //    RideTime = 7,
                //    Capacity = 32,
                //    AttractionCategory = AttractionCategory.Kids,
                //    Location = new Point(2, 3)
                //},
                //new Attraction {
                //    RideTime = 5,
                //    Capacity = 24,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(2, 4)
                //},
                //new Attraction {
                //    RideTime = 7,
                //    Capacity = 28,
                //    AttractionCategory = AttractionCategory.Family,
                //    Location = new Point(2, 5)
                //},
                //new Attraction {
                //    RideTime = 7,
                //    Capacity = 48,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(3, 0)
                //},
                //new Attraction {
                //    RideTime = 6,
                //    Capacity = 24,
                //    AttractionCategory = AttractionCategory.Kids,
                //    Location = new Point(3, 1)
                //},
                //new Attraction {
                //    RideTime = 5,
                //    Capacity = 12,
                //    AttractionCategory = AttractionCategory.Kids,
                //    Location = new Point(3, 2)
                //},
                //new Attraction {
                //    RideTime = 7,
                //    Capacity = 24,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(3, 3)
                //},
                //new Attraction {
                //    RideTime = 6,
                //    Capacity = 16,
                //    AttractionCategory = AttractionCategory.Family,
                //    Location = new Point(3, 4)
                //},
                //new Attraction {
                //    RideTime = 7,
                //    Capacity = 24,
                //    AttractionCategory = AttractionCategory.Family,
                //    Location = new Point(3, 5)
                //},
                //new Attraction {
                //    RideTime = 12,
                //    Capacity = 4,
                //    AttractionCategory = AttractionCategory.Kids,
                //    Location = new Point(4, 0)
                //},
                //new Attraction {
                //    RideTime = 7,
                //    Capacity = 36,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(4, 1)
                //},
                //new Attraction {
                //    RideTime = 35,
                //    Capacity = 80,
                //    AttractionCategory = AttractionCategory.LiveShow,
                //    Location = new Point(4, 2)
                //},
                //new Attraction {
                //    RideTime = 8,
                //    Capacity = 32,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(4, 3)
                //},
                //new Attraction {
                //    RideTime = 7,
                //    Capacity = 16,
                //    AttractionCategory = AttractionCategory.Family,
                //    Location = new Point(4, 4)
                //},
                //new Attraction {
                //    RideTime = 8,
                //    Capacity = 24,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(4, 5)
                //},
                //new Attraction {
                //    RideTime = 6,
                //    Capacity = 24,
                //    AttractionCategory = AttractionCategory.Kids,
                //    Location = new Point(5, 0)
                //},
                //new Attraction {
                //    RideTime = 6,
                //    Capacity = 24,
                //    AttractionCategory = AttractionCategory.Family,
                //    Location = new Point(5, 1)
                //},
                //new Attraction {
                //    RideTime = 5,
                //    Capacity = 12,
                //    AttractionCategory = AttractionCategory.Family,
                //    Location = new Point(5, 2)
                //},
                //new Attraction {
                //    RideTime = 5,
                //    Capacity = 12,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(5, 3)
                //},
                //new Attraction {
                //    RideTime = 25,
                //    Capacity = 45,
                //    AttractionCategory = AttractionCategory.LiveShow,
                //    Location = new Point(5, 4)
                //},
                //new Attraction {
                //    RideTime = 8,
                //    Capacity = 24,
                //    AttractionCategory = AttractionCategory.Extreme,
                //    Location = new Point(5, 5)
                //}
            };
        }
        #endregion
    }
}
