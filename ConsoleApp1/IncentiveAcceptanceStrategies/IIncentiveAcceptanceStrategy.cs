using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Strategies
{
    public interface IIncentiveAcceptanceStrategy
    {
        bool IsIncentiveAccepted(Incentive incentive, Attraction currentAttraction, double currentWaitingTime, IDictionary<IncentiveType, double> incentivePayoffMap, IDictionary<Attraction, double> attractionPayoffMap);
    }
}
