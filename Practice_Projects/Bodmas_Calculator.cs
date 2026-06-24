using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Practice_Projects
{
    class Bodmas_Calculator
    {
        public static string FormatEquation(string input)
        {
            string FormatEquation = " 7 ( 9 )";
            input = input.Replace(" ", "");

            string result = "";
            for (int i = 0; i < input.Length; i++)
            {
                char Current = input[i];
                result += Current;

                if (i < input.Length - 1)
                {
                    char Next = input[i + 1];

                    if (char.IsDigit(Current) && Next == '(')
                    {
                        result += "*";
                    }
                }
            }
            //Console.WriteLine(result);
            return result;
        }
        public static int SignPower(char Sign)
        {
            if (Sign == '+' || Sign == '-') return 1;
            if (Sign == '*' || Sign == '/') return 2;
            return 0;
        }

        public static double Calculate(double a, double b, char Sign)
        {
            if (Sign == '+') return a + b;
            if (Sign == '-') return a - b;
            if (Sign == '*') return a * b;
            if (Sign == '/') return a / b;

            return 0;
        }

        public static double Evaluate(string input)
        {
            //string FormatEquation = " 7 ( 9 )";
            // string Equation = " 7 ( 9 )*7-9";

            input = FormatEquation(input);

            if (input.StartsWith("(") && input.EndsWith(")"))
            {
                string innerEquation = input.Substring(1, input.Length - 2);

                return Evaluate(innerEquation);
            }
            Console.WriteLine("Input : " + input);

            int bracketDepth = 0;
            int splitIndex = -1;
            int minPower = 10;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                if (input[i] == ')') bracketDepth++;
                if (input[i] == '(') bracketDepth--;

                if (bracketDepth == 0)
                {
                    int CurrentSign = SignPower(input[i]);
                    //Console.WriteLine("CurrentSign : " + CurrentSign);

                    if (CurrentSign > 0 && CurrentSign < minPower)
                    {
                        minPower = CurrentSign;
                        splitIndex = i;
                    }
                }
            }
            //Console.WriteLine("After For Loop : "+input);

            if (splitIndex != -1)
            {
                string LeftPart = input.Substring(0, splitIndex);
                string RightPart = input.Substring(splitIndex + 1);
                char Sign = input[splitIndex];

                Console.WriteLine("Left Part : " + LeftPart);
                Console.WriteLine("Right Part : " + RightPart);
                Console.WriteLine("Sign After Split : " + Sign);

                double RightAnswer = Evaluate(RightPart);
                double LeftAnswer = Evaluate(LeftPart);

                Console.WriteLine("Right Answer : " + RightAnswer);
                Console.WriteLine("Left Answer : " + LeftAnswer);
                Console.WriteLine("Sign : "+ Sign);

                Console.WriteLine(Calculate(LeftAnswer, RightAnswer, Sign));
                return Calculate(LeftAnswer, RightAnswer, Sign);
            }

            return double.Parse(input);
        }



        public static void Main(string[] args)
        {
            string Equation = "4+100-50/2*6+5+100-2";
            double result = Evaluate(Equation);
            Console.WriteLine($"The Final Answer of {Equation} is : {result}");
        }
    }
}
