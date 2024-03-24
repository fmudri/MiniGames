using System;
using System.Security.Cryptography;

Random random = new Random();

bool hasWon = false;

Console.WriteLine("Welcome to a selection of games!\nPlease select a number of game you wish to play.");

Console.WriteLine("1. Blackjack\n2. Higher or Lower\n3. Rock, Paper, Scissors\n4. Exit");

int gameChoice = Convert.ToInt32(Console.ReadLine());

switch (gameChoice)
{
    case 1:
        Console.WriteLine("You have chosen Blackjack!\n");
        Blackjack();
        break;

    case 2:
        Console.WriteLine("You have chosen Higher or Lower!\n");
        HigherOrLower();
        break;

    case 3:
        Console.WriteLine("You have chosen Rock, Paper, Scissors!\n");
        RockPaperScissors();
        break;

    case 4:
        Console.WriteLine("You have chosen to exit the program.\n");
        break;

    default:
        Console.WriteLine("Invalid choice, please try again.\n");
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

void Blackjack()
{
    /* RULES
     * Players are dealt two cards, and the value of the cards are added together.
     * The aim of the game is to get as close to 21 as possible without going over.
     * Players can choose to 'hit' to receive another card, or 'stand' to keep their current total.
     * Maximum number of cards a player can have is 5.
     * If a player gets 21, they win.
     * Dealer also gets two cards, and must hit if their total is less or equal to 17.
     * If the dealer goes over 21, the player wins.
     * If the dealer has a higher total than the player, the dealer wins.
     * The dealer wins in the event of a draw.
     * The dealer stands if his total is 18 or above
     * Cards have a value of their number and J, Q and K are worth 10 points each
     * Ace is worth either 1 or 11 points which is player's choice */

    // Total score of player and dealer
    int playerTotal;
    int dealerTotal;
    int playerCardCount;
    int dealerCardCount;

    // Cards that player and dealer are holding
    int[] playerCards = new int[5];
    int[] dealerCards = new int[3];

    playerCards[0] = random.Next(2, 10);
    playerCards[1] = random.Next(2, 10);
    dealerCards[0] = random.Next(2, 10);
    dealerCards[1] = random.Next(2, 10);

    playerTotal = playerCards[0] + playerCards[1];
    dealerTotal = dealerCards[0] + dealerCards[1];

    Console.WriteLine($"You have drawn {playerCards[0]} and {playerCards[1]}" +
        $"\nYour total is {playerTotal}" +
        $"\nPress Space if you wish to Hit, Enter if you wish to Stand or Esc if Mama raised a quitter");

    while (true)
    {
        var keyPress = Console.ReadKey();
        if (keyPress.Key == ConsoleKey.Escape)
        {
            Console.WriteLine("\nWWhatever...");
            Environment.Exit(2000);
        }

        if (keyPress.Key == ConsoleKey.Enter)
        {
            if (dealerTotal <= 17)
            {
                dealerCards[2] = random.Next(2, 10);
                dealerTotal = dealerCards[0] + dealerCards[1] + dealerCards[2];

                Console.WriteLine($"You decided to Stand. Your total is {playerTotal}" +
                    $"\nDealers total is {dealerTotal}");
                if (dealerTotal < playerTotal)
                {
                    Console.WriteLine("You win!");

                }
                else
                {
                    Console.WriteLine("You lose!");
                }
            }
        }
        Console.WriteLine("Play again Y/N?");
    }
}