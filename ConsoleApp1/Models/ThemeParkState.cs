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

        public ThemeParkState(int numVisitors, int operationMinutes, double ticketPrice)
        {
            themePark = new ThemePark
            {
                NumberOfVisitors = numVisitors,
                OperationMinutes = operationMinutes,
                TicketPrice = ticketPrice,
                IncentivesBudget = ticketPrice * numVisitors / 10,
                IncentiveGenerationInterval = 1,
                ShouldGenerateIncentives = false
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
            // *Foreach visitor.If not in attraction, select next attraction
            //* Theme park decides to generate incentive
            //* If an incentive was created, visitors decide to accept or not incentive
            //*Drain Queues
            CurrentTime = currentTime;

            // if themePark.Vistitors.Length < themePark.Visitors
            // add new visitors. Init()

            // shuffle the order of visitors
            themePark.Visitors = themePark.Visitors.OrderBy(v => randomizer.Next()).ToList();

            // for each visitor,
            for (int i = 0; i < themePark.Visitors.Count(); i++)
            {
                var visitor = themePark.Visitors[i];

                if (!visitor.IsCurrentlyInAttraction())
                {
                    // choose the next attraction if he is not in one
                    var nextAttraction = visitor.GetNextAttraction(themePark);
                    visitor.EnqueueInAttraction(nextAttraction);
                }
                else if (visitor.TimeLeftInAttraction > 0)
                {
                    // decrease the time left if he is in an attraction
                    // if he is in the queue, this shouldn't do anything
                    visitor.DecreaseTimeLeftInAttraction(1);
                }

            }

            // generate an incentive and offer it if needed
            var offeredIncentive = themePark.GenerateIncentive();
            if (offeredIncentive != null)
            {
                var visitorsToOfferIncentiveTo = offeredIncentive.OfferToAttraction.VisitorsQueue.Skip(Math.Max(0, offeredIncentive.OfferToAttraction.VisitorsQueue.Count() - offeredIncentive.NumberOfVisitorsToOffer));
                
                foreach (var visitorToOfferIncentiveTo in visitorsToOfferIncentiveTo)
                {
                    if (visitorToOfferIncentiveTo.IsIncentiveAccepted(offeredIncentive))
                    {
                        visitorToOfferIncentiveTo.AcceptIncentive(offeredIncentive);
                        themePark.UsedIncentivesBudget += offeredIncentive.RealValue;
                    }
                }
            }

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
