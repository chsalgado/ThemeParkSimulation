using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Models
{
    public class ThemeParkState
    {
        private ThemePark themePark;

        public ThemeParkState()
        {
            themePark = new ThemePark();
            themePark.Init();

            themePark.Attractions.ToList().ForEach(a => a.Init());
        }

        private Dictionary<Attraction, Incentive> GetIncentives()
        {
            return null;
        }

        public void progressState()
        {
            // if themePark.Vistitors.Length < themePark.Visitors
            // add new visitors. Init()

            // shuffle the order of visitors
            
            // for each visitor
                // get the time left
                // get the payoffs for each attractions for the visitor
                // get his position
                // get the queue he is in, if any
                // get incentive offered for each attractions.
                // feed all these information to the visitor to decide
                // collect the decision of visitor

            // for each decision make by the visitor, update the state
                // update the queue
                // update the position
                // update the payoff for each attraction
                // update the total payoff earned
        }
    }
}
