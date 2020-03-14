using System;
using ConsoleApp1.Models;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            
            // for 1000 days run park n hours
            int days = 1;
            double totalPayoff = 0;
            for (int day = 1; day <= days; day++)
            {
                // create a theme park
                ThemeParkState themeParkState = new ThemeParkState(
                    numVisitors: 1,
                    operationMinutes: 1 * 20,
                    ticketPrice: 50);


                //debug
                foreach (var visitor in themeParkState.themePark.Visitors)
                {
                    Console.WriteLine("For visitor");
                    foreach (var kvp in visitor.AttractionPayoffMap)
                    {
                        //textBox3.Text += ("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                        Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                    }
                }

                // interval, 1 minute? choose a baseline based on ride time
                for (int time = 0; time < themeParkState.themePark.OperationMinutes; time++)
                {
                    Console.WriteLine("Time is {0}", time);
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
