using ConsoleApp1.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Visitor
    {
        public double AccruedPayoff { get; set; }

        public IDictionary<Attraction, double> AttractionPayoffMap { get; set; }

        public IDictionary<IncentiveType, double> IncentivePayoffMap { get; set; }

        // Like most, like, like less, do not like
        public AttractionCategory[] AttractionCategoriesPreferences { get; set; }

        public IVisitorStrategy VisitorStrategy { get; set; }

        private int TimeLeftInAttraction { get; set; }

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

        public void GetIntoAttraction(Attraction attraction)
        {
            var attractionPayoff = this.AttractionPayoffMap[attraction];

            // increase payoff
            this.AccruedPayoff += attractionPayoff;

            // cannot enqueue for rideTime
            TimeLeftInAttraction = attraction.RideTime;

            // decrease payoff for attraction (no one gets into the same attraction a lot of times)
            this.AttractionPayoffMap[attraction] = attractionPayoff / 2.0;
        }

        public void DecreaseTimeLeftInAttraction(int decreaseFactor)
        {
            TimeLeftInAttraction = Math.Max(0, TimeLeftInAttraction - decreaseFactor);
        }

        public bool IsCurrentlyInAttraction()
        {
            return TimeLeftInAttraction > 0;
        }
    }
}
