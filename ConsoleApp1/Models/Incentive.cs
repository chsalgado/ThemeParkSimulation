using ConsoleApp1.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1.Models
{
    public class Incentive
    {
        public static IDictionary<IncentiveType, int> RetailPrices = new Dictionary<IncentiveType, int>
        {
            { IncentiveType.SmallPlushie, 15 },
            { IncentiveType.BigPlushie, 30 },
            { IncentiveType.Snack, 10 },
            { IncentiveType.VipSeat, 20 }
        };

        public static IDictionary<IncentiveType, int> RealPrices = new Dictionary<IncentiveType, int>
        {
            { IncentiveType.SmallPlushie, 3 },
            { IncentiveType.BigPlushie, 6 },
            { IncentiveType.Snack, 2 },
            { IncentiveType.VipSeat, 10 } // Opportunity cost
        };

        public IncentiveType IncentiveType { get; }
        
        public int RetailValue { get; }

        public int RealValue { get; }

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
