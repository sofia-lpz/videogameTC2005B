use colometa;

insert into player (username, password, matches_won, level) values
('player', 'admin', 0, 0);



insert into villager (name, description, element) values
("Cat", "Its your cat!", "Reason"),
('Terror', 'Terror', 'Terror'),
('Sheep', 'A random sheep that escaped from a farm. Not very interested in going back', 'ennui'),
('Dream', 'Dream', 'Dream');

insert into stats (username, most_used_card, most_used_villager, least_used_card, least_used_villager, found_objects) values
('player', '9', 'Cat', '17', 'Cat', 0);

insert into deck (username, cardId) values
('player', '3');


insert into card (cardId, name, energy_cost, effect, type, description, player_health, player_attack, player_defense, player_support, enemy_defense, enemy_attack) values
('1', 'plum juice', 3, 'healing', 'snack', 'drinking this grants 3 hp', 3, 0, 0, 0, 0, 0),
('2', 'plum jam', 1, 'healing', 'snack', 'eating this grants 1 hp', 1, 0, 0, 0, 0, 0),
('3', 'candy', 2, 'healing', 'snack', 'this candy grants 2 hp', 2, 0, 0, 0, 0, 0),
('4', 'bandage', 3, 'healing', 'skill', 'apply bansage and heal your both characters 2 hp', 2, 0, 0, 0, 0, 0),
('5', 'glove', 3, 'support', 'skill', 'applies increases defense by 3 points', 0, 0, 3, 0, 0, 0),
('6', '4 leaf clover', 1, 'support', 'skill', 'increases attack by 1 point', 0, 0, 0, 1, 0, 0),
('7', 'friendship bracelet', 1, 'support', 'skill', 'increases defense by 1 point', 0, 0, 1, 0, 0, 0),
('8', 'horse shoe', 2, 'support', 'skill', 'increases attack by 2 points', 0, 0, 0, 2, 0, 0),
('9', 'chocolate', 3, 'support', 'snack', 'lowers enemy defense by 1 point', 0, 0, 0, 0, 1, 0),
('10', 'dog', 2, 'support', 'creature', 'lowers enemy defense by 2 points', 0, 0, 0, 0, 2, 0),
('11', 'sword', 2, 'attack', 'weapon', 'deals 2 damage to your opponent', 0, 2, 0, 0, 0, 0),
('12', 'fear', 3, 'attack', 'hypnosis', 'deals 1 damage to the opponent and increases defense by 1 point', 0, 1, 1, 0, 0, 0),
('13', 'sharp stick', 1, 'attack', 'weapon', 'deals 1 damage to your opponent', 0, 1, 0, 0, 0, 0),
('14', 'sleep', 2, 'attack', 'hypnosis', 'skips your opponents turn', 0, 0, 0, 0, 0, 0),
('15', 'confusion', 2, 'attack', 'skill', 'deals 2 damage to your opponent', 0, 2, 0, 0, 0, 0),
('16', 'mock', 3, 'attack', 'skill', 'decreases the enemy attack by 2 points', 0, 0, 0, 0, 0, 2),
('17', 'hide', 1, 'defense', 'skill', 'increases defense by 1 point', 0, 0, 1, 0, 0, 0),
('18', 'stare', 1, 'defense', 'skill', 'decreases the enemy attack by 1 point', 0, 0, 0, 0, 0, 1),
('19', 'block', 2, 'defense', 'skill', 'decreases the enemy attack by 2 points', 0, 0, 0, 0, 0, 2),
('20', 'dandelion', 3, 'attack', 'skill', 'deals 3 damage points to opponent', 0, 3, 0, 0, 0, 0),
('21', 'seashell', 1, 'attack', 'skill', 'deals 1 damage to opponent', 0, 1, 0, 0, 0, 0),
('22', 'rabbit foot', 1, 'healing', 'skill', 'heals 1 health point', 1, 0, 0, 0, 0, 0),
('23', 'wedding ring', 3, 'healing', 'skill', 'heals 2 health points', 2, 0, 0, 0, 0, 0),
('24', 'wishbone', 2, 'attack', 'skill', 'deals 3 damage', 0, 3, 0, 0, 0, 0);


insert into team (username, villager) values
('player', 'Cat');


insert into tcg_match (matchId, timestamp, username, won) values
(1, '2024-05-22 11:34:00', 'player', TRUE);






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

