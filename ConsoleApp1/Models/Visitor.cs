using ConsoleApp1.Strategies;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Visitor
    {
        private static Tuple<double, double>[] PAYOFF_RANGES = new Tuple<double, double>[]
        {

        };

        private static readonly List<AttractionCategory> ATTRACTION_CATEGORIES
            = Enum.GetValues(typeof(AttractionCategory)).Cast<AttractionCategory>().ToList();

        private static readonly List<Func<IVisitorStrategy>> STRATEGY_CREATORS = new List<Func<IVisitorStrategy>>
        {
            () => new DistanceVisitorStrategy(),
            () => new PayoffVisitorStrategy(),
            () => new WaitTimeVisitorStrategy()

        };

        private Random randomizer = new Random();

        private Attraction lastAttractionVisited = null;

        public double AccruedPayoff { get; set; }

        public IDictionary<Attraction, double> AttractionPayoffMap { get; set; }

        public IDictionary<IncentiveType, double> IncentivePayoffMap { get; set; }

        // Like most, like, like less, do not like
        public AttractionCategory[] AttractionCategoriesPreferences { get; set; }

        public IVisitorStrategy VisitorStrategy { get; set; }

        private int TimeLeftInAttraction { get; set; }

        public Attraction CurrentAttraction { get; set; }

        public Point Location { get; set; }

        public void Init(IEnumerable<Attraction> attractions)
        {
            // Fill category preferences
            var attractionCategories = ATTRACTION_CATEGORIES.OrderBy(a => randomizer.NextDouble()).ToList();
            var payoffRangeForCategory = new Dictionary<AttractionCategory, Tuple<double, double>>();
            for (int i = 0; i < attractionCategories.Count(); i ++)
            {
                payoffRangeForCategory.Add(attractionCategories[i], PAYOFF_RANGES[i]);
            }

            // Fill payoff maps
            AttractionPayoffMap = new Dictionary<Attraction, double> ();
            foreach (var attraction in attractions)
            {
                var ranges = payoffRangeForCategory[attraction.AttractionCategory];
                var min = ranges.Item1;
                var max = ranges.Item2;
                var payoff = randomizer.NextDouble() * (max - min) + min;
                AttractionPayoffMap[attraction] = payoff;
            }

            // Get an IVisitorStrategy
            VisitorStrategy = STRATEGY_CREATORS[randomizer.Next(STRATEGY_CREATORS.Count())].Invoke();

            // Set Location to 0, 0
            Location = new Point(0, 0);

            AccruedPayoff = 0;
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
            this.CurrentAttraction = attraction;
            this.Location = attraction.Location;

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

            if (TimeLeftInAttraction == 0)
            {
                this.lastAttractionVisited = CurrentAttraction;
                this.CurrentAttraction = null;
            }
        }

        public Attraction GetNextAttraction(ThemePark themePark)
        {
            return VisitorStrategy.GetNextAttraction(themePark, AttractionPayoffMap, lastAttractionVisited);
        }


        public bool IsCurrentlyInAttraction()
        {
            return CurrentAttraction != null;
        }
    }
}
