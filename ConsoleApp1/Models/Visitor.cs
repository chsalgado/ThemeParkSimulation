using ConsoleApp1.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Visitor
    {
        public int AccruedPayoff { get; set; }

        public IDictionary<Attraction, int> AttractionPayoffMap { get; set; }
        public IDictionary<IncentiveType, int> IncentivePayoffMap { get; set; }

        // Like most, like, like less, do not like
        public AttractionCategory[] AttractionCategoriesPreferences { get; set; }

        public IVisitorStrategy VisitorStrategy { get; set; }

        public void Init()
        {
            // Fill category preferences
            // Fill payoff maps
            // Get an IVisitorStrategy
        }

        public bool AcceptIncentive(Incentive incentive)
        {
            // dequeue
            // queue into new attraction
            // get some payoff
            // decrease payoff for incentive (i may be happy with one plushie, but the second one makes me less happy)
            return true;
        }

        public void GetIntoAttraction()
        {
            // increase payoff
            // cannot enqueue for rideTime
            // decrease payoff for attraction (no one gets into the same attraction a lot of times)
        }
    }
}
