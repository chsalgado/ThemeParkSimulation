using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Strategies
{
    public class WaitTimeBalanceGenerationStrategy : IIncentiveGenerationStrategy
    {
        public Incentive GenerateIncentive(IEnumerable<Attraction> attractions, double totalBugdet, double usedBudget, int operationHours, int currentTime)
        {
            return null;
        }
    }
}
