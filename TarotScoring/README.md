TarotScoring
===========

Tarot is a French card game, for more details have a look to [the wikipedia page](https://en.wikipedia.org/wiki/French_tarot)

We will focus on the scoring part, no need to have any knowledge of this game ;).

##Problem Description

The FFT (Federation Francais de tarot) would like to implement an automatic scoring system **only for 3-4 people**.

Your goal is to match their requirements explained in the 5 parts.

##Introduction scoring rules

Scoring in tarot is "zero-sum"; when one player gains points, one or more other players lose this number of point.

**The total of the point players will be always 0.**

The point are calucalted with 6 kind of parameters:
* Basic contract (25 points)
* The bet (will give a multiplier)
* The point made by the attaquant team (extra points)
* The petit au bout (optional, give 10 points)
* The bonuses (misere, poignee... it's optional)
* Chelem

Here's the formula for the score calculation of one round:
```
s = bet multiplier * (basic contract + extra points + petit au bout) + bonuses + chelem
```

For a deeper look check: [scoring on wikipedia](https://en.wikipedia.org/wiki/French_tarot#Scoring)

Let's start!!

##Players (part 1)

The first input that you will get is the player list.

All the players start with 0 point.

##Example
* "Bob Leo Mathilde Jean"
* "Elise George Adeline"

##Round (part 2)

A round starts when a player bet that he will manage to reach a score contract (determine by oulders) with his cards.

For a basic round score calculator we use 4 parameters:
* Basic contract: **25 points**
* The bet (multiplier see betting table)
* The extra points
* The petit au bout (see Petit au bout table)

Here's the input format that you will have:
```
"PlayerName TypeOfBet WinOrLose extraPoint PetitAuBoutOptional"
```

The round scoring is determined by this formula:

**RoundScoring = (basic point contract + extra points + petit au bout) * multiplier**

The attacking player win, this score has to be removed to all the defending players. The substraced points has to be added to the attacking player.

If the attacking player lose, this score has to be added to all the defending players. The added points has to be substracted to the attacking player.

##Input tables

**Betting table:**

| Bet               | Multiplier    | Input Synthax |
| ----------------- | ------------- | ------------- |
| Petite (Prise)    | x1            | Petite        |
| Garde             | x2            | Garde         |
| Garde Sans        | x4	        | GardeSans     |
| Garde Contre      | x6	        | GardeContre   |

**Petit au bout table:**

| Bonus                   | Score | Input Synthax  |
| ----------------------- | ----- | -------------- |
| Petit au bout (attaque) | +10   | PetitAuBoutAtt |
| Petit au bout (defence) | -10   | PetitAuBoutDef |

##Example

| input                                          | Murray    | George    | Bob       | total |
| ---------------------------------------------- | --------- | --------- | --------- | ----- |
| "Murray George Bob"                            | 0         | 0         | 0         | 0     |
| "Bob Garde WinOf 3"                            | -56       | -56       | 112       | 0     |
| "George GardeSans LooseOf 0 PetitAuBoutDef"    | 84        | -336      | 252       | 0     |
| "Murray Petite WinOf 31"                       | 196       | -392      | 196       | 0     |
| "George GardeContre LooseOf 5"                 | 376       | -752      | 376       | 0     |
| "Bob Garde WinOf 0 PetitAuBoutAtt"             | 306       | -822      | 516       | 0     |

##Bonuses (part 3)

The bonuses happens during a round but to handle it in an easier way we separate it from the round scoring.

There are 4 kind of bonuses.

Here's the input format that you will have:
```
"PlayerName TypeOfBonus"
```

##Input table

**Bonus table**

| Bet               | Score | Input Synthax |
| ----------------- | ----- | ------------- |
| Misere            | +10   | Misere        |
| Poignée           | +20   | Poignee20     |
| Poignée double    | +30   | Poignee30     |
| Poignée triple    | +40   | Poignee40     |

##Example

Warning the part 2 is included in the exemple.

| input                                                | Murray    | George    | Bob       | Clair     |
| ---------------------------------------------------- | --------- | --------- | --------- | --------- |
| "Murray George Bob Clair"                            | 0         | 0         | 0         | 0         |
| "Bob Garde WinOf 14"                                 | -78       | -78       | 234       | -78       |
| "Clair Misere"                                       | -88       | -88       | 224       | -48       |
| "Bob Poignee20"                                      | -108      | -108      | 284       | -68       |
| "George GardeContre LooseOf 5"                       | 72        | -648      | 464       | 112       |
| "George Poignee20"                                   | 52        | -588      | 444       | 92        |
| "George GardeSans LooseOf 0 PetitAuBoutDef"          | 192       | -1008     | 584       | 232       |
| "Bob Petite WinOf 31"                                | 136       | -1064     | 752       | 176       |
| "Bob GardeSans WinOf 21 PetitAuBoutAtt"              | -88       | -1288     | 1424      | -48       |
| "Bob Poignee30"                                      | -118      | -1318     | 1514      | -78       |
| "Bob Garde WinOf 3"                                  | -174      | -1374     | 1682      | -134      |


##Chelem (part 4)

(coming soon)

##5 players (part 5)

(coming soon)
