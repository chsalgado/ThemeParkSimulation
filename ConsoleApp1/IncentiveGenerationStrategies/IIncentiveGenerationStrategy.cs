using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Strategies
{
    public interface IIncentiveGenerationStrategy
    {
        Incentive GenerateIncentive(List<Attraction> attractions, double totalBugdet, double usedBudget, int totalTime, int currentTime);
    }
}
