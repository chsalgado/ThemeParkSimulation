using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConsoleApp1.Strategies
{
    public class WaitTimeAttractionStrategy : IAttractionSelectionStrategy
    {
        public Attraction GetNextAttraction(ThemePark themePark, IDictionary<Attraction, double> attractionPayoffMap, Point lastLocation)
        {
            IDictionary<Attraction, double> modifiedAttractionPayoffMap = new Dictionary<Attraction, double>();
            double maxWaitTime = (double)modifiedAttractionPayoffMap.Aggregate((l, r) => l.Key.EstimatedWaitTime > r.Key.EstimatedWaitTime ? l : r).Key.EstimatedWaitTime;
            
            foreach (var keyValuePair in attractionPayoffMap)
            {
                var waitTimeRelativeToMax = (double)keyValuePair.Key.EstimatedWaitTime / (double)maxWaitTime * 0.5;
                var modifiedPayoff = keyValuePair.Value * (1.0 - waitTimeRelativeToMax);

                modifiedAttractionPayoffMap.Add(keyValuePair.Key, modifiedPayoff);
            }
          
            return modifiedAttractionPayoffMap.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }
    }
}
