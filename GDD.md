# **Lost illusion**

## _Game Design Document_

---

##### **Copyright notice / author information / boring legal stuff nobody likes**

##
## _Index_

---

1. [Index](#index)
2. [Game Design](#game-design)
    1. [Summary](#summary)
    2. [Gameplay](#gameplay)
    3. [Mindset](#mindset)
3. [Technical](#technical)
    1. [Screens](#screens)
    2. [Controls](#controls)
    3. [Mechanics](#mechanics)
4. [Level Design](#level-design)
    1. [Themes](#themes)
        1. Ambience
        2. Objects
            1. Ambient
            2. Interactive
        3. Challenges
    2. [Game Flow](#game-flow)
5. [Development](#development)
    1. [Abstract Classes](#abstract-classes--components)
    2. [Derived Classes](#derived-classes--component-compositions)
6. [Graphics](#graphics)
    1. [Style Attributes](#style-attributes)
    2. [Graphics Needed](#graphics-needed)
7. [Sounds/Music](#soundsmusic)
    1. [Style Attributes](#style-attributes-1)
    2. [Sounds Needed](#sounds-needed)
    3. [Music Needed](#music-needed)
8. [Schedule](#schedule)

## _Game Design_

---

### **Summary**

Is a strategic card-based adventure game in a visually distorted cityscape, where the player navigate an hypnotized protagonist on a quest to confront the magician responsible for their altered state of consciousness. The game combines exploration of a pixel art map with engaging card battles, unfolding the story through vividly illustrated cutscenes.

### **Gameplay**

The game integrates exploration with card-based combat. Each level on the 2D pixel art map represents a card battle that progressively reveals the storyline through both victories and defeats. Players encounter a variety of enemies transformed by the protagonist's distorted perception into fantastical beings. The primary objective is to reach the magician, overcoming obstacles such as complex cards and deceptive environments that tweak gameplay mechanics. Success in battles depends on strategic deck management and the ability to adapt tactics to the shifting conditions influenced by the magician effects.

### **Mindset**

The game is designed to induce a sense of curiosity, encouraging players to continuously question the reality presented within the game. Exploration is meant to be adventurous, with card combat phases designed to be intense and strategic, creating an intellectually engaging atmosphere. This employs a unique blend of eerie, whimsical music and unsettling yet compelling cutscenes, utilizing images and dialogue boxes to enhance the narrative. This artistic approach supports the theme of fluctuating reality, aiming to disorient yet captivate players, making each session a uniquely challenging and immersive experience.

## _Technical_

---

### **Screens**

1. Title Screen
    1. Options
2. Level Select
3. Game
    1. Inventory
    2. Assessment / Next Level
4. End Credits

_(example)_

### **Controls**

How will the player interact with the game? Will they be able to choose the controls? What kind of in-game events are they going to be able to trigger, and how? (e.g. pressing buttons, opening doors, etc.)

### **Mechanics**

- Map (might be scrapped due to time constraints)

The player will be able to navigate a 2d pixel art map of the town in a top down angle using their arrow keys. They will be able to find objects in the map which can later be used in the card matches. They will also encounter characters as they progress through the map who they can interact with for the card matches. Because of the players distorted perception these characters might appear as fantastical beings, and act erratically because of their own distorted perceptions.

- TCG

When the player encounters a character a 1v1 card match will start. There are 2 types of cards, the character cards and the action cards.

First, they will choose 3 characters cards from the characters cards they have in their inventory. Their deck will be made up of the action cards they've collected during the exploration part of the game and some will be predetermined. They are in the players inventory. Each character card has 10 health points.

<p align="center">
  <img src="/Videogame/LostIllusion/Assets/Sprites/Preview.PNG" width="500" height="300">
</p>

There are 4 elements that the characters cards will have, fire, water, snow, air. If the element is countered, the winning element will make more damage and receive less damage. The elements synergy is the following:
1. Fire beats Snow
2. Snow beats Water
3. Water beats Fire
4. Air doesn't have a counter nor can counter other element, this will be explained later.
   
<p align="center">
  <img src="/Videogame/LostIllusion/Assets/Sprites/ElementSynergy.png" width="500" height="300">
</p>

After selecting the 3 character cards, there will be a coin toss to decide which player starts their turn first, after this both players will roll 2 dice to determine the energy that they will have that turn, the energy will be used to use action cards, this will have an energy cost, the player can play all the cards they want, it is limited by the energy. After rolling the dice, both players at the same time will choose their active character. The player can choose the active character at any time but it will have energy cost to switch active characters.

<p align="center">
  <img src="/Videogame/LostIllusion/Assets/Sprites/Dado.png" width="300" height="300">
</p>

Each character card will have a passive ability, depending on their role, the roles will be: dps, tank, support. Some examples of the passive abilities are:
1. DPS character that his passive ability is to deal more damage of its element
2. Tank character that when its attacked provides a shield
3. Support character that if a character receives a lethal strike, this means that his health points reach zero, the character revives with 3 health points.

<p align="center">
  <img src="/Videogame/LostIllusion/Assets/Sprites/Cartasmesa2.PNG" width="500" height="300">
</p>

The action cards will help to do the actions the character will do, within the action cards there are many actions that can be made, there are cards to attack the character card of the opponent, other to heal your current active character, other to buff the attack damage of the main character, and other to apply defense to your current active character. Also, some of the action cards will have an element, this will be for various purposes such as:
1. For damage buffs, the card will only buff the damage of the element that the card has.
2. For defense, the cards will apply defense against the element that the card has.
3. For attack, the cards will attack causing damage of that element.

<p align="center">
  <img src="/Videogame/LostIllusion/Assets/Sprites/Poderes2.PNG" width="500" height="300">
</p>

 If the player uses the action card that has the same element as the active character it will produce a succesful attack that will apply the element effect on the opponent, this will help for the wind element, when the wind element attacks a character card that has an element effect, it will produce damage of that element to the character cards. If a player uses attack action card that the element of the card does not match the element of the active character, the damage will be decreasen and the element effect won't be applied.

 If the player has not enough energy points to use a card or doesn't want to use his energy points, he can end his turn. Every turn, both players will draw 2 cards from their deck, the cards will be random, also each round the energy points will be restarted and the dice will be rolled once again. The player that first defeats the 3 character cards of the other player, will win.


## _Level Design_

---

_(Note : These sections can safely be skipped if they&#39;re not relevant, or you&#39;d rather go about it another way. For most games, at least one of them should be useful. But I&#39;ll understand if you don&#39;t want to use them. It&#39;ll only hurt my feelings a little bit.)_

### **Themes**

1. Forest
    1. Mood
        1. Dark, calm, foreboding
    2. Objects
        1. _Ambient_
            1. Fireflies
            2. Beams of moonlight
            3. Tall grass
        2. _Interactive_
            1. Wolves
            2. Goblins
            3. Rocks
2. Castle
    1. Mood
        1. Dangerous, tense, active
    2. Objects
        1. _Ambient_
            1. Rodents
            2. Torches
            3. Suits of armor
        2. _Interactive_
            1. Guards
            2. Giant rats
            3. Chests

_(example)_

### **Game Flow**

1. Player starts in forest
2. Pond to the left, must move right
3. To the right is a hill, player jumps to traverse it (&quot;jump&quot; taught)
4. Player encounters castle - door&#39;s shut and locked
5. There&#39;s a window within jump height, and a rock on the ground
6. Player picks up rock and throws at glass (&quot;throw&quot; taught)
7. … etc.

_(example)_

## _Development_

---

### **Abstract Classes / Components**

1. BasePhysics
    1. BasePlayer
    2. BaseEnemy
    3. BaseObject
2. BaseObstacle
3. BaseInteractable

_(example)_

### **Derived Classes / Component Compositions**

1. BasePlayer
    1. PlayerMain
    2. PlayerUnlockable
2. BaseEnemy
    1. EnemyWolf
    2. EnemyGoblin
    3. EnemyGuard (may drop key)
    4. EnemyGiantRat
    5. EnemyPrisoner
3. BaseObject
    1. ObjectRock (pick-up-able, throwable)
    2. ObjectChest (pick-up-able, throwable, spits gold coins with key)
    3. ObjectGoldCoin (cha-ching!)
    4. ObjectKey (pick-up-able, throwable)
4. BaseObstacle
    1. ObstacleWindow (destroyed with rock)
    2. ObstacleWall
    3. ObstacleGate (watches to see if certain buttons are pressed)
5. BaseInteractable
    1. InteractableButton

_(example)_

## _Graphics_

---

### **Style Attributes**

What kinds of colors will you be using? Do you have a limited palette to work with? A post-processed HSV map/image? Consistency is key for immersion.

What kind of graphic style are you going for? Cartoony? Pixel-y? Cute? How, specifically? Solid, thick outlines with flat hues? Non-black outlines with limited tints/shades? Emphasize smooth curvatures over sharp angles? Describe a set of general rules depicting your style here.

Well-designed feedback, both good (e.g. leveling up) and bad (e.g. being hit), are great for teaching the player how to play through trial and error, instead of scripting a lengthy tutorial. What kind of visual feedback are you going to use to let the player know they&#39;re interacting with something? That they \*can\* interact with something?

### **Graphics Needed**

1. Characters
    1. Human-like
        1. Goblin (idle, walking, throwing)
        2. Guard (idle, walking, stabbing)
        3. Prisoner (walking, running)
    2. Other
        1. Wolf (idle, walking, running)
        2. Giant Rat (idle, scurrying)
2. Blocks
    1. Dirt
    2. Dirt/Grass
    3. Stone Block
    4. Stone Bricks
    5. Tiled Floor
    6. Weathered Stone Block
    7. Weathered Stone Bricks
3. Ambient
    1. Tall Grass
    2. Rodent (idle, scurrying)
    3. Torch
    4. Armored Suit
    5. Chains (matching Weathered Stone Bricks)
    6. Blood stains (matching Weathered Stone Bricks)
4. Other
    1. Chest
    2. Door (matching Stone Bricks)
    3. Gate
    4. Button (matching Weathered Stone Bricks)

_(example)_


## _Sounds/Music_

---

### **Style Attributes**

Again, consistency is key. Define that consistency here. What kind of instruments do you want to use in your music? Any particular tempo, key? Influences, genre? Mood?

Stylistically, what kind of sound effects are you looking for? Do you want to exaggerate actions with lengthy, cartoony sounds (e.g. mario&#39;s jump), or use just enough to let the player know something happened (e.g. mega man&#39;s landing)? Going for realism? You can use the music style as a bit of a reference too.

 Remember, auditory feedback should stand out from the music and other sound effects so the player hears it well. Volume, panning, and frequency/pitch are all important aspects to consider in both music _and_ sounds - so plan accordingly!

### **Sounds Needed**

1. Effects
    1. Soft Footsteps (dirt floor)
    2. Sharper Footsteps (stone floor)
    3. Soft Landing (low vertical velocity)
    4. Hard Landing (high vertical velocity)
    5. Glass Breaking
    6. Chest Opening
    7. Door Opening
2. Feedback
    1. Relieved &quot;Ahhhh!&quot; (health)
    2. Shocked &quot;Ooomph!&quot; (attacked)
    3. Happy chime (extra life)
    4. Sad chime (died)

_(example)_

### **Music Needed**

1. Slow-paced, nerve-racking &quot;forest&quot; track
2. Exciting &quot;castle&quot; track
3. Creepy, slow &quot;dungeon&quot; track
4. Happy ending credits track
5. Rick Astley&#39;s hit #1 single &quot;Never Gonna Give You Up&quot;

_(example)_


## _Schedule_

---

_(define the main activities and the expected dates when they should be finished. This is only a reference, and can change as the project is developed)_

1. develop base classes
    1. base entity
        1. base player
        2. base enemy
        3. base block
  2. base app state
        1. game world
        2. menu world
2. develop player and basic block classes
    1. physics / collisions
3. find some smooth controls/physics
4. develop other derived classes
    1. blocks
        1. moving
        2. falling
        3. breaking
        4. cloud
    2. enemies
        1. soldier
        2. rat
        3. etc.
5. design levels
    1. introduce motion/jumping
    2. introduce throwing
    3. mind the pacing, let the player play between lessons
6. design sounds
7. design music

_(example)_
