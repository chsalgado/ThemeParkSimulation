﻿using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConsoleApp1.Strategies
{
    public class DistanceVisitorStrategy : IVisitorStrategy
    {
        public Attraction GetNextAttraction(ThemePark themePark, IDictionary<Attraction, double> attractionPayoffMap, Attraction lastAttractionVisited)
        {
            IDictionary<Attraction, double> modifiedAttractionPayoffMap = new Dictionary<Attraction, double>();
            double maxDistance = Math.Sqrt(Math.Pow(themePark.Attractions[0].Length - 1 - 0, 2) + Math.Pow(themePark.Attractions.Length - 1 - 0, 2));
            
            foreach (var keyValuePair in attractionPayoffMap)
            {
                var distance = Math.Sqrt(Math.Pow(lastAttractionVisited.Location.X - keyValuePair.Key.Location.X, 2) + Math.Pow(lastAttractionVisited.Location.Y - keyValuePair.Key.Location.Y, 2));
                var distanceRelativeToMax = distance / maxDistance;
                var modifiedPayoff = keyValuePair.Value * (1 - distanceRelativeToMax);

                modifiedAttractionPayoffMap.Add(keyValuePair.Key, modifiedPayoff);
            }
          
            return modifiedAttractionPayoffMap.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;
        }
    }
}