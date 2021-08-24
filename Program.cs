using System;
using System.Linq;
namespace Project
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|                DSS Project using C# - 2020/2021               |");
            Console.WriteLine("|                                                               |");
            Console.WriteLine("|                      Badr Mohamed Kharoup                     |");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine("Press \"Enter\" to start the program");
            Console.ReadKey();

            //Getting values from the user for the payoffs
            Console.WriteLine();
            float[,] array = new float[3, 3];
            Console.WriteLine("*Decision values for x1*");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter D{0} for x1: ", i + 1);
                array[0, i] = float.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("*Decision values for x2*");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter D{0} for x2: ", i + 1);
                array[1, i] = float.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("*Decision values for x3*");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter D{0} for x3: ", i + 1);
                array[2, i] = float.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("The payoff table you've chosen is: ");
            Console.WriteLine();
            Console.WriteLine("\tD1 \tD2 \tD3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("x{0}\t", i + 1);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }

            //Asking whether the chosen values are valid
            Console.WriteLine();
            Console.WriteLine("Is this the payoff table you want? (Y/N)");
            Console.Write("Your answer: ");
            string answer = Console.ReadLine().ToLower();


            switch (answer)
            {
                case "yes":
                case "y":
                    Console.WriteLine();
                    Console.WriteLine("*****Let's go to the next step*****");
                    break;

                case "no":
                case "n":
                    Console.WriteLine();
                    Console.WriteLine("*****Let's enter the values again*****");
                    Console.WriteLine();
                    Steps();
                    break;

                default:
                    Console.WriteLine(">>>Invalid Input.");
                    Answers();
                    break;
            }

            //Asking if the decision alternatives are with or without probabilities
            string Case = "";
            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose the case of decision alternatives: (1/2)");
                Console.WriteLine("1-With probabilities (Risk)\n2-Without probabilities (Uncertainty)");
                Console.Write("Your answer: ");
                string c = Console.ReadLine();
                Case = c;
            } while (Case != "1" && Case != "2");

            switch (Case)
            {
                case "1": //Case 1 is executed in case of probabilities
                    Console.WriteLine();
                    Console.WriteLine("*****Decision alternatives with probabilities*****");
                    Console.WriteLine();

                    //Getting every decision probability from the user.
                    Console.Write("Enter probability for D1: ");
                    float p1 = float.Parse(Console.ReadLine());
                    
                    Console.Write("Enter probability for D2: ");
                    float p2 = float.Parse(Console.ReadLine());
                    
                    Console.Write("Enter probability for D3: ");
                    float p3 = float.Parse(Console.ReadLine());
                    
                    Console.WriteLine();
                    Console.WriteLine("The payoff table with probabilities:");
                    Console.WriteLine();
                    Console.WriteLine("\tD1={0}\tD2={1}\tD3={2}",p1, p2, p3);
                    for (int i = 0; i < 3; i++)
                    {
                        Console.Write("x{0}\t", i + 1);
                        for (int j = 0; j < 3; j++)
                        {
                            Console.Write(array[i, j] + "\t");
                        }
                        Console.WriteLine();
                    }

                    string _method = "";
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Which method do you want to choose? (1/2)");
                        Console.WriteLine("1-Revenue       2-Cost");
                        Console.Write("Write the corresponding number: ");
                        string Method = Console.ReadLine();
                        _method = Method;
                    } while (_method != "1" && _method != "2");


                    Console.WriteLine();
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("Calculating the EVUR \'Expected Value Under Risk\'");
                    Console.WriteLine("-------------------------------------------------");

                    float[] prob_arr = new float[3] { p1, p2, p3 };
                    float[] x1_arr = new float[3] { array[0, 0], array[0, 1], array[0, 2] };
                    float[] x2_arr = new float[3] { array[1, 0], array[1, 1], array[1, 2] };
                    float[] x3_arr = new float[3] { array[2, 0], array[2, 1], array[2, 2] };

                    float x1_prob = p1 * x1_arr[0] + p2 * x1_arr[1] + p3 * x1_arr[2];
                    float x2_prob = p1 * x2_arr[0] + p2 * x2_arr[1] + p3 * x2_arr[2];
                    float x3_prob = p1 * x3_arr[0] + p2 * x3_arr[1] + p3 * x3_arr[2];
                    float[] xprob_max = new float[3] { x1_prob, x2_prob, x3_prob };

                    Console.WriteLine("Expected Value for x1= {0}*{1} + {2}*{3} + {4}*{5} = {6}",p1, x1_arr[0], p2, x1_arr[1], p3, x1_arr[2], x1_prob);

                    Console.WriteLine("Expected Value for x2= {0}*{1} + {2}*{3} + {4}*{5} = {6}",p1, x2_arr[0], p2, x2_arr[1], p3, x2_arr[2], x2_prob);

                    Console.WriteLine("Expected Value for x3= {0}*{1} + {2}*{3} + {4}*{5} = {6}", p1, x3_arr[0], p2, x3_arr[1], p3, x3_arr[2], x3_prob);
                    
                    
                    float EVUR_Max = xprob_max.Max();
                    float EVUR_Min = xprob_max.Min();


                    if (_method == "1") //The expected value under risk in case of revenue
                    {
                        Console.WriteLine("EVUR = " + EVUR_Max);
                    }

                    else //The expected value under risk in case of cost
                    {
                        Console.WriteLine("EVUR = " + EVUR_Min);
                    }

                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Calculating the EVUC \'Expected Value Under Certainty\'");
                    Console.WriteLine("----------------------------------------------------------------");

                    float[] d1_arr = new float[3] { array[0, 0], array[1, 0], array[2, 0] };
                    float[] d2_arr = new float[3] { array[0, 1], array[1, 1], array[2, 1] };
                    float[] d3_arr = new float[3] { array[0, 2], array[1, 2], array[2, 2] };

                    float EVUC = 0;
                    if (_method == "1")
                    { EVUC = p1 * d1_arr.Max() + p2 * d2_arr.Max() + p3 * d3_arr.Max(); }
                    
                    if(_method == "2")
                    { EVUC = p1 * d1_arr.Min() + p2 * d2_arr.Min() + p3 * d3_arr.Min(); }

                    Console.WriteLine("EVUC = {0}*{1} + {2}*{3} + {4}*{5} = {6}", p1, d1_arr.Max(), p2, d2_arr.Max(), p3, d3_arr.Max(), EVUC);

                    Console.WriteLine();
                    Console.WriteLine("----------------------------------------------------------------");
                    Console.WriteLine("Calculating the EVPI \'Expected Value for Perfect Information\'");
                    Console.WriteLine("----------------------------------------------------------------");

                    Console.WriteLine("EVPI = |EVUC - EVUR|");

                    if (_method == "1") //The expected value for perfect information in case of revenue
                    {
                        Console.WriteLine("EVPI = {0} - {1} = {2}", EVUC, EVUR_Max, Math.Abs(EVUC - EVUR_Max));
                    }
                    
                    if (_method == "2") //The expected value for perfect information in case of cost
                    {
                        Console.WriteLine("EVPI = {0} - {1} = {2}", EVUC, EVUR_Min, Math.Abs(EVUC - EVUR_Min));
                    }
                    break;


                case "2": //Case 2 will be executed in case of no probabilities 
                    Console.WriteLine();
                    Console.WriteLine("*****Decision alternatives without probabilities*****");

                    string method = "";
                    do
                    {
                        Console.WriteLine();
                        Console.WriteLine("Which method do you want to choose? (1/2)");
                        Console.WriteLine("1-Revenue       2-Cost");
                        Console.Write("Write the corresponding number: ");
                        string Method = Console.ReadLine();
                        method = Method;
                    } while (method != "1" && method != "2");


                    //Applying the payoff table in the case of reveune
                    if (method == "1")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Write the approach corresponding number: (1/2/3)");
                        Console.WriteLine("1-Optimistic \t 2-Pessimistic \t 3-Regret");
                        Console.Write("Your answer: ");

                        string approach = Console.ReadLine();

                        float[] x1_array = new float[3] { array[0, 0], array[0, 1], array[0, 2] };
                        float[] x2_array = new float[3] { array[1, 0], array[1, 1], array[1, 2] };
                        float[] x3_array = new float[3] { array[2, 0], array[2, 1], array[2, 2] };

                        while (approach != "1" && approach != "2" && approach != "3")
                        {
                            Console.WriteLine(">>>Invalid Value.");
                            Console.WriteLine();
                            Console.WriteLine("Write the approach corresponding number: (1/2/3)");
                            Console.WriteLine("1-Optimistic \t 2-Pessimistic \t 3-Regret");
                            Console.Write("Your answer: ");
                            approach = Console.ReadLine();
                        }

                        switch (approach)
                        {
                            case "1": //Applying the payoff table in case of optimistic
                                Console.WriteLine("You chose the \"optimistic\" approach.");
                                Console.WriteLine();
                                Console.WriteLine("*****Let's go to the calculations*****");
                                Console.WriteLine();

                                Console.WriteLine("\tD1 \tD2 \tD3 \tMaximax");
                                float[] maxs = new float[3];
                                Console.Write("x1\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[0, j] + "\t");
                                    }
                                    Console.Write(x1_array.Max());
                                    maxs[0] = x1_array.Max();
                                    Console.WriteLine();
                                }

                                Console.Write("x2\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[1, j] + "\t");
                                    }
                                    Console.Write(x2_array.Max());
                                    maxs[1] = x2_array.Max();
                                    Console.WriteLine();
                                }

                                Console.Write("x3\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[2, j] + "\t");
                                    }
                                    Console.Write(x3_array.Max());
                                    maxs[2] = x3_array.Max();
                                    Console.WriteLine();
                                }

                                Console.WriteLine("The best alternative according to the optimistic approach is: {0}", Math.Abs(maxs.Max()));
                                break;

                            case "2": //Applying the payoff table in case of pessimistic
                                Console.WriteLine("You chose the \"pessimistic\" approach.");
                                Console.WriteLine();
                                Console.WriteLine("*****Let's go to the calculations*****");
                                Console.WriteLine();

                                Console.WriteLine("\tD1 \tD2 \tD3 \tMaximin");
                                float[] maxs2 = new float[3];
                                Console.Write("x1\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[0, j] + "\t");
                                    }
                                    Console.Write(x1_array.Min());
                                    maxs2[0] = x1_array.Min();
                                    Console.WriteLine();
                                }

                                Console.Write("x2\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[1, j] + "\t");
                                    }
                                    Console.Write(x2_array.Min());
                                    maxs2[1] = x2_array.Min();
                                    Console.WriteLine();
                                }

                                Console.Write("x3\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[2, j] + "\t");
                                    }
                                    Console.Write(x3_array.Min());
                                    maxs2[2] = x3_array.Min();
                                    Console.WriteLine();
                                }

                                Console.WriteLine("The best alternative according to the pessimistic approach is: {0}", Math.Abs(maxs2.Max()));
                                break;

                            case "3": //Applying the payoff table in case of regret
                                Console.WriteLine("You chose the \"regret\" approach.");
                                Console.WriteLine();
                                Console.WriteLine("*****Let's go tho the calculations*****");
                                Console.WriteLine();

                                Console.WriteLine("The Max of each column:");
                                float[] d1_col = new float[3] { array[0, 0], array[1, 0], array[2, 0] };
                                float[] d2_col = new float[3] { array[0, 1], array[1, 1], array[2, 1] };
                                float[] d3_col = new float[3] { array[0, 2], array[1, 2], array[2, 2] };

                                Console.WriteLine("\tD1 \tD2 \tD3");
                                Console.Write("x1\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[0, j] + "\t");
                                    }
                                    Console.WriteLine();
                                }

                                Console.Write("x2\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[1, j] + "\t");
                                    }
                                    Console.WriteLine();
                                }

                                Console.Write("x3\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[2, j] + "\t");
                                    }
                                    Console.WriteLine();
                                }

                                Console.WriteLine("---------------------------------");
                                Console.Write("Max\t");
                                for (int e = 0; e < 1; e++)
                                {
                                    for (int i = 0; i < 1; i++)
                                    {
                                        for (int j = 0; j < 1; j++)
                                        {
                                            Console.Write(d1_col.Max() + "\t");
                                        }
                                        Console.Write(d2_col.Max() + "\t");
                                    }
                                    Console.WriteLine(d3_col.Max());
                                    Console.WriteLine();
                                }



                                float[] d_maxs = new float[3] { d1_col.Max(), d2_col.Max(), d3_col.Max() };
                                Console.WriteLine();
                                Console.WriteLine("The subtraction table: ");
                                Console.WriteLine("------------------------------------------------------");
                                Console.Write("x1\t");
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write("({0})-({1})\t", d_maxs[i], x1_array[i]);
                                }
                                Console.WriteLine();

                                Console.Write("x2\t");
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write("({0})-({1})\t", d_maxs[i], x2_array[i]);
                                }
                                Console.WriteLine();

                                Console.Write("x3\t");
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write("({0})-({1})\t", d_maxs[i], x3_array[i]);
                                }
                                Console.WriteLine();
                                Console.WriteLine("------------------------------------------------------");
                                Console.WriteLine("\n");
                                Console.WriteLine("------------------------------------------------------");
                                Console.WriteLine("\tD1\tD2\tD3\tMinimax");
                                Console.Write("x1\t");

                                float[] new_x1 = new float[3];
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write(d_maxs[i] - x1_array[i] + "\t");
                                    new_x1[i] = d_maxs[i] - x1_array[i];
                                }
                                Console.Write(new_x1.Max());
                                Console.WriteLine();

                                float[] new_x2 = new float[3];
                                Console.Write("x2\t");
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write(d_maxs[i] - x2_array[i] + "\t");
                                    new_x2[i] = d_maxs[i] - x2_array[i];
                                }
                                Console.Write(new_x2.Max());
                                Console.WriteLine();

                                float[] new_x3 = new float[3];
                                Console.Write("x3\t");
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write(d_maxs[i] - x3_array[i] + "\t");
                                    new_x3[i] = d_maxs[i] - x3_array[i];
                                }
                                Console.Write(new_x3.Max());
                                Console.WriteLine();

                                float[] new_maxs = new float[3] { new_x1.Max(), new_x2.Max(), new_x3.Max() };
                                Console.WriteLine("The best alternative according to the regret (Minimax) approach is: {0}", Math.Abs(new_maxs.Min()));
                                Console.WriteLine("------------------------------------------------------");
                                break;
                        }
                    }

                    //Applying the payoff table in the case of cost
                    if (method == "2")
                    {
                        Console.WriteLine();
                        Console.WriteLine("Write the approach corresponding number: (1/2/3)");
                        Console.WriteLine("1-Optimistic \t 2-Pessimistic \t 3-Regret");
                        Console.Write("Your answer: ");

                        string approach = Console.ReadLine();

                        float[] x1_array = new float[3] { array[0, 0], array[0, 1], array[0, 2] };
                        float[] x2_array = new float[3] { array[1, 0], array[1, 1], array[1, 2] };
                        float[] x3_array = new float[3] { array[2, 0], array[2, 1], array[2, 2] };

                        while (approach != "1" && approach != "2" && approach != "3")
                        {
                            Console.WriteLine(">>>Invalid Value.");
                            Console.WriteLine();
                            Console.WriteLine("Write the approach corresponding number: (1/2/3)");
                            Console.WriteLine("1-Optimistic \t 2-Pessimistic \t 3-Regret");
                            Console.Write("Your answer: ");
                            approach = Console.ReadLine();
                        }

                        switch (approach)
                        {
                            case "1": //Applying the payoff table in case of optimistic
                                Console.WriteLine("You chose the \"optimistic\" approach.");
                                Console.WriteLine();
                                Console.WriteLine("*****Let's go tho the calculations*****");
                                Console.WriteLine();

                                Console.WriteLine("\tD1 \tD2 \tD3 \tMinimin");
                                float[] mins = new float[3];
                                Console.Write("x1\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[0, j] + "\t");
                                    }
                                    Console.Write(x1_array.Min());
                                    mins[0] = x1_array.Min();
                                    Console.WriteLine();
                                }

                                Console.Write("x2\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[1, j] + "\t");
                                    }
                                    Console.Write(x2_array.Min());
                                    mins[1] = x2_array.Min();
                                    Console.WriteLine();
                                }

                                Console.Write("x3\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[2, j] + "\t");
                                    }
                                    Console.Write(x3_array.Min());
                                    mins[2] = x3_array.Min();
                                    Console.WriteLine();
                                }

                                Console.WriteLine("The best alternative according to the optimistic approach is: {0}", Math.Abs(mins.Min()));
                                break;

                            case "2": //Applying the payoff table in case of pessimistic
                                Console.WriteLine("You chose the \"pessimistic\" approach.");
                                Console.WriteLine();
                                Console.WriteLine("*****Let's go to the calculations*****");
                                Console.WriteLine();

                                Console.WriteLine("\tD1 \tD2 \tD3 \tMinimax");
                                float[] row_max = new float[3];
                                Console.Write("x1\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[0, j] + "\t");
                                    }
                                    Console.Write(x1_array.Max());
                                    row_max[0] = x1_array.Max();
                                    Console.WriteLine();
                                }

                                Console.Write("x2\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[1, j] + "\t");
                                    }
                                    Console.Write(x2_array.Max());
                                    row_max[1] = x2_array.Max();
                                    Console.WriteLine();
                                }

                                Console.Write("x3\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[2, j] + "\t");
                                    }
                                    Console.Write(x3_array.Max());
                                    row_max[2] = x3_array.Max();
                                    Console.WriteLine();
                                }

                                Console.WriteLine("The best alternative according to the pessimistic approach is: {0}", Math.Abs(row_max.Min()));
                                break;

                            case "3": //Applying the payoff table in case of regret
                                Console.WriteLine("You chose the \"regret\" approach.");
                                Console.WriteLine();
                                Console.WriteLine("*****Let's go to the calculations*****");
                                Console.WriteLine();

                                Console.WriteLine("The Max of each column:");
                                float[] d1_col = new float[3] { array[0, 0], array[1, 0], array[2, 0] };
                                float[] d2_col = new float[3] { array[0, 1], array[1, 1], array[2, 1] };
                                float[] d3_col = new float[3] { array[0, 2], array[1, 2], array[2, 2] };

                                Console.WriteLine("\tD1 \tD2 \tD3");
                                Console.Write("x1\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[0, j] + "\t");
                                    }
                                    Console.WriteLine();
                                }

                                Console.Write("x2\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[1, j] + "\t");
                                    }
                                    Console.WriteLine();
                                }

                                Console.Write("x3\t");
                                for (int i = 0; i < 1; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Console.Write(array[2, j] + "\t");
                                    }
                                    Console.WriteLine();
                                }

                                Console.WriteLine("---------------------------------");
                                Console.Write("Max\t");
                                for (int e = 0; e < 1; e++)
                                {
                                    for (int i = 0; i < 1; i++)
                                    {
                                        for (int j = 0; j < 1; j++)
                                        {
                                            Console.Write(d1_col.Min() + "\t");
                                        }
                                        Console.Write(d2_col.Min() + "\t");
                                    }
                                    Console.WriteLine(d3_col.Min());
                                    Console.WriteLine();
                                }



                                float[] d_mins = new float[3] { d1_col.Min(), d2_col.Min(), d3_col.Min() };
                                Console.WriteLine();
                                Console.WriteLine("The subtraction table: ");
                                Console.WriteLine("------------------------------------------------------");
                                Console.Write("x1\t");
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write("({0})-({1})\t", d_mins[i], x1_array[i]);
                                }
                                Console.WriteLine();

                                Console.Write("x2\t");
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write("({0})-({1})\t", d_mins[i], x2_array[i]);
                                }
                                Console.WriteLine();

                                Console.Write("x3\t");
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write("({0})-({1})\t", d_mins[i], x3_array[i]);
                                }
                                Console.WriteLine();
                                Console.WriteLine("------------------------------------------------------");
                                Console.WriteLine("\n");
                                Console.WriteLine("------------------------------------------------------");
                                Console.WriteLine("\tD1\tD2\tD3\tMinimax");
                                Console.Write("x1\t");

                                float[] new_x1 = new float[3];
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write(Math.Abs(d_mins[i] - x1_array[i]) + "\t");
                                    new_x1[i] = Math.Abs(d_mins[i] - x1_array[i]);
                                }
                                Console.Write(new_x1.Max());
                                Console.WriteLine();

                                float[] new_x2 = new float[3];
                                Console.Write("x2\t");
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write(Math.Abs(d_mins[i] - x2_array[i]) + "\t");
                                    new_x2[i] = Math.Abs(d_mins[i] - x2_array[i]);
                                }
                                Console.Write(new_x2.Max());
                                Console.WriteLine();

                                float[] new_x3 = new float[3];
                                Console.Write("x3\t");
                                for (int i = 0; i < 3; i++)
                                {
                                    Console.Write(Math.Abs(d_mins[i] - x3_array[i]) + "\t");
                                    new_x3[i] = Math.Abs(d_mins[i] - x3_array[i]);
                                }
                                Console.Write(new_x3.Max());
                                Console.WriteLine();

                                float[] new_maxs = new float[3] { new_x1.Max(), new_x2.Max(), new_x3.Max() };
                                Console.WriteLine("The best alternative according to the regret (Minimax) approach is: {0}", Math.Abs(new_maxs.Min()));
                                Console.WriteLine("------------------------------------------------------");
                                break;
                        }
                    }
                    break;
            }

            //Asking the user whether they want to restart the program or not
            Console.WriteLine();
            Console.WriteLine("Do you want to restart the program? (Y/N)");
            Console.Write("Your answer: ");
            string restart = Console.ReadLine().ToLower();
            switch (restart)
            {
                case "yes":
                case "y":
                    Console.WriteLine("******************* Restarting the program *******************");
                    Main();
                    break;

                case "no":
                case "n":
                    Console.WriteLine("************************ Program closed ************************");
                    break;

                default:
                    Console.WriteLine(">>>Invalid Input.");
                    Restart();
                    break;
            }
        }
        //Below are some methods (functions) help execute the program properly
        static void Steps()
        {
            float[,] array = new float[3, 3];
            Console.WriteLine("*Decision values for x1*");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter D{0} for x1: ", i + 1);
                array[0, i] = float.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("*Decision values for x2*");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter D{0} for x2: ", i + 1);
                array[1, i] = float.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("*Decision values for x3*");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter D{0} for x3: ", i + 1);
                array[2, i] = float.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("The payoff table you've chosen is: ");
            Console.WriteLine();
            Console.WriteLine("\tD1 \tD2 \tD3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("x{0}\t", i + 1);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Answers();
        }
        static void Answers()
        {
            Console.WriteLine();
            Console.WriteLine("Is this the payoff table you want? (Y/N)");
            Console.Write("Your answer: ");
            string answer = Console.ReadLine().ToLower();

            switch (answer)
            {
                case "yes":
                case "y":
                    Console.WriteLine();
                    Console.WriteLine("*****Let's go to the next step*****");
                    break;

                case "no":
                case "n":
                    Console.WriteLine();
                    Console.WriteLine("*****Let's try the steps again*****");
                    NewMain();
                    break;

                default:
                    Console.WriteLine(">>>Invalid Input.");
                    Console.WriteLine("[NOTE]Please, write \"Y\" or \"N\"");
                    Answers();
                    break;
            }
        }
        static void Restart()
        {
            Console.WriteLine();
            Console.WriteLine("Do you want to restart the program? (Y/N)");
            Console.Write("Your answer: ");
            string restart = Console.ReadLine().ToLower();
            switch (restart)
            {
                case "yes":
                case "y":
                    Console.WriteLine("******************* Restarting the program *******************");
                    Main();
                    break;

                case "no":
                case "n":
                    Console.WriteLine("******************* Program closed *******************");
                    break;

                default:
                    Console.WriteLine(">>>Invalid Input.");
                    Restart();
                    break;
            }
        }
        static void NewMain()
        {
            Console.WriteLine();

            float[,] array = new float[3, 3];
            Console.WriteLine("*Decision values for x1*");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter D{0} for x1: ", i + 1);
                array[0, i] = float.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("*Decision values for x2*");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter D{0} for x2: ", i + 1);
                array[1, i] = float.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("*Decision values for x3*");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("Enter D{0} for x3: ", i + 1);
                array[2, i] = float.Parse(Console.ReadLine());
            }

            Console.WriteLine();
            Console.WriteLine("The payoff table you've chosen is: ");
            Console.WriteLine();
            Console.WriteLine("\tD1 \tD2 \tD3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("x{0}\t", i + 1);
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
            Answers();
        }
    }
}