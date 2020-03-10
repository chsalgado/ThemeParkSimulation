using ConsoleApp1.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Incentive
    {
        public IncentiveType IncentiveType { get; set; }
        
        public int RetailValue { get; set; }

        public int RealValue { get; set; }

        public Attraction AssociatedAttraction { get; set; }

        public int NumberOfVisitorsToOffer { get; set; }
    }
}
