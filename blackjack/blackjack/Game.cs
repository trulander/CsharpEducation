using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack
{
    class Game : AbstractGame
    {
        private int[] _deck = new int[36] { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 11, 11, 11, 11 };
        private int _stepCounter = 0;
        private User _player, _computer;

        public Game()
        {
            _player = new Player();
            _computer = new Computer();

            _player.UserName = "Player";

            Start();
        }

        protected override void Start()
        {
            bool continuee = true;
            string request;

            /* live cycle the game */
            do
            {
                ShowLog("Do you want to go? (Y/N)");
                request = Console.ReadLine();
                _player.Missed = (request == "Y" || request == "y") ? false : true;

                /* if you missed and computer has more score then you, computer is winner */
                if (_computer.UserScore > _player.UserScore && _player.Missed)
                {
                    break;
                }

                ToGo(_player);
                ToGo(_computer);

                /* if computer missed and player has more score then computer, player is winner */
                if (_computer.UserScore < _player.UserScore && _computer.Missed)
                {
                    break;
                }

                if ((_player.UserScore >= 21 || _computer.UserScore >= 21) || (_computer.UserScore >= 15 && _player.Missed))
                {
                    continuee = false;
                    break;
                }

                ShowLog("Current score: " + _player.UserScore + ":" + _computer.UserScore);

            } while (continuee);

            Finish();
        }

        /* The method return weight of new card */
        protected override int GetCard()
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
        protected override void ToGo(User user)
        {
            if ((user.UserScore >= 15 && user.Type == "AI") || user.Missed)
            {
                user.Missed = true;
                ShowLog(user.UserName + " missed");
            }
            else
            {
                int card = GetCard();
                /* if it blackjack, i'll check how many score i can to count */
                if (card == 11 && user.UserScore <= 10)
                {
                    user.UserScore += card;
                }
                else if (card != 11)
                {
                    user.UserScore += card;
                }
                else
                {
                    user.UserScore += 1;
                }
                ShowLog(user.UserName + " card is:" + card);
            }
        }

        /* The method make result and show to the screen */
        protected override void Finish()
        {
            if ((_player.UserScore > _computer.UserScore && _player.UserScore < 22 && _player.UserScore != 0) ||
                (_player.UserScore < 22 && _player.UserScore != 0 && _computer.UserScore > 22 && _computer.UserScore != 0))
            {
                ShowLog("The winner is " + _player.UserName);
            }
            else if (_computer.UserScore < 22 && _computer.UserScore != 0 && _computer.UserScore != _player.UserScore)
            {
                ShowLog("The winner is " + _computer.UserName);
            }
            else
            {
                ShowLog("The winner is nobody, it's fail. ");
            }
            ShowLog("score " + _player.UserScore + ":" + _computer.UserScore);
        }
    }
}