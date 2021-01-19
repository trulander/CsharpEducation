using System;

namespace blackjack
{
    public static class Program
    {
        static void Main(string[] args)
        {
            int[] koloda = new int[36] { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 11, 11, 11, 11 };
            int step_counter = 0;
            int your_score = 0;
            int computer_score = 0;

            string request;
            bool continuee;

            do
            {
                Console.WriteLine("Do you want to go? (Y/N)");
                request = Console.ReadLine();
                continuee = (request == "Y" || request == "y") ? true : false;


                Random random = new Random();
                for (int i = 0; i < 2; i++)
                {
                    int card_in_coloda = random.Next(0 + step_counter, 36);
                    int currentcard = koloda[card_in_coloda];
                    koloda[card_in_coloda] = 0;
                    step_counter++;
                    Array.Sort(koloda);
                    //Console.WriteLine(currentcard);

                    if(i == 0)
                    {
                        if(currentcard == 11 && your_score <= 10)//if it blackjack, i'll check how many score i can to count
                        {
                            your_score += currentcard;
                        }
                        else if (currentcard != 11)
                        {
                            your_score += currentcard;
                        }
                        else
                        {
                            your_score += 1;
                        }
                        Console.WriteLine("Your card is:" + currentcard);
                    }
                    else
                    {
                        if (currentcard == 11 && computer_score <= 10)//if it blackjack, i'll check how many score i can to count
                        {
                            computer_score += currentcard;
                        }
                        else if(currentcard != 11)
                        {
                            computer_score += currentcard;
                        }
                        else
                        {
                            computer_score += 1;
                        }
                        Console.WriteLine("Computer card is:" + currentcard);
                    }
                }

                if(your_score >= 21 || computer_score >= 21)
                {
                    break;
                }

                Console.WriteLine("Current score: " + your_score + ":" + computer_score);


            } while (continuee);

            Console.Write("The winner is ");

            if (your_score > computer_score && your_score < 22 && computer_score < 22)
            {
                Console.WriteLine("player ");
            }
            else if (your_score < 22)
            {
                Console.WriteLine("player ");
            }
            else if (computer_score < 22)
            {
                Console.WriteLine("computer ");
            }
            else
            {
                Console.WriteLine("nobody, it's fail. ");
            }
            Console.Write("score " + your_score + ":" + computer_score);
        }
        


        //public static int Getcart()
        //{
        //    Random random = new Random();
            
        //    int card_in_coloda = random.Next(0, 37 - step_counter);
        //    int currentcard = koloda[card_in_coloda];
        //    koloda[card_in_coloda] = 0;

        //    step_counter++;
        //    return currentcard;
        //}
    }
}
