using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack
{
    class Game
    {
        public int _yourScore = 0;
        public int _computerScore = 0;

        private int[] _deck = new int[36] { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 11, 11, 11, 11 };
        private int _stepCounter = 0;
        private bool _playerMissed;

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
                if (_computerScore > _yourScore && _playerMissed)
                {
                    break;
                }

                ToGo("Player");
                ToGo("Computer");

                if ((_yourScore >= 21 || _computerScore >= 21) || (_computerScore >= 15 && _playerMissed))
                {
                    continuee = false;
                    break;
                }

                ShowLog("Current score: " + _yourScore + ":" + _computerScore);

            } while (continuee);
            
            Finish();
        }

        /* Custom method for show to screen logs the game */
        public void ShowLog(string value)
        {
            Console.WriteLine(value);
        }

        /* The method return weight of new card */
        private int GetCard() {
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
                    if (_computerScore >= 15)
                    {
                        ShowLog("Computer missed");
                        break;
                    }
                    if (card == 11 && _computerScore <= 10)//if it blackjack, i'll check how many score i can to count
                    {
                        _computerScore += card;
                    }
                    else if (card != 11)
                    {
                        _computerScore += card;
                    }
                    else
                    {
                        _computerScore += 1;
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
                    if (card == 11 && _yourScore <= 10)//if it blackjack, i'll check how many score i can to count
                    {
                        _yourScore += card;
                    }
                    else if (card != 11)
                    {
                        _yourScore += card;
                    }
                    else
                    {
                        _yourScore += 1;
                    }
                    ShowLog("Your card is:" + card);
                    break;
            }
        }

        /* The method make result and show to the screen */
        private void Finish()
        {
            if ((_yourScore > _computerScore && _yourScore < 22 && _yourScore != 0) ||
                (_yourScore < 22 && _yourScore != 0 && _computerScore > 22 && _computerScore != 0))
            {
                ShowLog("The winner is player ");
            }
            else if (_computerScore < 22 && _computerScore != 0 && _computerScore != _yourScore)
            {
                ShowLog("The winner is computer ");
            }
            else
            {
                ShowLog("The winner is nobody, it's fail. ");
            }
            ShowLog("score " + _yourScore + ":" + _computerScore);
        }
    }
}