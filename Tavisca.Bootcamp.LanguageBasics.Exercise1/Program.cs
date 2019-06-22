using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        private const int Flag = 0;

        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }
        public static int Calculation(string s_num1,string s_num2,string s_num,int flag)
        {
            int num1,num2;
            int temp,j;
            string s_temp;
            num1=Int32.Parse(s_num1);
            num2=Int32.Parse(s_num2);
            if(flag==0)
                temp=num1*num2;
            else
            {
                if(num2%num1!=0||num1==0||num2==0)
                    return -1;
                temp=num2/num1;
            }
             s_temp=temp.ToString();
             if(s_temp.Length==s_num.Length)
             {
                j=s_num.IndexOf('?');
                return s_temp[j]-'0';
             }
             else
                return -1;
        }
        public static int FindDigit(string equation)
        {
            string[] arrayABC=equation.Split("*");
            string A=arrayABC[0];
            string[] arrayBC=arrayABC[1].Split("=");
            string B=arrayBC[0];
            string R=arrayBC[1];
            int m_digit;
            if(A.Contains("?"))
            {
                m_digit=Calculation(B,R,A,1);
                
            }
            else if(B.Contains("?"))
            {
                m_digit=Calculation(A,R,B,1);
            }      
            else
            {
                m_digit=Calculation(A,B,R, 0);
            }
            return m_digit;
        }
    }
}
