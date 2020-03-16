using System;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // for 1000 days run park n hours
            int days = 100;
            double totalPayoff = 0;
            int numberOfVisitors = 1000;
            int operationMinutes = 8 * 60;
            double ticketPrice = 50;
            int totalWaitTime = 0;

            for (int day = 1; day <= days; day++)
            {
                // create a theme park
                ThemeParkState themeParkState = new ThemeParkState(
                    numVisitors: numberOfVisitors,
                    operationMinutes: operationMinutes,
                    ticketPrice: ticketPrice);

                // interval, 1 minute? choose a baseline based on ride time
                for (int time = 0; time < themeParkState.themePark.OperationMinutes; time++)
                {
                    themeParkState.ProgressState(time);
                }

                var finalPayoff = themeParkState.GetFinalPayoff();
                totalPayoff += finalPayoff;
                var waitTime = themeParkState.GetTotalWaitTime();
                totalWaitTime += waitTime;
                Console.WriteLine("Final payoff is at day {0} is {1}", day, finalPayoff);
                //Console.WriteLine("Final wait-time is at day {0} is {1}", day, waitTime);
            }

            //Console.WriteLine("Total payoff after 1000 days is {0}", totalPayoff);
            Console.WriteLine("Total wait time after 1000 days is {0}", totalWaitTime);

            // run twice: once with incentives once w/o
            // compare payoff
            totalPayoff = 0;
            totalWaitTime = 0;
            for (int day = 1; day <= days; day++)
            {
                // create a theme park
                ThemeParkState themeParkState = new ThemeParkState(
                    numVisitors: numberOfVisitors,
                    operationMinutes: operationMinutes,
                    ticketPrice: ticketPrice);

                themeParkState.themePark.ShouldGenerateIncentives = true;
                themeParkState.themePark.IncentiveGenerationInterval = 10;


                // interval, 1 minute? choose a baseline based on ride time
                for (int time = 0; time < themeParkState.themePark.OperationMinutes; time++)
                {
                    themeParkState.ProgressState(time);
                }

                var finalPayoff = themeParkState.GetFinalPayoff() - themeParkState.themePark.UsedIncentivesBudget;
                totalPayoff += finalPayoff;
                var waitTime = themeParkState.GetTotalWaitTime();
                totalWaitTime += waitTime;
                Console.WriteLine("{0}", finalPayoff);
                //Console.WriteLine("Final wait-time is at day {0} is {1}", day, waitTime);
            }

            Console.WriteLine("Total payoff after 1000 days is {0}", totalPayoff);
            //Console.WriteLine("Total wait time after 1000 days is {0}", totalWaitTime);

        }

    }
}
