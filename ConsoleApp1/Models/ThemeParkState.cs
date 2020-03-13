using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Models
{
    public class ThemeParkState
    {
        public readonly ThemePark themePark;
        public static int CurrentTime;

        private Random randomizer = new Random();

        public ThemeParkState(int numVisitors, int operationHours, double ticketPrice)
        {
            themePark = new ThemePark
            {
                NumberOfVisitors = numVisitors,
                OperationHours = operationHours,
                TicketPrice = ticketPrice,
                IncentivesBudget = ticketPrice * numVisitors / 10
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
                                    }).ToList();
        }

        private Dictionary<Attraction, Incentive> GetIncentives()
        {
            return null;
        }

        public void ProgressState(int currentTime)
        {
            CurrentTime = currentTime;

            // if themePark.Vistitors.Length < themePark.Visitors
            // add new visitors. Init()

            // shuffle the order of visitors
            themePark.Visitors = themePark.Visitors.OrderBy(v => randomizer.Next()).ToList();

            // for each visitor,
            for (int i = 0; i < themePark.Visitors.Count(); i++)
            {
                var visitor = themePark.Visitors[i];
                Console.WriteLine("visitor payoff is {0}", visitor.AccruedPayoff);
                Console.WriteLine("visitor time left is {0}", visitor.TimeLeftInAttraction);

                if (!visitor.IsCurrentlyInAttraction())
                {
                    // choose the next attraction if he is not in one
                    var nextAttraction = visitor.GetNextAttraction(themePark);
                    visitor.EnqueueInAttraction(nextAttraction);
                    Console.WriteLine("Visitor choose attraction {0}", nextAttraction.Location);
                }
                else if (visitor.TimeLeftInAttraction > 0)
                {
                    // decrease the time left if he is in an attraction
                    // if he is in the queue, this shouldn't do anything
                    visitor.DecreaseTimeLeftInAttraction(1);
                }

            }

            // somehow, we get the incentives, and pass it to the visitors in some way

            // for each attraction, drain queues
            for (int i = 0; i < themePark.Attractions.Count(); i++)
            {
                themePark.Attractions[i].DrainQueue();
            }
        }

        public double GetFinalPayoff()
        {
            return themePark.Visitors.Sum(v => v.AccruedPayoff);
        }
    }
}
