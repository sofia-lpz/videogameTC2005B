use colometa;

insert into player (username, password, matches_won) values
('admin1', 'password1', 47),
('admin2', 'password2', 29),
('admin3', 'password3', 5),
('admin4', 'password4', 12),
('admin5', 'password5', 29),
('admin6', 'password6', 33),
('admin7', 'password7', 31),
('admin8', 'password8', 12),
('admin9', 'password9', 42),
('admin10', 'password10', 10);


insert into villager (name, description, element) values
('villager1', 'A brave fire warrior', 'fire'),
('villager2', 'A wise water mage', 'water'),
('villager3', 'An earth guardian', 'earth'),
('villager4', 'A mysterious snow rogue', 'snow'),
('villager5', 'A swift water scout', 'water'),
('villager6', 'A fire self healer', 'fire'),
('villager7', 'A snow warrior', 'snow'),
('villager8', 'A water healer', 'water'),
('villager9', 'A fire mage', 'fire'),
('villager10', 'A snow warrior', 'snow'),
('villager11', 'A water mage', 'water'),
('villager12', 'An earth warrior', 'earth'),
('villager13', 'A snow healer', 'snow'),
('villager14', 'A fire warrior', 'fire'),
('villager15', 'A water rogue', 'water'),
('villager16', 'An earth warrior', 'earth'),
('villager17', 'A snow warrior', 'snow'),
('villager18', 'A water warrior', 'water'),
('villager19', 'A fire warrior', 'fire'),
('villager20', 'An earth warrior', 'earth');


insert into stats (username, most_used_card, most_used_villager, least_used_card, least_used_villager, found_objects) values
('admin1', '9', 'villager4', '17', 'villager4', 0),
('admin2', '18', 'villager5', '13', 'villager4', 1),
('admin3', '15', 'villager3', '23', 'villager2', 8),
('admin4', '13', 'villager6', '19', 'villager5', 9),
('admin5', '2', 'villager2', '22', 'villager2', 18),
('admin6', '15', 'villager5', '1', 'villager3', 15),
('admin7', '17', 'villager6', '16', 'villager5', 5),
('admin8', '20', 'villager3', '9', 'villager3', 9),
('admin9', '3', 'villager6', '9', 'villager3', 1),
('admin10', '20', 'villager4', '17', 'villager2', 17),
('admin11', '15', 'villager3', '23', 'villager2', 8),
('admin12', '13', 'villager6', '19', 'villager5', 9),
('admin13', '2', 'villager2', '22', 'villager2', 18),
('admin14', '15', 'villager5', '1', 'villager3', 15),
('admin15', '17', 'villager6', '16', 'villager5', 5),
('admin16', '20', 'villager3', '9', 'villager3', 9),
('admin17', '3', 'villager6', '9', 'villager3', 1),
('admin18', '20', 'villager4', '17', 'villager2', 17),
('admin19', '15', 'villager3', '23', 'villager2', 8),
('admin20', '13', 'villager6', '19', 'villager5', 9),
('admin21', '2', 'villager2', '22', 'villager2', 18),
('admin22', '15', 'villager5', '1', 'villager3', 15),
('admin23', '17', 'villager6', '16', 'villager5', 5),
('admin24', '20', 'villager3', '9', 'villager3', 9),
('admin25', '3', 'villager6', '9', 'villager3', 1),
('admin26', '20', 'villager4', '17', 'villager2', 17),
('admin27', '15', 'villager3', '23', 'villager2', 8),
('admin28', '13', 'villager6', '19', 'villager5', 9),
('admin29', '2', 'villager2', '22', 'villager2', 18),
('admin30', '15', 'villager5', '1', 'villager3', 15);

insert into deck (username, cardId) values
('admin1', '3'),
('admin2', '21'),
('admin3', '15'),
('admin4', '20'),
('admin5', '2'),
('admin6', '9'),
('admin7', '7'),
('admin8', '11'),
('admin9', '4'),
('admin10', '5'),
('admin11', '6'),
('admin12', '8'),
('admin13', '10'),
('admin14', '12'),
('admin15', '14'),
('admin16', '16'),
('admin17', '18'),
('admin18', '19'),
('admin19', '1'),
('admin20', '13'),
('admin21', '17'),
('admin22', '22'),
('admin23', '23'),
('admin24', '24'),
('admin25', '3'),
('admin26', '21'),
('admin27', '15'),
('admin28', '20'),
('admin29', '2'),
('admin30', '9');


insert into card (cardId, name, energy_cost, effect, type, description) values
('1', 'plum juice', 3, 'healing', 'snack', 'drinking this grants 2 hp'),
('2', 'plum jam', 1, 'healing', 'snack', 'eating this grants 1 hp'),
('3', 'candy', 2, 'healing', 'snack', 'this candy grants 1 hp healing for 2 rounds'),
('4', 'bandage', 2, 'healing', 'skill', 'apply a bandage to receive 1 hp and remove effects'),
('5', 'glove', 3, 'support', 'skill', 'applies immunity to the element damage for 1 round'),
('6', '4 leaf clover', 1, 'support', 'skill', 'increases wind attack by 1 point'),
('7', 'friendship bracelet', 1, 'support', 'skill', 'increases defense by 1 point'),
('8', 'horse shoe', 2, 'support', 'skill', 'increases attack by 2 points'),
('9', 'chocolate', 3, 'support', 'snack', 'decreases the enemy accuracy for 1 round'),
('10', 'dog', 2, 'support', 'creature', 'increases accuracy for 1 round'),
('11', 'sword', 2, 'attack', 'weapon', 'deals 2 damage to your opponent'),
('12', 'fear', 3, 'attack', 'hypnosis', 'deals 1 damage to the opponent and increases defense by 1 point'),
('13', 'sharp stick', 1, 'attack', 'weapon', 'deals 1 damage to your opponent'),
('14', 'sleep', 2, 'attack', 'hypnosis', 'skips your opponents turn'),
('15', 'confusion', 2, 'attack', 'skill', 'deals 1 damage each turn for 2 turns'),
('16', 'mock', 1, 'attack', 'skill', 'decreases the enemy attack by 1 point'),
('17', 'hide', 2, 'defense', 'skill', 'decreases the enemy accuracy by 1 point'),
('18', 'stare', 1, 'defense', 'skill', 'decreases the enemy attack by 1 point'),
('19', 'block', 2, 'defense', 'skill', 'decreases the enemy attack by 2 points'),
('20', 'dandelion', 3, 'defense', 'skill', 'decreases the enemy attack by 3 points'),
('21', 'seashell', 2, 'defense', 'skill', 'decreases the enemy attack by 2 points'),
('22', 'rabbit foot', 1, 'defense', 'skill', 'decreases the enemy attack by 1 point'),
('23', 'wedding ring', 3, 'defense', 'skill', 'decreases the enemy attack by 3 points'),
('24', 'wishbone', 2, 'defense', 'skill', 'decreases the enemy attack by 2 points');


insert into team (username, villager) values
('admin1', 'villager3'),
('admin2', 'villager2'),
('admin3', 'villager6'),
('admin4', 'villager1'),
('admin5', 'villager4'),
('admin6', 'villager5'),
('admin7', 'villager4'),
('admin8', 'villager3'),
('admin9', 'villager1'),
('admin10', 'villager6');


insert into tcg_match (matchId, timestamp, username, won) values
(1, '2024-05-22 11:34:00', 'admin1', TRUE),
(2, '2024-05-22 15:29:00', 'admin2', FALSE),
(3, '2024-05-23 09:15:00', 'admin3', TRUE),
(4, '2024-05-23 14:45:00', 'admin4', TRUE),
(5, '2024-05-24 10:00:00', 'admin5', FALSE),
(6, '2024-05-24 16:30:00', 'admin1', FALSE),
(7, '2024-05-25 12:00:00', 'admin2', TRUE),
(8, '2024-05-25 17:30:00', 'admin3', TRUE),
(9, '2024-05-26 13:00:00', 'admin4', FALSE),
(10, '2024-05-26 18:45:00', 'admin5', FALSE),
(11, '2024-05-27 14:15:00', 'admin7', TRUE),
(12, '2024-05-27 19:30:00', 'admin2', TRUE),
(13, '2024-05-28 15:45:00', 'admin3', FALSE),
(14, '2024-05-28 20:00:00', 'admin6', FALSE),
(15, '2024-05-29 16:00:00', 'admin9', TRUE),
(16, '2024-05-29 21:30:00', 'admin8', TRUE),
(17, '2024-05-30 17:00:00', 'admin2', FALSE),
(18, '2024-05-30 22:45:00', 'admin2', FALSE),
(19, '2024-05-31 18:00:00', 'admin10', TRUE),
(20, '2024-05-31 23:15:00', 'admin5', TRUE),
(21, '2024-06-01 19:00:00', 'admin7', FALSE),
(22, '2024-06-01 23:59:00', 'admin2', FALSE),
(23, '2024-06-02 20:00:00', 'admin3', TRUE),
(24, '2024-06-02 22:45:00', 'admin2', TRUE);






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

