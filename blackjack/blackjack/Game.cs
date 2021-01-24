using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack
{
    class Game
    {
        private int[] _deck = new int[36] { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 11, 11, 11, 11 };
        private int _stepCounter = 0;
        private bool _playerMissed;
        private bool _computerMissed = false;

        public int YourScore { get; private set; }
        public int ComputerScore { get; private set; }

        public Game()
        {
            bool continuee = true;
            string request;

            /* live cycle the game */
            do
            {
                ShowLog("Do you want to go? (Y/N)");
                request = Console.ReadLine();
                _playerMissed = (request == "Y" || request == "y") ? false : true;

                /* if you missed and computer has more score then you, computer is winner */
                if (ComputerScore > YourScore && _playerMissed)
                {
                    break;
                }

                ToGo("Player");
                ToGo("Computer");

                /* if computer missed and player has more score then computer, player is winner */
                if (ComputerScore < YourScore && _computerMissed)
                {
                    break;
                }

                if ((YourScore >= 21 || ComputerScore >= 21) || (ComputerScore >= 15 && _playerMissed))
                {
                    continuee = false;
                    break;
                }

                ShowLog("Current score: " + YourScore + ":" + ComputerScore);

            } while (continuee);
            
            Finish();
        }

        /* Custom method for show to screen logs the game */
        public static void ShowLog(string value)
        {
            Console.WriteLine(value);
        }

        /* The method return weight of new card */
        private int GetCard()
        {
            Random random = new Random();
            int cardInDeck = random.Next(0 + _stepCounter, 36);
            int currentCard = _deck[cardInDeck];
            _deck[cardInDeck] = 0;
            _stepCounter++;
            Array.Sort(_deck);
            return currentCard;
        }

        /* 
         * The method make new step of the game
         * It can to get value is Player or Computer
         */
        private void ToGo(string user) 
        {
            int card = GetCard();
            switch (user)
            {
                case "Computer":
                    if (ComputerScore >= 15)
                    {
                        _computerMissed = true;
                        ShowLog("Computer missed");
                        break;
                    }
                    if (card == 11 && ComputerScore <= 10)//if it blackjack, i'll check how many score i can to count
                    {
                        ComputerScore += card;
                    }
                    else if (card != 11)
                    {
                        ComputerScore += card;
                    }
                    else
                    {
                        ComputerScore += 1;
                    }
                    ShowLog("Computer card is:" + card);
                    break;
                case "Player":
                default:
                    if (_playerMissed)
                    {
                        ShowLog("Player missed");
                        break;
                    }
                    if (card == 11 && YourScore <= 10)//if it blackjack, i'll check how many score i can to count
                    {
                        YourScore += card;
                    }
                    else if (card != 11)
                    {
                        YourScore += card;
                    }
                    else
                    {
                        YourScore += 1;
                    }
                    ShowLog("Your card is:" + card);
                    break;
            }
        }

        /* The method make result and show to the screen */
        private void Finish()
        {
            if ((YourScore > ComputerScore && YourScore < 22 && YourScore != 0) ||
                (YourScore < 22 && YourScore != 0 && ComputerScore > 22 && ComputerScore != 0))
            {
                ShowLog("The winner is player ");
            }
            else if (ComputerScore < 22 && ComputerScore != 0 && ComputerScore != YourScore)
            {
                ShowLog("The winner is computer ");
            }
            else
            {
                ShowLog("The winner is nobody, it's fail. ");
            }
            ShowLog("score " + YourScore + ":" + ComputerScore);
        }
    }
}