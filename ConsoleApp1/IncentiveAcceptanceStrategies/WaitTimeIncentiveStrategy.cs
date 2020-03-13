using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Strategies
{
    public class WaitTimeIncentiveStrategy : IIncentiveAcceptanceStrategy
    {
        private static double WaitTimeDiscountFactor = 0.95;
        public bool IsIncentiveAccepted(Incentive incentive, Attraction currentAttraction, double currentWaitingTime, IDictionary<IncentiveType, double> incentivePayoffCoefficientMap, IDictionary<Attraction, double> attractionPayoffMap)
        {
            var incentivePayoff = incentivePayoffCoefficientMap[incentive.IncentiveType] * incentive.RetailValue;
            var associatedAttractionPayoff = attractionPayoffMap[incentive.AssociatedAttraction];
            var newPayoff = incentivePayoff + associatedAttractionPayoff;
            var timeToGetNewPayoff = incentive.AssociatedAttraction.EstimatedWaitTime + incentive.AssociatedAttraction.RideTime;
            double exponentiallyWeightedNewPayoff = Math.Pow(WaitTimeDiscountFactor, timeToGetNewPayoff) * newPayoff;

            var currentPayoff = attractionPayoffMap[currentAttraction];
            var timeToGetCurrentPayoff = currentWaitingTime + currentAttraction.RideTime;
            double exponentiallyWeightedCurrentPayoff = Math.Pow(WaitTimeDiscountFactor, timeToGetCurrentPayoff) * currentPayoff;

            return exponentiallyWeightedNewPayoff > exponentiallyWeightedCurrentPayoff;
        }
    }
}
