using ConsoleApp1.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Strategies
{
    public class PayoffAttractionStrategy : IAttractionSelectionStrategy
    {
        public Attraction GetNextAttraction(ThemePark themePark, IDictionary<Attraction, double> attractionPayoffMap, Attraction lastAttractionVisited)
        {
            return attractionPayoffMap.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }
    }
}
