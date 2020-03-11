using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public class ThemeParkState
    {
        private Dictionary<Tuple<int, int>, Attraction> attractions;
        private Dictionary<Attraction, Queue<IVisitor>> attractionQueues;
        private List<IVisitor> visitors;
        private Dictionary<IVisitor, Queue<IVisitor>> visitorQueueMap;
        private Dictionary<IVisitor, Tuple<int, int>> visitorLocations;
        private Dictionary<IVisitor, Dictionary<Attraction, double>> visitorAttractionPayoffs;
        private Dictionary<IVisitor, Dictionary<IncentiveType, double>> visitorIncentivePayoffs;

        public ThemeParkState()
        {
            attractions = initAttractions();
            attractionQueues = new Dictionary<Attraction, Queue<IVisitor>>();
            foreach (var attraction in attractions.Values)
            {
                var queue = new Queue<IVisitor>();
                attractionQueues.Add(attraction, queue);
            }

            visitors = initVisitors();
            visitorQueueMap = new Dictionary<IVisitor, Queue<IVisitor>>();
            visitorLocations = new Dictionary<IVisitor, Tuple<int, int>>();
            visitorAttractionPayoffs = new Dictionary<IVisitor, Dictionary<Attraction, double>>();
            foreach (var visitor in visitors)
            {
                visitorQueueMap.Add(visitor, null);
                visitorLocations.Add(visitor, Tuple.Create(0, 0));
                visitorAttractionPayoffs.Add(visitor, initVisitorAttractionPayoffs(visitor));
            }

        }

        private Dictionary<Tuple<int, int>, Attraction> initAttractions()
        {
            return null;
        }

        private List<IVisitor> initVisitors()
        {
            return null;
        }

        private Dictionary<Attraction, double> initVisitorAttractionPayoffs(IVisitor visitor)
        {
            return null;
        }

        private Dictionary<Attraction, Incentive> getIncentives()
        {
            return null;
        }

        public void progressState()
        {
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
