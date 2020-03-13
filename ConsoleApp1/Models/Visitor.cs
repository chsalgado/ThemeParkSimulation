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

        private static readonly List<IncentiveType> INCENTIVE_TYPES
            = Enum.GetValues(typeof(IncentiveType)).Cast<IncentiveType>().ToList();

        private static readonly IList<Func<IAttractionSelectionStrategy>> ATTRACTION_STRATEGY_CREATORS = new List<Func<IAttractionSelectionStrategy>>
        {
            () => new DistanceAttractionStrategy(),
            () => new PayoffAttractionStrategy(),
            () => new WaitTimeAttractionStrategy()

        };

        private static readonly IList<Func<IIncentiveAcceptanceStrategy>> INCENTIVE_STRATEGY_CREATORS = new List<Func<IIncentiveAcceptanceStrategy>>
        {
            () => new WaitTimeIncentiveStrategy(),
            () => new InversePayoffIncentiveStrategy()
        };

        private Random randomizer = new Random();

        public double AccruedPayoff { get; set; }

        public IDictionary<Attraction, double> AttractionPayoffMap { get; set; }

        public IDictionary<IncentiveType, double> IncentivePayoffMap { get; set; }

        // Like most, like, like less, do not like
        public AttractionCategory[] AttractionCategoriesPreferences { get; set; }

        public IAttractionSelectionStrategy AttranctionSelectionStrategy { get; set; }

        public IIncentiveAcceptanceStrategy IncentiveAcceptanceStrategy { get; set; }

        private int TimeLeftInAttraction { get; set; }

        public Attraction CurrentAttraction { get; set; }

        public Point Location { get; set; }

        /// <summary>
        /// Estimated wait time left in a queue in minutes
        /// </summary>
        public int EstimatedWaitTimeLeft
        {
            get
            {
                if (this.CurrentAttraction == null)
                {
                    return 0;
                }

                var positionInQueue = this.CurrentAttraction.VisitorsQueue.IndexOf(this);
                return (int)Math.Ceiling((double)positionInQueue / (double)this.CurrentAttraction.Capacity) * this.CurrentAttraction.RideTime;
            }
        }

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

            // Get an IAttractionSelectionStrategy
            AttranctionSelectionStrategy = ATTRACTION_STRATEGY_CREATORS[randomizer.Next(ATTRACTION_STRATEGY_CREATORS.Count())].Invoke();

            // Get an IIncentiveAcceptanceStrategy
            IncentiveAcceptanceStrategy = INCENTIVE_STRATEGY_CREATORS[randomizer.Next(INCENTIVE_STRATEGY_CREATORS.Count())].Invoke();
            
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

        public void EnqueueInAttraction(Attraction attraction)
        {
            attraction.VisitorsQueue.Add(this);

            this.CurrentAttraction = attraction;
            this.Location = attraction.Location;
        }

        public void EnjoyAttraction(Attraction attraction)
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

            if (TimeLeftInAttraction == 0)
            {
                this.CurrentAttraction = null;
            }
        }

        public Attraction GetNextAttraction(ThemePark themePark)
        {
            return AttranctionSelectionStrategy.GetNextAttraction(themePark, AttractionPayoffMap, this.Location);
        }


        public bool IsCurrentlyInAttraction()
        {
            return CurrentAttraction != null;
        }
    }
}
