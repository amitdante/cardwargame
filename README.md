# cardwargame
War Game

Play the classic war game against the AI, There are 2 decks, player's deck is on the lower half, click on it to draw a card and send it to battle zone.
The Ai will also draw a card to fight against you, the card which has more value wins.
Possible values are 1-10 both included.
One on one card showdown is called a battle, winner takes both cards, the value of cards left in the deck is shown next to the deck.
The number of cards currently present in the battlefield is shown below the battlefield as "Cards At Stake"
If both cards are of same value during a battle, a war begins, you and AI both draw the number of cards equal to the card's value that started the war.
The drawing of card is done automatically, whoever wins the war wins all cards.
First player left with 0 cards loses the game.
During each battle after the winner is decided, a button appears which is labeled as "Your Turn" which should be clicked inorder to start next turn 
of drawing cards.

SOLUTION ARCHITECTURE
1) Created a full deck in GameManager, which is a list holding objects of CardData class, then they are shuffled and distributed into 2 halves, player1Cards and player2Cards.
2) These halves consists the decks for both players, during a move, a card is spawn which pulls its value from the CardData objects situated at top of list, and removes that top element form the list, adding it to a temporary list.
3) AI does the same thing with his list, so there are two temporary lists now, on the end of the battle the cards from both temporary lists are added to winner player's deck list.
4) During a war, the temporary lists are kpt intact until the war is over and then assigned to the winner player.
5) This continues until one of the players is left with no cards.

CODE STRUCTURE
GameManager handles most of the gameplay logic and initialization of cards happens at PopulateCards.
Each player has a DeckScript assigned to their deck, which handles spawning of individual cards and calling their methods.
Each card has a MovementHandler script which makes them rotate and move during gameplay, SetData handles the setting of power values of card.
All UI is handled by the GameManager.
All scripts refer to GameManager as global source of game state data and gameplay functions.

ASSUMPTIONS
No general assumptions, have followed the requirements as closely as possible.
A is 1, J-Q-K are 11,12,13 respectively.
I have tested most of the functionality myself, but some bugs might be encountered, in that case you can revert back to me and I will fix them asap.

HAVE FUN !
