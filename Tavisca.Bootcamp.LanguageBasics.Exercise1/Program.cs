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
        public static int GetDigit(string firstNumber,string secondNumber,string resultantNumber,string flag)
        {
            int firstNumberInt=Int32.Parse(firstNumber);//convert string numbers into integer
            int secondNumberInt=Int32.Parse(secondNumber);

            if(firstNumberInt==0||secondNumberInt==0)//corner case if any of the numbers is zero
                return -1;
                
            int result=0;
            int index=0;

            if(flag=="multiply")
                result=firstNumberInt*secondNumberInt;//multiply the numbers to find RHS of given Equation
            else if(flag=="divide")
            {
                if(secondNumberInt%firstNumberInt!=0)//corner case..checks if the numbers is divisible
                    return -1;
                
                result=secondNumberInt/firstNumberInt;//divide the numbers to find LHS of given Equation
            }
            else
                Console.WriteLine("Invalid operation");

            string resultString=result.ToString();

            if(resultString.Length==resultantNumber.Length)//compare the length of calculated result and given result
            {
                index=resultantNumber.IndexOf('?');
                return resultString[index]-'0';
            }
            else
                return -1;
        }
        
        public static string[] SplitEquation(string equation)
        {
            string[] splitByStar=equation.Split("*");//split by * into array of strings
            string A=splitByStar[0];
            string[] splitByEqual=splitByStar[1].Split("=");//split the string by =
            string B=splitByEqual[0];
            string C=splitByEqual[1];

            string[] splittedEquation=new string[3];
            splittedEquation[0]=A;
            splittedEquation[1]=B;
            splittedEquation[2]=C;

            return splittedEquation;
        }
        public static int FindDigit(string equation)
        {
            int missingDigit;
            string[] splittedEquation = SplitEquation(equation);//split the given equation into three different strings
            
            string A=splittedEquation[0];
            string B=splittedEquation[1];
            string C=splittedEquation[2];

            if(A.Contains("?"))
            {
                missingDigit=GetDigit(B,C,A,"divide");
                
            }
            else if(B.Contains("?"))
            {
                missingDigit=GetDigit(A,C,B,"divide");
            }      
            else
            {
                missingDigit=GetDigit(A,B,C,"multiply");
            }
            return missingDigit;
        }
    }
}
