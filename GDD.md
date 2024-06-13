# **Chasing Colometa**

## _Game Design Document_

---

**Developers:**  
Diego Valencia  
Javier Montero  
Daniel Filorio  
Sofia Moreno

## _Index_

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
7. [Sounds/Music](#sounds-music)
    1. [Style Attributes](#style-attributes-1)
    2. [Sounds Needed](#sounds-needed)
    3. [Music Needed](#music-needed)
8. [Schedule](#schedule)

## _Game Design_

---

### **Summary**

"Chasing Colometa" is a strategic card-based RPG set in a lonely village. The player must navigate the village to uncover the mystery behind a magic show gone awry. Throughout the journey, the player encounters various memories and interacts with villagers affected by the incident. The game combines exploration of a pixel art map with card battles.

### **Gameplay**

The game integrates exploration with card-based combat. The storyline unfolds through the map and card matches. Players encounter enemies transformed by the protagonist's distorted perception into fantastical beings. The primary objective is to find a lost girl and uncover what happened to her.

Success in battle depends on strategic deck management and the ability to adapt tactics to changing conditions.

### **Mindset**

The game is designed to induce a sense of curiosity, encouraging players to question the reality presented within the game. Exploration is meant to be adventurous, while the card combat phase is intense and strategic, creating an intellectually engaging atmosphere. The game employs eerie, whimsical music and unsettling yet compelling cutscenes, using dialogue boxes to enhance the narrative. This artistic approach supports the theme of fluctuating reality, aiming to disorient yet captivate players, making each session a uniquely challenging and immersive experience.

### **Screens**

- Main Title Screen
- Register Screen
- Login Screen
- Map in the Village
- Map in a Forest Clearing
- Character Selection Screen
- Win Screen
- Lose Screen

### **Controls**

- Move through the map using W, A, S, and D keys.
- Interact with objects and people with the Enter key.
- Pause with the P key.
- Skip dialogues with the Space bar.
- Skip scenes with the S key.
- Interact with cards and characters with mouse clicks in the TCG.

### **Mechanics**

The player will navigate a 2D pixel art map of the town from a top-down angle using their arrow keys. They will find objects on the map to interact with, activating cutscenes and revealing more of the story. Characters encountered on the map will further the story through interactions.

**TCG Mechanics**

When the player encounters a character, a 1v1 card match begins. There are two types of cards: character cards and action cards.

- Players choose 3 character cards from their inventory.
- The deck is made up of collected and predetermined action cards.
- Each character card has 10 health points.

#### Elements and Synergy

1. Reason beats Terror
2. Terror beats Dream
3. Dream beats Reason

#### Turn Mechanics

#### Action Cards

**Winning Condition:** The player who first defeats the opponent's 3 character cards wins.

### **Themes**

**Forest:**
- Mood: Dark, calm, foreboding

**Village:**
- Mood: Calm, strange, sleepy

### **Game Flow**

1. Player starts with a cutscene describing the incident.
2. Player starts in the village in front of a barn.
3. Path to the left.
4. Player encounters a woman asking about her missing daughter.
5. Player activates a cutscene with a watermelon on the path.
6. Player goes left of the trees, finds another watermelon near the pond, and activates a cutscene.
7. Player encounters a friend who warns them about the forest.
8. Player spots a watermelon on the other side of the pond.
9. Player reaches the watermelon by returning to the start of the forest and activates a cutscene.
10. Player is encouraged to enter the forest.
11. Player is prompted to pick characters for the TCG match.
12. Player encounters a huge centipede in the forest.
13. TCG match starts.

## _Development_

---

### **Abstract Classes / Components**

1. **BasePhysics**
    - BasePlayer
    - BaseEnemy
    - BaseObject
2. **BaseObstacle**
3. **BaseInteractable**

### **Derived Classes / Component Compositions**

1. **Allscenes**
    - Background sound manager
    - Fade in
    - Fade out
    - Volume Manager
2. **TCG match**
    - Posts to the API of data
    - Card buttons class
    - Card animation manager
    - Character card class
    - Defense bar manager
    - Enemy card class
    - Health bar manager
    - Pause Controller
    - Pause animation class
    - Result handler
    - TCG controller
    - Tcgdata (which contains player preferences and other data)
    - Tcgfeedback
3. **Map scripts**
    - Mother event manager derived from eventManager class
    - Running event manager derived from eventManager class
    - Character movement
    - NPC movement derived from character movement
    - NPC specific movement derived from character movement
    - Pick me up, derived from collideable object class
    - Talk to me, derived from collideable object class
    - Fight me derived from collideable object class
    - Force fight derived from triggerable object class
    - Force talk derived from triggerable object class
    - Map manager class
    - Next scene collider class
    - Triggerable object
    - Collideable object
4. **Main menu**
    - Login class
    - Register class
    - Menu buttons class
    - Main menu manager class
5. **Dialogue**
    - Dialogue class
    - Dialogue data class

## _Graphics_

Graphics are primarily taken or adapted from the videogame "Omori."

### **Style Attributes**

- Colors: Pastels, blues, and purples.
- Style: Pixelated, cute yet dark.
- No outlines.
- Hand-drawn style animations.
- The art style is very similar to "Omori," focusing on a blend of charming and eerie elements. The use of soft pastel colors contrasts with the dark themes of the game, creating a unique visual experience that is both nostalgic and unsettling.
- The characters and environments are drawn in a way that emphasizes simplicity and expressiveness. Characters have large, emotive eyes and simple yet distinctive features.
- Backgrounds are richly detailed with a mix of natural and fantastical elements, designed to evoke a sense of mystery and curiosity.
- Animations are smooth and hand-drawn, giving life to the pixel art and enhancing the overall immersive experience. Transitions between scenes and actions are fluid, maintaining the whimsical yet eerie atmosphere of the game.

### **Graphics Needed**

1. **Characters**
    - Human
        - Protagonist (idle, walking, running)
        - Friend (idle, walking)
        - Mother (idle, walking)
        - Daughter (idle, walking)
    - Other
        - Centipede (attacking)
    - **Character Cards backgrounds**
        - Reason
        - Terror
        - Dream
    - **Cards**
        - Frames

2. **Tilemaps**
    - Village
    - Forest
    - Barn
    - Watermelon
    - Centipede

3. **Ambient**
    - Trees
    - Rocks
    - Grass
    - Water
    - Flowers
    - Bushes
    - Signs
    - Fences

4. **Other**
    - Buttons

## _Sounds/Music_

Music tracks taken from the "Omori" videogame soundtrack and sound effects from free resources.

### **Sounds Needed**

1. Healing sound
2. Attack sound
3. Defense sound
4. Support sound
5. Dialogue sound
6. Button sounds

### **Music Needed**

1. My Time
2. By Your Side
3. Let's Get Together Now
4. You Were Wrong. Go Back.
5. WHITE SPACE
6. Lost At A Sleepover
7. 100 Sunny
8. Trees...
9. Finding Shapes in the Clouds
10. DUET
11. Trouble Brewing
12. A Home for Flowers (Dandelion)
13. Sis
14. Flouring the Fruits
15. ...Where We Used to Play
16. It's OK to Try Again
17. EVERYONE
18. My Time (Piano)
19. See You Tomorrow
20. The Windmill
21. 3 o'clock, Let's Jam!
22. Remembrance
23. Snow Forest
24. Overture
25. I Prefer My Pizza (Mambo)
26. Treehouse (Quiet)



27. Spaces In Between
28. My Time (Violin)

## _Schedule_

---

Expected completion date: June 12, 2024