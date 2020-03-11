using System;
using System.Collections.Generic;

namespace ConsoleApp1.Models
{
    public enum Decision
    {
        WAIT_IN_LINE,
        MOVE,
        ENJOUY_ATTRACTION
    };

    public interface IVisitor
    {
        Tuple<Decision, Attraction> getDecision(
            int timeLeft,
            Dictionary<Tuple<int, int>, Attraction> attractions,
            Dictionary<Attraction, double> attractionPayOff,
            Tuple<int, int> visitorLocation,
            Queue<Visitor> waitedQueue, // can be null if not waiting in a queue
            Dictionary<Attraction, Incentive> incentives
            );
    }
}
