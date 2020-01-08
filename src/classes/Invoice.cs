using System;

namespace csharp1.classes
{
    class Invoice 
    {
        public static double TAX_VALUE = 0.2;
        readonly int account;
        readonly String customer;
        readonly String provider;

        //private String article;
        //private int quantity;

        public Invoice(int acc, String customer, String provider) {
            this.account = acc;
            this.customer = customer;
            this.provider = provider;
        }

    }
}