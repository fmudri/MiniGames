using System;
using System.Security.Cryptography;
using System.Threading;
Random random = new();

//Determines if user wants to play again
var play = true;
Console.WriteLine("Welcome to a selection of games!\nPlease select a number of game you wish to play.");

Console.WriteLine("1. Blackjack\n2. Higher or Lower\n3. Rock, Paper, Scissors\n4. Exit");

int gameChoice = Convert.ToInt32(Console.ReadLine());

switch (gameChoice)
{
    case 1:
        Console.WriteLine("\nYou have chosen Blackjack!");
        Thread.Sleep(1000);
        Blackjack();
        break;

    case 2:
        Console.WriteLine("\nYou have chosen Higher or Lower!\n");
        HigherOrLower();
        break;

    case 3:
        Console.WriteLine("\nYou have chosen Rock, Paper, Scissors!\n");
        RockPaperScissors();
        break;

    case 4:
        Console.WriteLine("\nYou have chosen to exit the program.\n");
        break;

    default:
        Console.WriteLine("\nInvalid choice, please try again.\n");
        break;
}

void RockPaperScissors()
{
    throw new NotImplementedException();
}

void HigherOrLower()
{
    throw new NotImplementedException();
}
bool ShouldPlay()
{
    string? response = Console.ReadLine();
    if (response?.ToLower() == "y")
    {
        return true;
    }
    else if (response?.ToLower() == "n")
    {
        return false;
    }
    else
    {
        Console.WriteLine("Invaild key pressed. Exiting...");
        return false;
    }
}
void Blackjack()
{
    /* RULES
     * Players are dealt two cards, and the value of the cards are added together.
     * The aim of the game is to get as close to 21 as possible without going over.
     * Players can choose to 'hit' to receive another card, or 'stand' to keep their current total.
     * Maximum number of cards a player can have is 5.
     * If a player gets 21, they win.
     * If a player gets above 21, they lose.
     * Dealer also gets two cards, and must hit if their total is less or equal to 17.
     * If the dealer goes over 21, the player wins.
     * If the dealer has a higher total than the player, the dealer wins.
     * The dealer wins in the event of a draw.
     * The dealer stands if his total is 18 or above
     * Cards have a value of their number and J, Q and K are worth 10 points each
     * Ace is worth either 1 or 11 points which is player's choice 
     * Because of simplicity, if player gets aces in first two draws, they are randomly 
     *      determined to be either 1 or 11 in value
     *      All dealers aces are randomly determined */

    while (play)
    {
        // POTENCIJALNO NAPRAVITI SVAKI HAND KAO METODU
        Console.WriteLine("Press Spacebar to draw your hand or any other key to quit");
        var firstHand = Console.ReadKey(true).Key;

        if (firstHand == ConsoleKey.Spacebar)
        {
            Console.WriteLine("\nDrawing cards...");
            Thread.Sleep(2000);

            // Total score of player and dealer
            int playerTotal;
            int dealerTotal;

            // Cards that player and dealer are holding
            int[] playerCards = new int[7];
            int[] dealerCards = new int[7];

            // PLAYER AND DEALER DRAW FIRST TWO CARDS
            // ACES ARE ONLY HERE AUTOMATICLY ASSIGNED AS 1 OR 11
            playerCards[0] = random.Next(1, 11);
            playerCards[1] = random.Next(1, 11);
            playerTotal = playerCards[0] + playerCards[1];

            dealerCards[0] = random.Next(1, 11);
            dealerCards[1] = random.Next(1, 11);
            dealerTotal = dealerCards[0] + dealerCards[1];

            // INFORMS THE PLAYER OF HIS AND DEALER'S CARDS
            Console.WriteLine($"\nYou drew {playerCards[0]} and {playerCards[1]}" +
            $"\nYour total is {playerTotal} and dealers' card is {dealerCards[0]}\n" +
            $"\nPress Spacebar to Hit, Enter to Stand or any other key if Mama raised a quitter\n");
            var secondHand = Console.ReadKey(true).Key;

            // IF PLAYER DECIDES TO HIT (DRAW THIRD CARD)
            if (secondHand == ConsoleKey.Spacebar)
            {
                playerCards[2] = random.Next(1, 11);

                // IF PLAYER HAS DRAWN AN ACE, CHECK TO SEE WHICH VALUE PLAYER WANTS
                if (playerCards[2] == 1 || playerCards[2] == 11)
                {
                    Console.WriteLine("\nYou drew an ace. Do you want it to be 1 or 11?\nPress 1 for 1 or 2 for 11");
                    if (Console.ReadKey().Key == ConsoleKey.D1)
                    {
                        Console.WriteLine("\nYou chose 1");
                        playerCards[2] = 1;
                        playerTotal += playerCards[2];
                    }
                    else if (Console.ReadKey().Key == ConsoleKey.D2)
                    {
                        Console.WriteLine("\nYou chose 11");
                        playerCards[2] = 11;
                        playerTotal += playerCards[2];
                    }
                }
                playerTotal += playerCards[2];

                Console.WriteLine($"\nYou drew {playerCards[2]} and your total is {playerTotal}");
                Console.WriteLine("Would you like to draw another card or Stand?"
                + "\nPress Enter to Stand or Space to Hit");
                var thirdHand = Console.ReadKey(true).Key;

                // IF PLAYER DECIDES TO HIT (DRAW FOURTH CARD)
                if (thirdHand == ConsoleKey.Spacebar)
                {
                    playerCards[3] = random.Next(1, 11);

                    // IF PLAYER HAS DRAWN AN ACE, CHECK TO SEE WHICH VALUE PLAYER WANTS
                    if (playerCards[3] == 1 || playerCards[3] == 11)
                    {
                        Console.WriteLine("\nYou drew an ace. Do you want it to be 1 or 11?\nPress 1 for 1 or 2 for 11");
                        if (Console.ReadKey().Key == ConsoleKey.D1)
                        {
                            Console.WriteLine("You chose 1");
                            playerCards[3] = 1;
                            playerTotal += playerCards[3];
                        }
                        if (Console.ReadKey().Key == ConsoleKey.D2)
                        {
                            Console.WriteLine("You chose 11");
                            playerCards[3] = 11;
                            playerTotal += playerCards[3];
                        }
                    }
                    playerTotal += playerCards[3];

                    Console.WriteLine($"\nYou drew {playerCards[3]} and your total is {playerTotal}");
                    Console.WriteLine("Would you like to draw another card or Stand?"
                    + "\nPress Enter to Stand or Space to Hit");
                    var fourthHand = Console.ReadKey(true).Key;

                    // IF PLAYER DECIDES TO HIT (DRAW FIFTH CARD)
                    if (fourthHand == ConsoleKey.Spacebar)
                    {
                        playerCards[4] = random.Next(1, 11);

                        // IF PLAYER HAS DRAWN AN ACE, CHECK TO SEE WHICH VALUE PLAYER WANTS
                        if (playerCards[4] == 1 || playerCards[4] == 11)
                        {
                            Console.WriteLine("\nYou drew an ace. Do you want it to be 1 or 11?\nPress 1 for 1 or 2 for 11");
                            if (Console.ReadKey().Key == ConsoleKey.D1)
                            {
                                Console.WriteLine("You chose 1");
                                playerCards[4] = 1;
                                playerTotal += playerCards[4];
                            }
                            if (Console.ReadKey().Key == ConsoleKey.D2)
                            {
                                Console.WriteLine("You chose 11");
                                playerCards[4] = 11;
                                playerTotal += playerCards[4];
                            }
                        }
                        playerTotal += playerCards[4];

                        Console.WriteLine($"\nYou drew {playerCards[4]} and your total is {playerTotal}");
                        Console.WriteLine("Would you like to draw another card or Stand?"
                        + "\nPress Enter to Stand or Space to Hit");

                        // PLAYER DECIDES TO STAND WITH FIVE CARDS
                        if (fourthHand == ConsoleKey.Enter)
                        {
                            if (dealerTotal > 21)
                            {
                                Console.WriteLine("You win!");
                            }
                            if (dealerTotal >= 18 && dealerTotal <= 21)
                            {
                                Console.WriteLine($"\nYou decided to Stand. Your total is {playerTotal}" +
                                    $"\nDealers' total is {dealerTotal}");
                                if (dealerTotal < playerTotal)
                                {
                                    Console.WriteLine("You win!");
                                }
                                else
                                {
                                    Console.WriteLine("You lose!");
                                }
                            }
                            if (dealerTotal < 18)
                            {
                                dealerCards[3] = random.Next(1, 11);
                                dealerTotal = dealerCards[0] + dealerCards[1] + dealerCards[2] + dealerCards[3];
                                Console.WriteLine($"You decided to Stand. Your total is {playerTotal}" +
                                    $"\nDealers' total is {dealerTotal}");

                                if (dealerTotal < playerTotal)
                                {
                                    Console.WriteLine("You win!");
                                }
                                else if (dealerTotal > 21)
                                {
                                    Console.WriteLine("You win!");
                                }
                                else if (dealerTotal == playerTotal)
                                {
                                    Console.WriteLine("It's a draw!");
                                }
                                else
                                {
                                    Console.WriteLine("You lose!");
                                }
                            }
                            Console.WriteLine("Play again Y/N?");
                            play = ShouldPlay();
                        }

                    }

                    // PLAYER DECIDES TO STAND WITH FOUR CARDS
                    if (thirdHand == ConsoleKey.Enter)
                    {
                        if (dealerTotal > 21)
                        {
                            Console.WriteLine("You win!");
                        }
                        if (dealerTotal >= 18 && dealerTotal <= 21)
                        {
                            Console.WriteLine($"\nYou decided to Stand. Your total is {playerTotal}" +
                                $"\nDealers' total is {dealerTotal}");
                            if (dealerTotal < playerTotal)
                            {
                                Console.WriteLine("You win!");
                            }
                            else
                            {
                                Console.WriteLine("You lose!");
                            }
                        }
                        if (dealerTotal < 18)
                        {
                            dealerCards[3] = random.Next(1, 11);
                            dealerTotal = dealerCards[0] + dealerCards[1] + dealerCards[2] + dealerCards[3];
                            Console.WriteLine($"You decided to Stand. Your total is {playerTotal}" +
                                $"\nDealers' total is {dealerTotal}");

                            if (dealerTotal < playerTotal)
                            {
                                Console.WriteLine("You win!");
                            }
                            else if (dealerTotal > 21)
                            {
                                Console.WriteLine("You win!");
                            }
                            else if (dealerTotal == playerTotal)
                            {
                                Console.WriteLine("It's a draw!");
                            }
                            else
                            {
                                Console.WriteLine("You lose!");
                            }
                        }
                        Console.WriteLine("Play again Y/N?");
                        play = ShouldPlay();
                    }
                }

                // IF PLAYER DECIDES TO STAND WITH THREE CARDS
                else if (secondHand == ConsoleKey.Enter)
                {
                    if (dealerTotal > 21)
                    {
                        Console.WriteLine("You win!");
                    }
                    if (dealerTotal >= 18 && dealerTotal <= 21)
                    {
                        Console.WriteLine($"\nYou decided to Stand. Your total is {playerTotal}" +
                            $"\nDealers' total is {dealerTotal}");
                        if (dealerTotal < playerTotal)
                        {
                            Console.WriteLine("You win!");
                        }
                        else
                        {
                            Console.WriteLine("You lose!");
                        }
                    }
                    if (dealerTotal < 18)
                    {
                        dealerCards[2] = random.Next(1, 11);
                        dealerTotal = dealerCards[0] + dealerCards[1] + dealerCards[2];
                        Console.WriteLine($"You decided to Stand. Your total is {playerTotal}" +
                            $"\nDealer drew {dealerCards[2]}. His hidden card was {dealerCards[1]}"
                            + $" and his total is {dealerTotal}");

                        if (dealerTotal < playerTotal)
                        {
                            Console.WriteLine("You win!");
                        }
                        else if (dealerTotal > 21)
                        {
                            Console.WriteLine("You win!");
                        }
                        else if (dealerTotal == playerTotal)
                        {
                            Console.WriteLine("It's a draw!");
                        }
                        else
                        {
                            Console.WriteLine("You lose!");
                        }
                    }
                    Console.WriteLine("Play again Y/N?");
                    play = ShouldPlay();
                }

                // TEMPORARY SOLUTION UNTIL I ADD EXCEPTIONS OR VALIDATION 
                else
                {
                    Console.WriteLine("Invalid key pressed. Exiting program...");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                }
            }

            // IF PLAYER DECIDES TO STAND WITH TWO CARDS
            else if (secondHand == ConsoleKey.Enter)
            {
                if (dealerTotal > 21)
                {
                    Console.WriteLine("You win!");
                }
                if (dealerTotal >= 18 && dealerTotal <= 21)
                {
                    Console.WriteLine($"\nYou decided to Stand. Your total is {playerTotal}" +
                        $"\nDealers' total is {dealerTotal}");
                    if (dealerTotal < playerTotal)
                    {
                        Console.WriteLine("You win!");
                    }
                    else
                    {
                        Console.WriteLine("You lose!");
                    }
                }
                if (dealerTotal < 18)
                {
                    dealerCards[2] = random.Next(1, 11);
                    dealerTotal = dealerCards[0] + dealerCards[1] + dealerCards[2];
                    Console.WriteLine($"You decided to Stand. Your total is {playerTotal}" +
                        $"\nDealer drew {dealerCards[2]}. His hidden card was {dealerCards[1]}"
                        + $" and his total is {dealerTotal}");

                    if (dealerTotal < playerTotal)
                    {
                        Console.WriteLine("You win!");
                    }
                    else if (dealerTotal > 21)
                    {
                        Console.WriteLine("You win!");
                    }
                    else if (dealerTotal == playerTotal)
                    {
                        Console.WriteLine("It's a draw!");
                    }
                    else
                    {
                        Console.WriteLine("You lose!");
                    }
                }
                Console.WriteLine("Play again Y/N?");
                play = ShouldPlay();
            }

        }
        // IF PLAYER DECIDES TO QUIT
        else
        {
            Console.WriteLine("Whatever...");
            Thread.Sleep(2000);
            play = false;
        }
    }
}