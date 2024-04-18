using System;

class Program
{
    static readonly Random random = new Random();

    static void Main()
    {
        Console.WriteLine("Welcome to the casino!\nPlease press 1 to play Blackjack or any other key to exit.");

        if (int.TryParse(Console.ReadLine(), out int gameChoice) && gameChoice == 1)
        {
            Console.WriteLine("\nYou have chosen to play. Good luck!");
            Blackjack();
        }
        else
        {
            Console.WriteLine("\nYou have chosen to exit the program.");
        }
        Console.WriteLine("Thanks for playing! Goodbye!");
    }
    static void Blackjack()
    {
        while (true)
        {
            Console.WriteLine("\nPress Spacebar to draw your hand or any other key to quit");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Spacebar)
            {
                PlayBlackjackRound();
                if (!ShouldPlay()) break;
            }
            else
            {
                Console.WriteLine("Exiting...");
                break;
            }
        }
    }
    static bool ShouldPlay()
    {
        Console.WriteLine("\nPlay again? Please enter Y or N.");
        return Console.ReadLine()?.Trim().ToUpper() == "Y";
    }

    static void PlayBlackjackRound()
    {
        int playerTotal = 0;
        int dealerTotal = 0;

        int[] playerCards = new int[7];
        int[] dealerCards = new int[7];

        playerTotal = DrawInitialCards(playerCards, "Player");
        dealerTotal = DrawInitialCards(dealerCards, "Dealer");

        DisplayInitialCards(playerCards, dealerCards);

        while (playerTotal <= 21)
        {
            Console.WriteLine("\nPress Spacebar to Hit or Enter to Stand");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.Spacebar)
            {
                playerTotal = Hit(playerCards, playerTotal);
                Console.WriteLine($"\nYour total is {playerTotal}");
            }
            else if (key.Key == ConsoleKey.Enter)
            {
                Console.WriteLine($"\nYour final total is {playerTotal}");
                break;
            }
        }

        if (playerTotal > 21)
        {
            Console.WriteLine("Player busts! Dealer wins.");
            return;
        }

        while (dealerTotal < 17)
        {
            dealerTotal = Hit(dealerCards, dealerTotal);
            Console.WriteLine($"Dealer's total is {dealerTotal}");
        }

        if (dealerTotal > 21)
        {
            Console.WriteLine("Dealer busts! Player wins.");
            return;
        }
        DetermineWinner(playerTotal, dealerTotal);
    }

    static int DrawInitialCards(int[] cards, string playerName)
    {
        int total = 0;
        for (int i = 0; i < 2; i++)
        {
            int card = random.Next(1, 11);
            if (card == 1)
            {
                card = ChooseAceValue();
            }
            cards[i] = card;
            total += card;
        }
        return total;
    }

    static void DisplayInitialCards(int[] playerCards, int[] dealerCards)
    {
        Console.WriteLine($"\nYou drew {playerCards[0]} and {playerCards[1]}");
        Console.WriteLine($"Your total is {playerCards[0] + playerCards[1]}");
        Console.WriteLine($"Dealer's card is {dealerCards[0]}");
    }

    static int Hit(int[] cards, int total)
    {
        int index = Array.IndexOf(cards, 0);
        int card = random.Next(1, 11);
        if (card == 1)
        {
            card = ChooseAceValue();
        }
        cards[index] = card;
        return total + card;
    }

    static int ChooseAceValue()
    {
        Console.WriteLine("\nYou drew an ace. Press 1 for value of 1 or 2 for value of 11?");
        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey();
        } while (key.Key != ConsoleKey.D1 && key.Key != ConsoleKey.D2);
        return key.Key == ConsoleKey.D1 ? 1 : 11;
    }

    static void DetermineWinner(int playerTotal, int dealerTotal)
    {
        if (playerTotal > dealerTotal)
        {
            Console.WriteLine("Player wins!");
        }
        else if (playerTotal < dealerTotal)
        {
            Console.WriteLine("Dealer wins!");
        }
        else
        {
            Console.WriteLine("It's a tie!");
        }
    }
}
