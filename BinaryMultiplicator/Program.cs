using System;
using System.Collections.Generic;

namespace BinaryMultiplicator
{
    public class Program
    {
        public class FunctionInfo
        {
            public Action Function;
            public string ToolTip;
        }

        public static Dictionary<ConsoleKey, FunctionInfo> Functions { get; }= new Dictionary<ConsoleKey, FunctionInfo>();

        private static void RegisterFunctions()
        {
            Functions.Add(ConsoleKey.Escape, new FunctionInfo()
            {
                Function = Help,
                ToolTip = "Help"
            });

            Functions.Add(ConsoleKey.F1, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethodMI.Singleton),
                ToolTip = "Manual Multiplication I"
            });
            Functions.Add(ConsoleKey.F2, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethodMII.Singleton),
                ToolTip = "Manual Multiplication II"
            });
            Functions.Add(ConsoleKey.F3, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethodMIII.Singleton),
                ToolTip = "Manual Multiplication III"
            });
            Functions.Add(ConsoleKey.F4, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethodMIV.Singleton),
                ToolTip = "Manual Multiplication IV"
            });
            Functions.Add(ConsoleKey.F5, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethodAI.Singleton),
                ToolTip = "Automatic Multiplication I"
            });
            Functions.Add(ConsoleKey.F6, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethodAII.Singleton),
                ToolTip = "Automatic Multiplication II"
            });
            Functions.Add(ConsoleKey.F7, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethodAIII.Singleton),
                ToolTip = "Automatic Multiplication III"
            });
            Functions.Add(ConsoleKey.F8, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethodAIV.Singleton),
                ToolTip = "Automatic Multiplication IV"
            });

            string WaitForBinary()
            {
                string str = Console.ReadLine();
                while (!Binary.ValidateBinary(str))
                {
                    str = Console.ReadLine();
                    Console.WriteLine("Input invalid.");
                }
                return str;
            }

            void CalculateBy(IMultiplicationMethod method)
            {
                Console.WriteLine("Enter a and b values.");
                string a = WaitForBinary();
                string b = WaitForBinary();

                if (a.Length != b.Length)
                {
                    Console.WriteLine("Values must have identical word length.");
                    return;
                }

                method.Calculate(a, b);
            }
        }

        private static void Help()
        {
            Console.WriteLine("This program have following functions:");
            foreach (var fi in Functions)
                Console.WriteLine($"{fi.Key} - {fi.Value.ToolTip};");
            Console.WriteLine();
        }

        private static void Main(string[] args)
        {
            RegisterFunctions();
            Help();
            while (true)
            {
                Console.WriteLine("Waiting for command.");
                FunctionInfo fi;
                while (true)
                {
                    ConsoleKeyInfo cki = Console.ReadKey();

                    Console.SetCursorPosition(0, Console.CursorTop);
                    Console.Write(' ');
                    Console.SetCursorPosition(0, Console.CursorTop);

                    if(Functions.ContainsKey(cki.Key))
                    {
                        fi = Functions[cki.Key];
                        break;
                    }
                }
                
                Console.WriteLine($"================={fi.ToolTip}=================");
                fi.Function();
                Console.WriteLine("==================================");
            }
        }
    }
}
