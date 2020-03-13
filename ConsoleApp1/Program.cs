using System;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // for 1000 days run park n hours
            int days = 2;
            double totalPayoff = 0;
            for (int day = 1; day <= days; day++)
            {
                // create a theme park
                ThemeParkState themeParkState = new ThemeParkState(
                    numVisitors: 10,
                    operationHours:3,
                    ticketPrice: 10,
                    incentiveBudget:10);

                // interval, 1 minute? choose a baseline based on ride time
                int operatingTime = themeParkState.themePark.OperationHours * 60;
                for (int time = 0; time < operatingTime; time++)
                {
                    themeParkState.ProgressState(time);
                }

                var finalPayoff = themeParkState.GetFinalPayoff();
                totalPayoff += finalPayoff;
                Console.WriteLine("Final payoff is at day {0} is {1}", day, finalPayoff);
            }

            Console.WriteLine("Total payoff after 1000 days is {0}", totalPayoff);

            // run twice: once with incentives once w/o
            // compare payoff
        }

    }
}
