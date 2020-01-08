using System;

namespace csharp1.classes 
{
    class Converter
    {

        private readonly double usd, eur, rur;
        public Converter(double usd, double eur, double rur) 
        {
            this.usd = usd;
            this.eur = eur;
            this.rur = rur;
        }

        public double ToUah(double amount, Currency currency) {
            switch (currency) {
                case Currency.USD: return amount*usd;
                case Currency.EUR: return amount*eur;
                case Currency.RUR: return amount*rur;
            }
            throw new Exception();
        }

        public double FromUah(double amount, Currency currency) {
            switch (currency) {
                case Currency.USD: return amount/usd;
                case Currency.EUR: return amount/eur;
                case Currency.RUR: return amount/rur;
            }
            throw new Exception();
        }
    }

    public enum Currency {
        USD, EUR, RUR
    }
}