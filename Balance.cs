using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;

namespace Dncdpm
{
    class Balance
    {
        static Int16 ttask = 0;
        static Int16 count = 2;
        static Int16 countServer = 0;
        static StringBuilder outputList = new StringBuilder();

        public static void Run(object sender, ElapsedEventArgs e)
        {
            try
            {
                ttask++;
                using (StreamReader inputReader = new StreamReader(AppDomain.CurrentDomain.BaseDirectory + "\\input.txt"))
                {
                    List<String> inputList = inputReader.ReadToEnd().Split('\n').ToList<String>();
                    if (inputList.Count > 2)
                    {
                        if (Convert.ToInt16(inputList[0]) <= 10 && Convert.ToInt16(inputList[0]) > 1 &&
                            Convert.ToInt16(inputList[1]) <= 10 && Convert.ToInt16(inputList[1]) > 1)
                        {
                            string output = "";
                            for (int i = 2; i < inputList.Count; i++)
                            {
                                if (count < inputList.Count)
                                {
                                    Decimal calc = Math.Ceiling((Convert.ToDecimal(inputList[count]) / Convert.ToDecimal(inputList[1])));
                                    if (calc > 1)
                                    {
                                        for (int ii = 0; ii < calc; ii++)
                                        {
                                            if (output == "")
                                            {
                                                output = Convert.ToInt16(inputList[1]).ToString();
                                                countServer++;
                                            }
                                            else
                                            {
                                                output += "," + Convert.ToInt16(inputList[1]).ToString();
                                                countServer++;
                                            }
                                        }
                                        output += "\r\n";
                                    }
                                    else
                                    {
                                        output = "1\r\n";
                                        countServer++;
                                    }
                                    outputList.Append(output);
                                    count++;
                                    break;
                                }
                            }
                            Console.WriteLine(outputList.ToString());
                        }
                        else
                        {
                            Console.WriteLine("Atenção! ttask e umax deve ser de 1 até 10.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("A lista não contém entradas de usuários.");
                    }
                }

                if (ttask == 10)
                {
                    outputList.Append(countServer.ToString());
                    GravarOutput(outputList);
                }
            }
            catch (IOException io)
            {
                Console.WriteLine("Arquivo input.txt não foi localizado.");
            }
        }

        public static void GravarOutput(StringBuilder outputList)
        {
            try
            {
                using (StreamWriter writeOutput = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\output.txt", false))
                {
                    writeOutput.Write(outputList.ToString());
                }
                Environment.Exit(-1);
            }
            catch (IOException io)
            {
                Console.WriteLine("Falha na gravação do arquivo de saida output.txt.");
            }            
        }
    }
}
