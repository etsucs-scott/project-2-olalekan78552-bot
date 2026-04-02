#Submission Note

Card War Game
How the Game Works

The deck is shuffled and distributed evenly among all players.
In each round, every player places one card face-up.
The player with the highest-ranked card wins the round and collects all cards in the pot.

If there is a tie, only the tied players continue by playing additional cards.
The winner of the tie round takes all cards accumulated in the pot.

The user is prompted to enter the number of players before the game begins.

Description
Game supports 2 – 4 players only
Round play is fully automatic
The game has a 10,000 round cap to prevent infinite loops
How to Build the Game
Create a Card class and define enums for Rank and Suit
Create a Deck class and implement shuffle functionality
Create a Hand class to store each player’s cards using a queue
Create a PlayerHand class to map players name to players card
Create a playedCard class to compare card being played 
Create a Player class to represent each player
Implement the game logic inside a GameEngine class



Name: Stephen Aguda
Project: CardWar

GitHub Repository:
https://github.com/etsucs-scott/project-2-olalekan78552-bot