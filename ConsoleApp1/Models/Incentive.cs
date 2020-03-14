using ConsoleApp1.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Incentive
    {
        private static IDictionary<IncentiveType, int> RetailPrices = new Dictionary<IncentiveType, int>
        {
            { IncentiveType.SmallPlushie, 15.0 },
            { IncentiveType.BigPlushie, 30.0 },
            { IncentiveType.Snack, 10.0 },
            { IncentiveType.VipSeat, 20.0 }
        };

        public static IDictionary<IncentiveType, double> RealPrices = new Dictionary<IncentiveType, double>
        {
            { IncentiveType.SmallPlushie, 3.0 },
            { IncentiveType.BigPlushie, 6.0 },
            { IncentiveType.Snack, 2.0 },
            { IncentiveType.VipSeat, 10.0 } // Opportunity cost
        };

        public IncentiveType IncentiveType { get; }
        
        public double RetailValue { get; }

        public double RealValue { get; }

        public Attraction ExchangeAtAttraction { get; }

        public Attraction OfferToAttraction { get; }

        public int NumberOfVisitorsToOffer { get; }

        public Incentive(IncentiveType incentiveType, Attraction offerToAttraction, Attraction exchangeAtAttraction, int numberOfVisitorsToOffer)
        {
            this.IncentiveType = incentiveType;
            this.OfferToAttraction = offerToAttraction;
            this.ExchangeAtAttraction = exchangeAtAttraction;
            this.NumberOfVisitorsToOffer = numberOfVisitorsToOffer;

            this.RetailValue = RetailPrices[incentiveType];
            this.RealValue = RealPrices[incentiveType];
        }
    }
}
