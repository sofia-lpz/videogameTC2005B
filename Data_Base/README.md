# ENTITY RELATIONSHIP MODEL

![ER-Model Image](./retoUML.jpg)

## Proposed entity relation model for the TCG

- **player**

 The players have usernames, level in which they are playing, a score, and a boolean npc indicator. This is so enemies of the player are stored in the same table. They can have multiple cards in their deck/inventory

- **playerCard**

  Given the many-to-many relationship between cards and players, this intermediate table was created. It has a composite primary key consisting of the player ID and the card ID.

- **card**

  Cards have names, element, description to display on the card, an energy cost, and an effect

- **effect**

  These are types that appear in the game and are applicable to different cards, as previously mentioned. They have a duration and a description and are related to the cardID, since they have a one to one relationship

- **action**

  These are things that cards can do in game, such as attack, heal, etc.

- **actionCard**

  Given the many-to-many relationship between cards and attacks, since cards can have multiple attacks or share them with other cards, this intermediate table was created. Like playerCard, it has a composite primary key with the card ID and the action ID


- **Match**

  This table is to keep score of matches played. it includes a date, a playerID and a result which can say if the non npc player won or not. This is for showing stats later.
