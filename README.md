# Card War Game

## How to Build and Run

Open a terminal in the project root folder and run:

dotnet build

Then run the game:

dotnet run --project CardWar/CardWar.Console

## How the Game Works

The deck is shuffled and distributed evenly among all players.

In each round, every player places one card face-up.  
The player with the highest-ranked card wins the round and collects all cards in the pot.

If there is a tie, only the tied players continue by playing additional cards.  
The winner of the tie round collects all cards accumulated in the pot.

The user is prompted to enter the number of players before the game begins.

## Game Rules

- Supports **2 to 4 players only**
- Round play is **fully automatic**
- Maximum of **10,000 rounds** to prevent infinite loops
- Players with no cards are eliminated
- The game ends when one player remains or the round limit is reached

## Game Output

Each round displays:
- Each player’s card
- The round winner
- Remaining card count for each player

## UML Diagram

File: CardWar_UML.png

The UML diagram includes:
- Card, Deck, Hand
- Player, PlayerHands
- PlayedCard (handles round logic and tie resolution)
- GameEngine (controls overall game flow)

## GitHub Repository

https://github.com/etsucs-scott/project-2-olalekan78552-bot