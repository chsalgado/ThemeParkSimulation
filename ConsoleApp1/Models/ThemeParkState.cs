using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Models
{
    public class ThemeParkState
    {
        private ThemePark themePark;
        private Random randomizer = new Random();

        private Dictionary<Visitor, Queue<Visitor>> visitorQueueMap;

        public ThemeParkState()
        {
            themePark = new ThemePark();
            themePark.Init();

            themePark.Attractions.ToList().ForEach(a => a.Init());

            visitorQueueMap = new Dictionary<Visitor, Queue<Visitor>>();
        }

        private Dictionary<Attraction, Incentive> GetIncentives()
        {
            return null;
        }

        public void progressState(int currentTime)
        {
            // if themePark.Vistitors.Length < themePark.Visitors
            // add new visitors. Init()

            // shuffle the order of visitors
            themePark.Visitors = themePark.Visitors.OrderBy(v => randomizer.Next()).ToList();

            // for each visitor, choose the next attraction if he is not in one 
            foreach (var visitor in themePark.Visitors)
            {
                if (!visitor.IsCurrentlyInAttraction())
                {
                    var nextAttraction = visitor.GetNextAttraction(themePark);
                    nextAttraction.VisitorsQueue.Enqueue(visitor);
                }

            }

            // when to call DecreaseTimeLeftInAttraction

            // for each attraction, first n visitors in line get to enjoy it
            foreach (var attraction in themePark.Attractions)
            {
                // if can take more visitors

                for (int i = 0; i < attraction.Capacity; i++)
                {
                    if (attraction.VisitorsQueue.Count() == 0) break;
                    var visitor = attraction.VisitorsQueue.Dequeue();
                    visitor.GetIntoAttraction(attraction);
                }
            }

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
