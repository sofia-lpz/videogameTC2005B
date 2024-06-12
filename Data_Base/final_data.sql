use colometa;

insert into player (username, password) values
('player', 'admin');

insert into villager (name, description, element) values
("Cat", "Its your cat!", "Reason"),
("Doll", "Possesed doll", "Terror"),
('Sheep', 'A random sheep that escaped from a farm. Not very interested in going back', 'Dream'),
('Bird', 'A bird that is always chirping', 'Reason'),
('Ghost', 'A ghost that haunts the house', 'Terror'),
('Bluejay', 'A bluejay that is always flying', 'Dream');

insert into card (cardId, name, energy_cost, effect, type, description, player_health, player_attack, player_defense, player_support, enemy_defense, enemy_attack) values
('1', 'BANDAGE', 3, 'healing', 'snack', 'drinking this grants 3 hp', 3, 0, 0, 0, 0, 0),
('2', 'FIRST AID KIT', 1, 'healing', 'snack', 'eating this grants 1 hp', 1, 0, 0, 0, 0, 0),
('3', 'CANDY', 2, 'healing', 'snack', 'this candy grants 2 hp', 2, 0, 0, 0, 0, 0),
('4', 'GRAPE SODA', 3, 'healing', 'skill', 'apply and heal 3 hp', 3, 0, 0, 0, 0, 0),

('5', 'KNIFE', 3, 'attack', 'skill', 'deals 3 damage points to the opponent', 0, 3, 0, 0, 0, 0),
('11', 'BAT', 2, 'attack', 'weapon', 'deals 2 damage to the opponent', 0, 2, 0, 0, 0, 0),
('12', 'RAKE', 2, 'attack', 'hypnosis', 'deals 2 damage to the opponent', 0, 2, 0, 0, 0, 0),
('20', 'TEAPOT', 3, 'attack', 'skill', 'deals 3 damage to the opponent', 0, 3, 0, 0, 0, 0),
('21', 'FRYING PAN', 1, 'attack', 'skill', 'deals 1 damage to opponent', 0, 1, 0, 0, 0, 0),
('22', 'GARDEN SHEARS', 1, 'attack', 'skill', 'deals 2 damage to the opponent', 0, 2, 0, 0, 0, 0),
('23', 'FLASHLIGHT', 3, 'attack', 'skill', 'deals 3 damage to the opponent', 0, 3, 0, 0, 0, 0),
('24', 'SHARP TULIP', 2, 'attack', 'skill', 'deals 3 damage to the opponent', 0, 3, 0, 0, 0, 0),
('15', 'PINWHEEL', 2, 'attack', 'skill', 'deals 2 damage to the opponent', 0, 2, 0, 0, 0, 0),
('13', 'JACKS', 1, 'attack', 'weapon', 'deals 1 damage to the opponent', 0, 1, 0, 0, 0, 0),

('7', 'BRACELET', 1, 'defense', 'skill', 'increases defense by 1 point', 0, 0, 1, 0, 0, 0),
('17', 'GLASSES', 1, 'defense', 'skill', 'increases defense by 1 point', 0, 0, 1, 0, 0, 0),
('18', 'FRIENDSHIP BRACELET', 1, 'defense', 'skill', 'decreases the enemy defense by 1 point', 0, 0, 0, 0, 1, 0),
('19', 'PRETTY BOW', 2, 'defense', 'skill', 'decreases the enemy defense by 2 points', 0, 0, 0, 0, 2, 0),

('6', 'RABBIT FOOT', 1, 'support', 'skill', 'increases attack by 1 point', 0, 0, 0, 1, 0, 0),
('8', '4 LEAF CLOVER', 2, 'support', 'skill', 'increases attack by 2 points', 0, 0, 0, 2, 0, 0),
('9', '3 LEAF CLOVER', 3, 'support', 'snack', 'lowers enemy attack by 1 point', 0, 0, 0, 0, 0, 1),
('10', '5 LEAF CLOVER', 2, 'support', 'creature', 'lowers enemy attack by 2 points', 0, 0, 0, 0, 0, 2),
('16', 'WISHBONE', 3, 'support', 'skill', 'decreases the enemy attack by 2 points', 0, 0, 0, 0, 0, 2),

('14', 'SLEEP', 3, 'special', 'hypnosis', 'skips enemy turn', 0, 0, 0, 0, 0, 0);





-- ideas for cards
-- 24 cards minimum excluding characters
/*
4 healing cards
- cookie (+? health)
- bandage (+? health)
- wine
- apple

6 support cards
- 4 leaf clover (increases attack)
- friendship bracelet (increases defense)
- horse shoe (increases attack)
- dandelion
- seashell
- rabbit foot
- wedding ring
- wishbone

8 attack cards
----------weapons ()

- punch
- kick
- sword (is it a sword? or are you imagining it?)
- spoon
- matchbox
- fish
- rake
- shovel
- sythe
- teapot
- knife
 
 ----------creatures
- rat
- baby chicken
- beetle
- spider

 ----------hypnosis (3)
- sleep (enemy skips turn)
- fear (reduces enemy attack, increases his defense)

6 defense cards
All of these reduce damage taken
- hide (your opponent cant see you)
- stare (you've made your oponent uncomfortable and distracted!)
- mock (your opponent is embarrassed)
- block

