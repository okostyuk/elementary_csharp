using System;

namespace inheritance {

    class Printer {
        public int field = 1;
        private int prop = 2;
        public virtual int Property { get{return prop;}}
        public virtual int Method() {
            return 3;
        }
        public virtual String Method2() {
            return Method() + " " + prop ;
        }

        public static void Test(Printer p) {
            Console.WriteLine(p.GetType() + ": " + p.field + " " + p.prop + " " + p.Property + " " + p.Method() +" " +  p.Method2());
            if (p is SecondPrinter) {
                SecondPrinter p2 = (SecondPrinter) p;
                Console.WriteLine(p2.GetType() + ": " + p2.field + " " + p2.prop + " " + p2.Property + " " + p2.Method() +" " +  p2.Method2());
            }
        }
        delegate int Message();
        static void MainOld(string[] args)
        {
            Printer p = new Printer();
            Printer p2 = new SecondPrinter();
            Printer.Test(p);
            Printer.Test(p2);
            Message mes = p.Method;


        }
    }

    class SecondPrinter : Printer 
    {
        private int field = 11;
        private int prop = 22;
        public int Property { get{return prop;}}
        public override int Method() {
            return 33;
        }

        public override String Method2() {
            return Method() + " " + prop + " base: " + base.Method2();
        }
    }


}