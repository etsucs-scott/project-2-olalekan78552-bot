using System.Text;
using CardWar.Core;

namespace CardWar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //List<Card> myCard = new List<Card>();
            //Console.WriteLine("Hello, World!");

            //Deck deck = new Deck();

            //foreach (Card card in deck.Cards)
            //{
            //    Console.WriteLine(card);
            //}

            //Console.Write("Enter the number of players: ");
            //while (!int.TryParse(Console.ReadLine(), out int nOfPlayers))
            //{
            //    Console.Write("Enter a number between 2 and 4: ");
            //}

            //Console.WriteLine(deck.Count);

            //Console.WriteLine(deck.Cards.Peek());

            //Card tempCard = deck.Cards.Pop();

            //myCard = new List<Card>(deck.Cards);

            //Console.WriteLine(tempCard);



            //foreach (Card card in myCard)
            //{
            //    Console.WriteLine(card);
            //}
            Deck deck = new Deck();
            deck.Shuffle();
            
            GameEngine game = new GameEngine(deck);
            game.AddPlayers();           
            game.DealCard();   
            game.StartGame();

            































        }
    }
}
