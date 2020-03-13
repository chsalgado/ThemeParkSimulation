using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Strategies
{
    public interface IAttractionSelectionStrategy
    {
        Attraction GetNextAttraction(ThemePark themePark, IDictionary<Attraction, double> attractionPayoffMap, Attraction lastAttractionVisited);
    }
}
