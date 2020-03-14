using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Strategies
{
    public class WaitTimeBalanceGenerationStrategy : IIncentiveGenerationStrategy
    {
        public Incentive GenerateIncentive(
            List<Attraction> attractions,
            double totalBugdet,
            double usedBudget,
            int totalTime,
            int currentTime)
        {
            double budgetToSpend = totalBugdet * ((double)currentTime / totalTime) - usedBudget;
            if (budgetToSpend <= 0) return null;

            var attractionWithLongestWait =
                attractions.Aggregate(attractions[0], (max, curr) => curr.EstimatedWaitTime > max.EstimatedWaitTime ? curr : max);
            var attractionWithShortestWait =
                attractions.Aggregate(attractions[0], (min, curr) => curr.EstimatedWaitTime < min.EstimatedWaitTime ? curr : min);

            double W1 = attractionWithLongestWait.EstimatedWaitTime;
            double W2 = attractionWithShortestWait.EstimatedWaitTime;
            double Q1 = attractionWithLongestWait.VisitorsQueue.Count();
            double Q2 = attractionWithShortestWait.VisitorsQueue.Count();

            // some arithmetic gives this formula,so that the wait time between the two attractions should be about the same if n ppl
            // leaves the longest wait time queue
            int peopleToReceiveIncentives = (int)((W1 - W2) / (W1 / Q1 + W2 / Q2));

            double budgetPerPerson = budgetToSpend / peopleToReceiveIncentives;

            var affordableIncentives = Incentive.RealPrices.Where(k => k.Value <= budgetPerPerson);
            var incentiveType =
                affordableIncentives.Aggregate(affordableIncentives.First(), (max, curr) => curr.Value > max.Value ? curr : max).Key; 

            return new Incentive(
                incentiveType:incentiveType,
                offerToAttraction:attractionWithLongestWait,
                exchangeAtAttraction:attractionWithShortestWait,
                numberOfVisitorsToOffer:peopleToReceiveIncentives);
        }
    }
}
