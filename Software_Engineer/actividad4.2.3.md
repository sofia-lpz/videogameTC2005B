Propósito

Formalizar una propuesta inicial para el simulador que se estará desarrollando a lo largo del semestre.

Instrucciones

Siguiendo la teoría discutida respecto al proceso iterativo de diseño de juego genera el documento Game Design Document (GDD) y documenta tus resultados para cada parte del proyecto:

    Idea del juego
    Mecanicas: Descritas con el mayor detalle posible
    Listado de pantallas
    Listado de assets
    Listado de clases a programar
    Ilustraciones de las pantallas, ambientes, personajes: Pueden ser dibujos hechos a mano, o capturas de pantalla del tabajo que ya tengan realizado

Incluye en este documento la navegación completa del juego y presenta de la manera más clara posible el comportamiento que estará teniendo.

# Actividad 4.2.3 Formalization of mechanics

## Game idea

Manticore is a strategic card-based adventure game where the player is a protagonist who, along with the rest of the villagers, have been hypnotized by a magician passing through the town with a circus. The player must navigate the distorted townscape to find the magician responsible for their altered perceptions and be returned back to normal.

The game combines exploration of a pixel art map with engaging card battles, unfolding the story through the card matches.

## Mechanics

- Map (might be scrapped due to time constraints)

The player will be able to navigate a 2d pixel art map of the town using their arrow keys. They will be able to find objects in the map which can later be used in the card matches. They will also encounter characters as they progress through the map who they can interact with for the card matches. Because of the players distorted perception these characters might appear as fantastical beings, and act erratically because of their own distorted perceptions.

- TCG

When the player encounters a character a 1v1 card match will start. First, they will choose 3 characters from the characters they have in their inventory. Their deck will be made up of the objects they've collected during the exploration part of the game and some will be predetermined. They are in the players inventory.
Also there are 4 elements that the characters will have, fire, water, snow, air. To counter a water character, you will have to use a snow character, this will make that the water character receives more damage and does less damage. This as this, fire defeats snow and is countered by water, snow defeats water and is countered by fire, water defeats fire and is countered by snow. Air doesn't have a counter or defeats the other elements, what air does is to react to the effect that the element effect that the enemy has and makes damage to more than one player, but the damage that air characters do, is lower to others.
The player can choose the active character at any time but it will have energy cost to switch active characters.

### Game flow

- First the player will choose the 3 characters that they will use.

- A coin will toss to decide which player starts their turn first.

- Then the player must roll some dice. This determines the number of energy poitns they have for the turn, and is random.

- Also the player will decide its starting character.

- Players can play the cards they want per turn, they are limited by their energy in the round, the energy resets each round. These have different effects such as healing, which increases their health, attack, which lowers the health of the opponent, effects such as attack buffs or defense buffs, these have an element.

To play their card they need to have the necessary energy as dictated by the card. When they play the card the energy points are spent and their turn is over.

- The match ends when either the player or the enemy lose all their health.

If a player wins the match, they get rewarded with new cards or abilities that they can use in the next matches and they can carry on exploring the rest of the map.

## Screen list

### Main screen

Here the player can login and play, start a new game or change to the stats screen

### Stats
Here a user can see the stats gathered about the game. These include the user with the highest score, and user specific stats such as most used card, amount of found cards, between others.

### Map

Here the player can move through the town

### TCG match

### Table
Here the player can see their match cards and the enemy cards as well as some parts of the enemy

### enemy
In this screen view the player can see the enemy. This might include any dialogue that the enemy says to the player to build the story.

### Result screen

In this screen the player will be able to see the result of the match, that is to say wether they won or lost, and the rewards or penalties that come of the match result

### Ending screen
At the end of the game, which might include at least 3 card matches, an outcome of the story will play out through dialogue. This might include finding the magician.


## Asset list

- Scenes

Main
Map
match

- Prefabs

main character
enemies

- sprites

main character
tilesets

- Scripts

map game manager
scene changer
tcg game manager



## Classes to add

map game manager
scene changer
tcg game manager


## Illustrations


