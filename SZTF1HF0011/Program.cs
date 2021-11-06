using System;
using System.Collections.Generic;

namespace SZTF1HF0011
{
    class Program
    {
        /*
            Bemenet (Console)
        
            - 1. sor - a behelyettesítendő S karaktersorozat
            - 2. sor - a P program
            - 3. sor - az N értéke, vagyis a P program ismétlésének száma
            - 4. sor - a MIN értéke (inkluzív, 1-es alapú)
            - 5. sor - a MAX értéke (inkluzív, 1-es alapú)
        */
        static void Main(string[] args)
        {
            #region.test
            List<Data> DataList = new List<Data>()
            {
                new Data()
                {
                    Name = "1",
                    S = "e",
                    P = "$agl$",
                    N = 2,
                    MIN = 1,
                    MAX = 15,
                    expectedOutput = "eagleagleagle--"
                },
                new Data()
                {
                    Name = "2",
                    S = "b",
                    P = "$o$",
                    N = 10,
                    MIN = 1,
                    MAX = 3,
                    expectedOutput = "bob"
                },
                new Data()
                {
                    Name = "3",
                    S = "oenik",
                    P = "$$",
                    N = 100,
                    MIN = 1,
                    MAX = 50,
                    expectedOutput = "oenikoenikoenikoenikoenikoenikoenikoenikoenikoenik"
                },
                new Data()
                {
                    Name = "4",
                    S = "oe",
                    P = "$nik",
                    N = 10,
                    MIN = 10,
                    MAX = 40,
                    expectedOutput = "iknikniknikniknikniknik--------"
                },
                new Data()
                {
                    Name = "5",
                    S = "nik",
                    P = "oe$",
                    N = 10,
                    MIN = 150,
                    MAX = 175,
                    expectedOutput = "--------------------------"
                },
                new Data()
                {
                    Name = "6",
                    S = "x",
                    P = "$a$b$c$",
                    N = 99999999,
                    MIN = 33,
                    MAX = 65,
                    expectedOutput = "xaxbxcxaxaxbxcxbxaxbxcxcxaxbxcxbx"
                },
                new Data() 
                {
                    Name = "7",
                    S = "a",
                    P = "$",
                    N = 1,
                    MIN = 1,
                    MAX = 1,
                    expectedOutput = "a"
                },
                new Data()
                {
                    Name = "8",
                    S = "0",
                    P = "1",
                    N = 1000000000,
                    MIN = 10000,
                    MAX = 10009,
                    expectedOutput = "----------"
                },
                new Data()
                {
                    Name = "9",
                    S = "0",
                    P = "$1$",
                    N = 576,
                    MIN = 1,
                    MAX = 10,
                    expectedOutput = "0101010101"
                }
            };

            //expected output: eagleagleagle--


            #endregion
            int counter = 0;
            foreach (Data input in DataList)
            {
                Console.Write($"\nReal {input.Name} output: ");
                ReplaceRecursive(input, ref counter);
                Console.Write($"\nExp. {input.Name} output: ");
                Console.Write(input.expectedOutput);
                counter = 0;
            }
            

            ;
        }
        static void ReplaceRecursive(Data input, ref int counter)
        {
            if (counter != input.N)            
            {
                counter++;
                string addition = "";
                if (!input.P.Contains('$'))
                {
                    ToConsole(input);
                    return;
                }
                foreach (char character in input.P)
                {
                    if (character != '$')
                    {
                        addition += character;
                    }
                    else
                    {
                        addition += input.S;
                    }
                }

                input.Output = addition;
                input.S = input.Output;

                if (input.S.Length >= input.MAX)
                {
                    ToConsole(input);
                }
                else
                {
                    ReplaceRecursive(input, ref counter);
                }
                

                
            }
            else
            {
                ToConsole(input);
            }

        }
        static void ToConsole(Data input)
        {
            string toConsole = "";
            for (int i = input.MIN - 1; i < input.MAX; i++)
            {
                if (i < input.Output.Length)
                {
                    toConsole += input.Output[i];
                }
                else
                {
                    toConsole += '-';
                }
            }
            Console.Write(toConsole);
        }
        
    }
    class Data
    {
        public string S { get; set; }
        public string P { get; set; }
        public int N { get; set; }
        public int MIN { get; set; }
        public int MAX { get; set; }
        public string Output { get; set; }
        public string expectedOutput { get; set; }
        public string Name { get; set; }
        public Data()
        {
            Output = " ";
        }
    }
}
