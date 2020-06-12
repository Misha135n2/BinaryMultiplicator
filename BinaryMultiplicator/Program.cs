using System;
using System.Collections.Generic;

namespace BinaryMultiplicator
{
    public class Program
    {
#if AUTOTEST
        // 152*237
        private static readonly string[] _test = new[]
        {
            "010011000", "011101101", // pp
            "010011000", "100010011", // pn
            "101101000", "011101101", // np
            "101101000", "100010011"  // nn
        };
        // +r 001000110 010111000
        // -r 110111001 101001000
#endif

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
            Functions.Add(ConsoleKey.Q, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethod2xI.Singleton),
                ToolTip = "2x Multiplication I"
            });
            Functions.Add(ConsoleKey.W, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethod2xII.Singleton),
                ToolTip = "2x Multiplication II"
            });
            Functions.Add(ConsoleKey.E, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethod2xIII.Singleton),
                ToolTip = "2x Multiplication III"
            });
            Functions.Add(ConsoleKey.R, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethod2xIV.Singleton),
                ToolTip = "2x Multiplication IV"
            });
            Functions.Add(ConsoleKey.T, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethod3xI.Singleton),
                ToolTip = "3x Multiplication I"
            });
            Functions.Add(ConsoleKey.Y, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethod3xII.Singleton),
                ToolTip = "3x Multiplication II"
            });
            Functions.Add(ConsoleKey.U, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethod3xIII.Singleton),
                ToolTip = "3x Multiplication III"
            });
            Functions.Add(ConsoleKey.I, new FunctionInfo()
            {
                Function = () => CalculateBy(MultiplicationMethod3xIV.Singleton),
                ToolTip = "3x Multiplication IV"
            });

            Functions.Add(ConsoleKey.A, new FunctionInfo()
            {
                Function = () => { DivideBy(DivisionMethodDCRI.Singleton); },
                ToolTip = "Division with Restoration I (Direct Code)"
            });

            Functions.Add(ConsoleKey.D, new FunctionInfo()
            {
                Function = () => { DivideBy(DivisionMethodNRI.Singleton); },
                ToolTip = "Division No Restoration I"
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

            void DivideBy(IDivisionMethod method)
            {
                string a = WaitForBinary();
                string b = WaitForBinary();

                method.Divide(a, b);
            }
            void CalculateBy(IMultiplicationMethod method)
            {
#if AUTOTEST
                for (int i = 0; i < _test.Length; i += 2)
                    method.Calculate(_test[i], _test[i + 1]);
#else
                Console.WriteLine("Enter a and b values.");
                string a = WaitForBinary();
                string b = WaitForBinary();
                if (a.Length != b.Length)
                {
                    Console.WriteLine("Values must have identical word length.");
                    return;
                }

                method.Calculate(a, b);
#endif
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
 #if AUTOTEST
            ConsoleKey[] keys =
            {
                //ConsoleKey.F5,
                //ConsoleKey.Q,
                //ConsoleKey.T,

                ConsoleKey.F6,
                ConsoleKey.W,
                ConsoleKey.Y,
                
                //ConsoleKey.F7,
                //ConsoleKey.E,
                //ConsoleKey.U,

                //ConsoleKey.F8,
                //ConsoleKey.R,
                //ConsoleKey.I,
            };

            foreach (var k in keys)
            {
                var fi = Functions[k];
                Console.WriteLine($"================={fi.ToolTip}=================");
                fi.Function();
                Console.WriteLine("==================================");
            }
            
            Console.ReadKey();
#else
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
#endif
        }
    }
}
