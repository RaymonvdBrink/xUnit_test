using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xUnit_test
{
    public class PrimeService
    {
        IMock mock;
        
        public PrimeService(IMock mock)
        {
            this.mock = mock;
        }

        public bool IsPrime(int candidate)
        {
            if (candidate < 2)
            {
                return false;
            }
            throw new NotImplementedException("Not fully implemented.");
        }

        public bool True(int test)
        {
            return mock.True(test);
        }
    }

    public interface IMock
    {
        bool True(int test);
    }

    public class Mocking : IMock
    {
        public bool True(int test)
        {
            return true;
        }
    }
}
