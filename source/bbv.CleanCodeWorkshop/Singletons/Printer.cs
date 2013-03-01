namespace Bbv.CleanCodeWorkshop.Singletons
{
    public class Printer
    {
        private static Printer instance;

        public static Printer Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Printer();
                }

                return instance;
            }
        }

        public void Print(Invoice invoice)
        {
        }
    }
}