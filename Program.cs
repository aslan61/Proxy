using System;
using System.Threading;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            CreditBase creditManager=new CreditManagerProxy();
            Console.WriteLine( creditManager.Calculate() );
            Console.WriteLine(creditManager.Calculate());
            Console.ReadLine();
        }
    }
    abstract class CreditBase
    {
        public abstract int Calculate();
    }
    class CreditManager : CreditBase
    {
        public override int Calculate()
        {
            int result=1;
            for (int i = 1; i < 5; i++)
            {
                result *= i;
                Thread.Sleep(1000);
            }
            return result;
        }
    }
    class CreditManagerProxy : CreditBase
    {
        private CreditManager _creditManager1;
        private int _cachedValue;
        public override int Calculate()
        {
            if (_creditManager1==null)
            {
                _creditManager1 = new CreditManager();
                _cachedValue = _creditManager1.Calculate();
            }
            return _cachedValue;    
        }
    }
}
