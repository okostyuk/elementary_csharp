using System;

namespace csharp1.classes
{
    class Address
    {
        private String appartmentField = "ASD";

        public String index { get; set; }
        public String country { get; set; }
        public String city { get; set; }
        public String street { get; set; }
        public String house { get; set; }
        //propfull tab tab
        public String appartment
        {
            get { return appartmentField;}
            set { appartmentField = value;}
        }


        override public String ToString() {
            return "index: " + index + "\n"
            + "Country: " + country + "\n"
            + "City: " + city + "\n"
            + "Street: " + street + "\n"
            + "App: " + appartment
            ;
        }
        
    }
}
