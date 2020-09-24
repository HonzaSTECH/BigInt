using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BigIntClass
{
    class StringInt
    {
        private string value;
        private bool isNegative;

        public string GetValue()
        {
            if (this.isNegative) { return "-" + this.value; }
            else { return this.value; }
        }

        private void SetValue(string value, bool isNegative = false)
        {
            this.isNegative = isNegative;
            this.value = value;
        }

        public StringInt(string value)
        {
            this.Set(value);
        }

        public override string ToString()
        {
            return this.GetValue();
        }

        public void Set(string value)
        {
            bool isNegative = false;
            if (value[0] == '-')
            {
                isNegative = true;
                value = value.Substring(1);
            }
            this.SetValue(value, isNegative);
        }

        public void Add(string addition)
        {
            Console.WriteLine("Called add with argument " + addition + " and value " + this.GetValue());
            if (!this.isNegative)
            {
                if (addition[0] != '-')
                {
                    //(+) + (+)
                    //Don't change anything
                }
                else
                {
                    //(+) + (-)
                    addition = addition.TrimStart('-');
                    this.Subtract(addition);
                    return;
                }
            }
            else
            {
                if (addition[0] != '-')
                {
                    //(-) + (+)
                    string temp = this.value;
                    this.Set(addition);
                    addition = temp.TrimStart('-');
                    this.isNegative = false;
                    this.Subtract(addition);
                    return;
                }
                else
                {
                    //(-) + (-)
                    addition = addition.TrimStart('-');
                }
            }

            int numLength = (addition.Length > this.value.Length) ? addition.Length : this.value.Length;
            numLength++;
            string num = this.value;
            short c = 0;
            string revertedResult = String.Empty;
            for (int i = 1; i <= numLength; i++)
            {
                short a = 0, b = 0;
                try
                {
                    a = Convert.ToInt16(num[num.Length - i].ToString());
                    b = Convert.ToInt16(addition[addition.Length - i].ToString());
                } catch (IndexOutOfRangeException) { }

                int result = Convert.ToInt16(a) + Convert.ToInt16(b) + c;
                c = 0;
                if (result >= 10)
                {
                    c++;
                    result -= 10;
                }
                revertedResult += result;
            }

            //Revert string
            char[] resultCharArr = revertedResult.ToCharArray();
            Array.Reverse(resultCharArr);
            this.value = new string(resultCharArr).TrimStart('0');
        }

        public void Subtract(string reducer)
        {
            Console.WriteLine("Called subtract with argument " + reducer + " and value " + this.GetValue());
            if (!this.isNegative)
            {
                if (reducer[0] != '-')
                {
                    //(+) - (+)
                    //Don't change anything
                }
                else
                {
                    //(+) - (-)
                    reducer = reducer.TrimStart('-');
                    this.Add(reducer);
                    return;
                }
            }
            else
            {
                if (reducer[0] != '-')
                {
                    //(-) - (+)
                    this.isNegative = false;
                    this.Add(reducer);
                    this.isNegative = true;
                    return;
                }
                else
                {
                    //(-) - (-)
                    //Don't change anything
                }
            }

            //Make sure the first number is greater than the reducer
            StringInt temp = new StringInt(reducer.TrimStart('-'));
            if (temp.GreaterThan(this.value.TrimStart('-')))
            {
                string tempVal = this.GetValue();
                this.Set(reducer);
                reducer = tempVal;
                this.isNegative = !this.isNegative;
            }

            reducer = reducer.TrimStart('-');

            int numLength = (reducer.Length > this.value.Length) ? reducer.Length : this.value.Length;
            numLength++;
            string num = this.value;
            short c = 0;
            string revertedResult = String.Empty;
            for (int i = 1; i <= numLength; i++)
            {
                short a = 0, b = 0;
                try
                {
                    a = Convert.ToInt16(num[num.Length - i].ToString());
                    b = Convert.ToInt16(reducer[reducer.Length - i].ToString());
                }
                catch (IndexOutOfRangeException) { }

                int result = Convert.ToInt16(a) - (Convert.ToInt16(b) + c);
                c = 0;
                if (result < 0)
                {
                    c++;
                    result += 10;
                }
                revertedResult += result;
            }

            //Revert string
            char[] resultCharArr = revertedResult.ToCharArray();
            Array.Reverse(resultCharArr);
            this.value = new string(resultCharArr).TrimStart('0');
        }

        public void Multiply(string factor)
        {
            Console.WriteLine("Called multiply with argument " + factor + " and value " + this.GetValue());

            if (factor[0] == '-' ^ this.isNegative)
            {
                this.isNegative = true;
                factor = factor.TrimStart('-');
            }
            else
            {
                this.isNegative = false;
            }
            
            string num = this.value;

            //Make sure the second factor (stored in variable factor) is shorter
            if (num.Length < factor.Length)
            {
                string temp = this.value;
                this.value = factor;
                factor = temp;
            }

            int factorLength = factor.Length;
            short c = 0;
            string[] partResults = new string[factorLength];
            for (int i = 1; i <= factorLength; i++)
            {
                short b = 0;
                string revertedResult = String.Empty;
                try
                {
                    b = Convert.ToInt16(factor[factor.Length - i].ToString());
                }
                catch (IndexOutOfRangeException) { }
                for (int j = 1; j <= num.Length - 1; j++)
                {
                    short a = 0;
                    try
                    {
                        a = Convert.ToInt16(num[num.Length - i].ToString());
                    }
                    catch (IndexOutOfRangeException) { }

                    int result = Convert.ToInt16(a) * (Convert.ToInt16(b) + c);
                    c = 0;
                    if (result < 0)
                    {
                        c = (short)(result / 10);
                        result %= 10;
                    }
                    revertedResult += result;
                }
                //Revert string and save it as part result
                char[] resultCharArr = revertedResult.ToCharArray();
                Array.Reverse(resultCharArr);
                partResults[i - 1] = new string(resultCharArr).TrimStart('0'); ;
            }

            //Add all part results together
            StringInt sum = new StringInt("0");
            for (int i = 0; i < factorLength; i++)
            {
                sum.Add(partResults[i]);
            }
            this.value = sum.GetValue().TrimStart('-');
        }

        public void Divide(string divisor)
        {
            throw new NotImplementedException();
        }

        public bool SmallerThan(string compare)
        {
            StringInt reversed = new StringInt(compare);
            return reversed.GreaterThan(this.value);
        }

        public bool GreaterThan(string compare)
        {
            //Check if one of the numbers is negative while the other one is positive
            if (compare[0] == '-' && !this.isNegative) { return true; }
            if (compare[0] != '-' && this.isNegative) { return false; }

            string thisValue = this.value;
            compare = compare.TrimStart('-');
            thisValue = thisValue.TrimStart('-');

            //Check if one of the numbers is longer
            if (compare.Length < thisValue.Length) { return true; }
            if (compare.Length > thisValue.Length) { return false; }

            //Check the digits one by one
            while (compare.Length > 0)
            {
                if (compare[0] < thisValue[0]) { return true; }
                if (compare[0] > thisValue[0]) { return false; }
                compare = compare.Substring(1);
                thisValue = thisValue.Substring(1);
            }
            return false;   //Equality
        }

        public bool EqualTo(string compare)
        {
            return (compare == this.GetValue()) ? true : false;
        }
    }
}
