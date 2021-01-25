using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack
{
    class Game : AbstractGame
    {
        private int[] _deck = new int[36] { 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 11, 11, 11, 11 };
        private int _stepCounter = 0;
        private User player, computer;

        public Game()
        {
            player = new Player();
            computer = new Computer();

            player.UserName = "Player";

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
                player.Missed = (request == "Y" || request == "y") ? false : true;

                /* if you missed and computer has more score then you, computer is winner */
                if (computer.UserScore > player.UserScore && player.Missed)
                {
                    break;
                }

                ToGo(player);
                ToGo(computer);

                /* if computer missed and player has more score then computer, player is winner */
                if (computer.UserScore < player.UserScore && computer.Missed)
                {
                    break;
                }

                if ((player.UserScore >= 21 || computer.UserScore >= 21) || (computer.UserScore >= 15 && player.Missed))
                {
                    continuee = false;
                    break;
                }

                ShowLog("Current score: " + player.UserScore + ":" + computer.UserScore);

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
            if ((player.UserScore > computer.UserScore && player.UserScore < 22 && player.UserScore != 0) ||
                (player.UserScore < 22 && player.UserScore != 0 && computer.UserScore > 22 && computer.UserScore != 0))
            {
                ShowLog("The winner is " + player.UserName);
            }
            else if (computer.UserScore < 22 && computer.UserScore != 0 && computer.UserScore != player.UserScore)
            {
                ShowLog("The winner is " + computer.UserName);
            }
            else
            {
                ShowLog("The winner is nobody, it's fail. ");
            }
            ShowLog("score " + player.UserScore + ":" + computer.UserScore);
        }
    }
}