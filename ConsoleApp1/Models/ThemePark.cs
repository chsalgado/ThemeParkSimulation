using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Models
{
    public class ThemePark
    {
        /// <summary>
        /// A theme park has attractions uniformly distributed in a grid
        /// </summary>
        public Attraction[][] Attractions { get; set; }

        public int OperationHours { get; set; }

        /// <summary>
        /// How many? Research six flags?
        /// </summary>
        public int NumberOfVisitors { get; set; }

        public IEnumerable<Visitor> Visitors { get; set; }

        public int TicketPrice { get; set; }

        public int IncentivesBudget { get; set; }

        public void GenerateIncentive()
        {
            // When to generate one
            // Which one to generate
            // How many people to offer it to
            // What is the target queue
        }

        public void Init()
        {
            // hardcode a semi realistic theme park
        }
    }
}
