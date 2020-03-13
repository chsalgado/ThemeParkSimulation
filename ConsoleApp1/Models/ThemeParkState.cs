using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Models
{
    public class ThemeParkState
    {
        public readonly ThemePark themePark;
        private Random randomizer = new Random();

        public ThemeParkState(int numVisitors, int operationHours, double ticketPrice, double incentiveBudget)
        {
            themePark = new ThemePark
            {
                NumberOfVisitors = numVisitors,
                OperationHours = operationHours,
                TicketPrice = ticketPrice,
                IncentivesBudget = incentiveBudget
            };

            InitVisitors(themePark);
        }

        private void InitVisitors(ThemePark themePark)
        {
            themePark.Visitors = Enumerable.Range(0, themePark.NumberOfVisitors).Select((i) =>
                                    {
                                        var visitor = new Visitor();
                                        visitor.Init(themePark.Attractions);

                                        return visitor;
                                    });
        }

        private Dictionary<Attraction, Incentive> GetIncentives()
        {
            return null;
        }

        public void ProgressState(int currentTime)
        {
            // if themePark.Vistitors.Length < themePark.Visitors
            // add new visitors. Init()

            // shuffle the order of visitors
            themePark.Visitors = themePark.Visitors.OrderBy(v => randomizer.Next());

            // for each visitor,
            foreach (var visitor in themePark.Visitors)
            {
                if (!visitor.IsCurrentlyInAttraction())
                {
                    // choose the next attraction if he is not in one 
                    var nextAttraction = visitor.GetNextAttraction(themePark);
                    visitor.EnqueueInAttraction(nextAttraction);
                }
                else
                {
                    // decrease the time left if he is in an attraction
                    // if he is in the queue, this shouldn't do anything
                    visitor.DecreaseTimeLeftInAttraction(1);
                }

            }

            // somehow, we get the incentives, and pass it to the visitors in some way

            // for each attraction, drain queues
            themePark.Attractions.ToList().ForEach(a => a.DrainQueue(currentTime));
        }

        public double GetFinalPayoff()
        {
            return themePark.Visitors.Sum(v => v.AccruedPayoff);
        }
    }
}
