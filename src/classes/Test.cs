namespace csharp1.classes
{
    public class Test : IName1, IName2
    {

        static void someStatic() {
        }

        Test() {
        }
        void IName1.test() 
        {
        }

        int IName2.test() {
            return 4;
        }
    }

    interface IName1
    {
        public void test();
    } 

    interface IName2
    {
        public int test();
    }
}