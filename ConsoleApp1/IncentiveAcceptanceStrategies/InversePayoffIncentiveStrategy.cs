using ConsoleApp1.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Strategies
{
    public class InversePayoffIncentiveStrategy : IIncentiveAcceptanceStrategy
    {
        public bool IsIncentiveAccepted(Incentive incentive, Attraction currentAttraction, double currentWaitingTime, IDictionary<IncentiveType, double> incentivePayoffCoefficientMap, IDictionary<Attraction, double> attractionPayoffMap)
        {
            var incentivePayoff = incentivePayoffCoefficientMap[incentive.IncentiveType] * incentive.RetailValue;
            var associatedAttractionPayoff = attractionPayoffMap[incentive.AssociatedAttraction];
            var newPayoff = incentivePayoff + associatedAttractionPayoff;
            var timeToGetNewPayoff = incentive.AssociatedAttraction.EstimatedWaitTime + incentive.AssociatedAttraction.RideTime;
            double newPayoffAccrualRatio = newPayoff / timeToGetNewPayoff;

            var currentPayoff = attractionPayoffMap[currentAttraction];
            var timeToGetCurrentPayoff = currentWaitingTime + currentAttraction.RideTime;
            double currentPayoffAccrualRatio = currentPayoff / timeToGetCurrentPayoff;

            return newPayoffAccrualRatio > currentPayoffAccrualRatio;
        }
    }
}
