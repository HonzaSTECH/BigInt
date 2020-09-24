using System;
using System.Collections.Generic;

namespace BigIntClass
{
    class BigInt
    {
        private List<int> value = new List<int>();

        public BigInt(string num)
        {
            try
            {
                this.value.Add(Convert.ToInt32(num));
            }
            catch (OverflowException)
            {
                this.value.Add(int.MaxValue);
                //num -= int.MaxValue;
            }
        }

        public bool SmallerThan(BigInt compare)
        {
            throw new NotImplementedException();
        }
        public bool SmallerThan(int compare)
        {
            throw new NotImplementedException();
        }

        public bool LargerThan(BigInt compare)
        {
            throw new NotImplementedException();
        }
        public bool LargerThan(int compare)
        {
            throw new NotImplementedException();
        }

        public bool EqualToo(BigInt compare)
        {
            throw new NotImplementedException();
        }
        public bool EqualToo(int compare)
        {
            throw new NotImplementedException();
        }

        public void Add(int addition)
        {
            throw new NotImplementedException();
        }
        public void Add(BigInt addition)
        {
            throw new NotImplementedException();
        }

        public void Subtract(int reducer)
        {
            throw new NotImplementedException();
        }
        public void Subtract(BigInt reducer)
        {
            throw new NotImplementedException();
        }

        public void Multiply(int factor)
        {
            throw new NotImplementedException();
        }
        public void Multiply(BigInt factor)
        {
            
            throw new NotImplementedException();
        }

        public void Divide(int divisor)
        {
            throw new NotImplementedException();
        }
        public void Divide(BigInt divisor)
        {
            throw new NotImplementedException();
        }
    }
}
