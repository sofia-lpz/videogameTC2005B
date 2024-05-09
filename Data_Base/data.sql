use colometa;

insert into player (username, password, level, score) values 
('admin', 'admin', 1, 0),
('player', 'password', 1, 0);

insert into card (cardId, name, energy_cost, effect, type, description) values
('1', 'plum juice', 3, 'healing', 'snack', 'drinking this grants 2 hp'),
('2', 'plum jam', 1, 'healing', 'snack', 'eating this grants 1 hp'),
('3', 'candy', 2, 'healing', 'snack', 'this candy grants 1 hp healing for 2 rounds'),
('4', 'bandage', 2, 'healing', 'tool', 'apply a bandage to receive 1 hp and remove effects'),
('5', 'glove', 3, 'support', 'tool', 'applies inmunity to the element damage for 1 round'),
('6', '4 leaf clover', 1, 'support', 'tool', 'increases wind attack by 1 point'),
('7', 'friendship bracelet', 1, 'support', 'tool', 'increases defense by 1 point'),
('8', 'horse shoe', 2, 'support', 'tool', 'increases attack by 2 points'),
('9', 'chocolate', 3, 'support', 'snack', 'decreases the enemy accuracy for 1 round'),
('10', 'dog', 2, 'support', 'creature', 'increases accuracy for 1 round'),
('11', 'sword', 2, 'attack', 'tool', 'deals 2 damage to your opponent'),
('12', 'fear', 3, 'attack', 'hypnosis', 'deals 1 damage to the opponent and increases defense bt 1 point'),
('13', 'sharp stick', 1, 'attack', 'tool', 'deals 1 damage to your opponent'),
('14', 'sleep', 2, 'attack', 'hypnosis', 'skips your opponents turn'),
('15', 'confusion', 2, 'attack', 'skill', 'deals 1 damage each turn for 2 turns'),
('16', 'mock', 1, 'defense', 'skill', 'mock your opponent'),
('17', 'mock', 1, 'defense', 'skill', 'mock your opponent'),
('18', 'mock', 1, 'defense', 'skill', 'mock your opponent'),
('19', 'mock', 1, 'defense', 'skill', 'mock your opponent'),
('20', 'mock', 1, 'defense', 'skill', 'mock your opponent'),
('21', 'mock', 1, 'defense', 'skill', 'mock your opponent'),
('22', 'mock', 1, 'defense', 'skill', 'mock your opponent'),
('23', 'mock', 1, 'defense', 'skill', 'mock your opponent'),
('24', 'mock', 1, 'defense', 'skill', 'mock your opponent');


-- ideas for cards
-- 24 cards minimum excluding characters
/*
4 healing cards
- plum juice (+? health)
- plum jam (+? health)
- candy (+? health)
- bandage (+? health)

6 support cards
- 4 leaf clover (increases attack)
- friendship bracelet (increases defense)
- horse shoe (increases attack)


8 attack cards
----------weapons ()
- sharp stick (initial weapon)
- sword (is it a sword? or are you imagining it?)
 
 ----------creatures

 ----------hypnosis (3)
- sleep (enemy skips turn)
- confusion ()
- fear (reduces enemy attack, increases his defense)

6 defense cards
All of these reduce damage taken
- hide (your opponent cant see you)
- stare (you've made your oponent uncomfortable and distracted!)
- mock (your opponent is embarrassed)






add run away mechanic?


Ideas for card elements (so its not just fire water ice etc)
'creature', 'hypnosis', 'snack', 'weapon', 'skill', 'charms'

snack
- candy
- apple
- orange (you can eat it or throw it as an attack?)
- chocolate
- plum juice
- sandwich
- peach
- plum jam

Weapons
- sharp stick
- sword (is it a sword? or are you imagining it?)
- pocket knife
- butcher knife
- teapot (throw it at your opponent)
- frying pan
- rake
- shovel
- watering can
- broken glass bottle
- sickle
- wheelbarrow 

hypnosis
- sleep
- confusion
- turn into chicken
- fear

creature (as in creatures you can keep in your pocket)
- beetle
- snake
- spider
- rat
- bat

objects
- 4 leaf clover (is lucky)
- 3 leaf clover
- friendship bracelet
- daisy
- severed finger (is it an actual finger? or are you hallucinating?)
- star shaped stone
- rabbit foot (super lucky)
- horseshoe
- bottlecap
- can
- glass bottle
*/