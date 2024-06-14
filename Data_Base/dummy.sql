-- DO NOT USE THIS DUMMY DATA
-- USE final_data.sql INSTEAD

-- Inserting data into player table
INSERT INTO player (username, password) VALUES 
('player1', 'password1'), ('player2', 'password2'), ('player3', 'password3'), 
('player4', 'password4'), ('player5', 'password5'), ('player6', 'password6'), 
('player7', 'password7'), ('player8', 'password8'), ('player9', 'password9'), 
('player10', 'password10'), ('player11', 'password11'), ('player12', 'password12'), 
('player13', 'password13'), ('player14', 'password14'), ('player15', 'password15'), 
('player16', 'password16'), ('player17', 'password17'), ('player18', 'password18'), 
('player19', 'password19'), ('player20', 'password20'), ('player21', 'password21'), 
('player22', 'password22'), ('player23', 'password23'), ('player24', 'password24'), 
('player25', 'password25'), ('player26', 'password26'), ('player27', 'password27'), 
('player28', 'password28'), ('player29', 'password29'), ('player30', 'password30');

-- Inserting data into villager table
INSERT INTO villager (name, description, element) VALUES 
('Villager1', 'Description1', 'Reason'), ('Villager2', 'Description2', 'Dream'), 
('Villager3', 'Description3', 'Terror'), ('Villager4', 'Description4', 'Reason'), 
('Villager5', 'Description5', 'Dream'), ('Villager6', 'Description6', 'Terror'), 
('Villager7', 'Description7', 'Reason'), ('Villager8', 'Description8', 'Dream'), 
('Villager9', 'Description9', 'Terror'), ('Villager10', 'Description10', 'Reason'), 
('Villager11', 'Description11', 'Dream'), ('Villager12', 'Description12', 'Terror'), 
('Villager13', 'Description13', 'Reason'), ('Villager14', 'Description14', 'Dream'), 
('Villager15', 'Description15', 'Terror'), ('Villager16', 'Description16', 'Reason'), 
('Villager17', 'Description17', 'Dream'), ('Villager18', 'Description18', 'Terror'), 
('Villager19', 'Description19', 'Reason'), ('Villager20', 'Description20', 'Dream'), 
('Villager21', 'Description21', 'Terror'), ('Villager22', 'Description22', 'Reason'), 
('Villager23', 'Description23', 'Dream'), ('Villager24', 'Description24', 'Terror'), 
('Villager25', 'Description25', 'Reason'), ('Villager26', 'Description26', 'Dream'), 
('Villager27', 'Description27', 'Terror'), ('Villager28', 'Description28', 'Reason'), 
('Villager29', 'Description29', 'Dream'), ('Villager30', 'Description30', 'Terror');

-- Inserting data into card table
INSERT INTO card (name, energy_cost, effect, type, description, player_health, player_attack, player_defense, player_support, enemy_defense, enemy_attack) VALUES 
('Card1', 1, 'healing', 'creature', 'Description1', 10, 0, 0, 0, 0, 0), 
('Card2', 2, 'attack', 'hypnosis', 'Description2', 0, 5, 0, 0, 0, 3), 
('Card3', 3, 'defense', 'snack', 'Description3', 0, 0, 5, 0, 2, 0), 
('Card4', 1, 'support', 'weapon', 'Description4', 0, 0, 0, 3, 0, 0), 
('Card5', 2, 'special', 'skill', 'Description5', 0, 0, 0, 0, 0, 0), 
('Card6', 1, 'healing', 'creature', 'Description6', 15, 0, 0, 0, 0, 0), 
('Card7', 2, 'attack', 'hypnosis', 'Description7', 0, 6, 0, 0, 0, 4), 
('Card8', 3, 'defense', 'snack', 'Description8', 0, 0, 6, 0, 3, 0), 
('Card9', 1, 'support', 'weapon', 'Description9', 0, 0, 0, 4, 0, 0), 
('Card10', 2, 'special', 'skill', 'Description10', 0, 0, 0, 0, 0, 0), 
('Card11', 1, 'healing', 'creature', 'Description11', 20, 0, 0, 0, 0, 0), 
('Card12', 2, 'attack', 'hypnosis', 'Description12', 0, 7, 0, 0, 0, 5), 
('Card13', 3, 'defense', 'snack', 'Description13', 0, 0, 7, 0, 4, 0), 
('Card14', 1, 'support', 'weapon', 'Description14', 0, 0, 0, 5, 0, 0), 
('Card15', 2, 'special', 'skill', 'Description15', 0, 0, 0, 0, 0, 0), 
('Card16', 1, 'healing', 'creature', 'Description16', 25, 0, 0, 0, 0, 0), 
('Card17', 2, 'attack', 'hypnosis', 'Description17', 0, 8, 0, 0, 0, 6), 
('Card18', 3, 'defense', 'snack', 'Description18', 0, 0, 8, 0, 5, 0), 
('Card19', 1, 'support', 'weapon', 'Description19', 0, 0, 0, 6, 0, 0), 
('Card20', 2, 'special', 'skill', 'Description20', 0, 0, 0, 0, 0, 0), 
('Card21', 1, 'healing', 'creature', 'Description21', 30, 0, 0, 0, 0, 0), 
('Card22', 2, 'attack', 'hypnosis', 'Description22', 0, 9, 0, 0, 0, 7), 
('Card23', 3, 'defense', 'snack', 'Description23', 0, 0, 9, 0, 6, 0), 
('Card24', 1, 'support', 'weapon', 'Description24', 0, 0, 0, 7, 0, 0), 
('Card25', 2, 'special', 'skill', 'Description25', 0, 0, 0, 0, 0, 0), 
('Card26', 1, 'healing', 'creature', 'Description26', 35, 0, 0, 0, 0, 0), 
('Card27', 2, 'attack', 'hypnosis', 'Description27', 0, 10, 0, 0, 0, 8), 
('Card28', 3, 'defense', 'snack', 'Description28', 0, 0, 10, 0, 7, 0), 
('Card29', 1, 'support', 'weapon', 'Description29', 0, 0, 0, 8, 0, 0), 
('Card30', 2, 'special', 'skill', 'Description30', 0, 0, 0, 0, 0, 0);

-- Inserting data into tcg_match table
INSERT INTO tcg_match (username, won) VALUES 
('player1', TRUE), ('player2', FALSE), ('player3', TRUE), 
('player4', FALSE), ('player5', TRUE), ('player6', FALSE), 
('player7', TRUE), ('player8', FALSE), ('player9', TRUE), 
('player10', FALSE), ('player11', TRUE), ('player12', FALSE), 
('player13', TRUE), ('player14', FALSE), ('player15', TRUE), 
('player16', FALSE), ('player17', TRUE), ('player18', FALSE), 
('player19', TRUE), ('player20', FALSE), ('player21', TRUE), 
('player22', FALSE), ('player23', TRUE), ('player24', FALSE), 
('player25', TRUE), ('player26', FALSE), ('player27', TRUE), 
('player28', FALSE), ('player29', TRUE), ('player30', FALSE);

-- Inserting data into card_use table
INSERT INTO card_use (cardId, username, times_used) VALUES 
(1, 'player1', 5), (2, 'player2', 10), (3, 'player3', 15), 
(4, 'player4', 20), (5, 'player5', 25), (6, 'player6', 30), 
(7, 'player7', 35), (8, 'player8', 40), (9, 'player9', 45), 
(10, 'player10', 50), (11, 'player11', 55), (12, 'player12', 60), 
(13, 'player13', 65), (14, 'player14', 70), (15, 'player15', 75), 
(16, 'player16', 80), (17, 'player17', 85), (18, 'player18', 90), 
(19, 'player19', 95), (20, 'player20', 100), (21, 'player21', 105), 
(22, 'player22', 110), (23, 'player23', 115), (24, 'player24', 120), 
(25, 'player25', 125), (26, 'player26', 130), (27, 'player27', 135), 
(28, 'player28', 140), (29, 'player29', 145), (30, 'player30', 150);

-- Inserting data into villager_use table
INSERT INTO villager_use (villager_id, username, times_used) VALUES 
(1, 'player1', 3), (2, 'player2', 6), (3, 'player3', 9), 
(4, 'player4', 12), (5, 'player5', 15), (6, 'player6', 18), 
(7, 'player7', 21), (8, 'player8', 24), (9, 'player9', 27), 
(10, 'player10', 30), (11, 'player11', 33), (12, 'player12', 36), 
(13, 'player13', 39), (14, 'player14', 42), (15, 'player15', 45), 
(16, 'player16', 48), (17, 'player17', 51), (18, 'player18', 54), 
(19, 'player19', 57), (20, 'player20', 60), (21, 'player21', 63), 
(22, 'player22', 66), (23, 'player23', 69), (24, 'player24', 72), 
(25, 'player25', 75), (26, 'player26', 78), (27, 'player27', 81), 
(28, 'player28', 84), (29, 'player29', 87), (30, 'player30', 90);

-- Inserting data into stats table
INSERT INTO stats (username, most_used_card, most_used_villager, least_used_card, least_used_villager, memories_found, matches_won, total_matches_played) VALUES 
('player1', 'Card1', 'Villager1', 'Card30', 'Villager30', 1, 1, 1), 
('player2', 'Card2', 'Villager2', 'Card29', 'Villager29', 2, 0, 1), 
('player3', 'Card3', 'Villager3', 'Card28', 'Villager28', 3, 1, 1), 
('player4', 'Card4', 'Villager4', 'Card27', 'Villager27', 4, 0, 1), 
('player5', 'Card5', 'Villager5', 'Card26', 'Villager26', 5, 1, 1), 
('player6', 'Card6', 'Villager6', 'Card25', 'Villager25', 6, 0, 1), 
('player7', 'Card7', 'Villager7', 'Card24', 'Villager24', 7, 1, 1), 
('player8', 'Card8', 'Villager8', 'Card23', 'Villager23', 8, 0, 1), 
('player9', 'Card9', 'Villager9', 'Card22', 'Villager22', 9, 1, 1), 
('player10', 'Card10', 'Villager10', 'Card21', 'Villager21', 10, 0, 1), 
('player11', 'Card11', 'Villager11', 'Card20', 'Villager20', 11, 1, 1), 
('player12', 'Card12', 'Villager12', 'Card19', 'Villager19', 12, 0, 1), 
('player13', 'Card13', 'Villager13', 'Card18', 'Villager18', 13, 1, 1), 
('player14', 'Card14', 'Villager14', 'Card17', 'Villager17', 14, 0, 1), 
('player15', 'Card15', 'Villager15', 'Card16', 'Villager16', 15, 1, 1), 
('player16', 'Card16', 'Villager16', 'Card15', 'Villager15', 16, 0, 1), 
('player17', 'Card17', 'Villager17', 'Card14', 'Villager14', 17, 1, 1), 
('player18', 'Card18', 'Villager18', 'Card13', 'Villager13', 18, 0, 1), 
('player19', 'Card19', 'Villager19', 'Card12', 'Villager12', 19, 1, 1), 
('player20', 'Card20', 'Villager20', 'Card11', 'Villager11', 20, 0, 1), 
('player21', 'Card21', 'Villager21', 'Card10', 'Villager10', 21, 1, 1), 
('player22', 'Card22', 'Villager22', 'Card9', 'Villager9', 22, 0, 1), 
('player23', 'Card23', 'Villager23', 'Card8', 'Villager8', 23, 1, 1), 
('player24', 'Card24', 'Villager24', 'Card7', 'Villager7', 24, 0, 1), 
('player25', 'Card25', 'Villager25', 'Card6', 'Villager6', 25, 1, 1), 
('player26', 'Card26', 'Villager26', 'Card5', 'Villager5', 26, 0, 1), 
('player27', 'Card27', 'Villager27', 'Card4', 'Villager4', 27, 1, 1), 
('player28', 'Card28', 'Villager28', 'Card3', 'Villager3', 28, 0, 1), 
('player29', 'Card29', 'Villager29', 'Card2', 'Villager2', 29, 1, 1), 
('player30', 'Card30', 'Villager30', 'Card1', 'Villager1', 30, 0, 1);

-- Inserting data into global_stats table
INSERT INTO global_stats (most_used_card, most_used_villager, least_used_card, least_used_villager, memories_found_avg) VALUES 
(1, 1, 30, 30, 5), 
(2, 2, 29, 29, 6), 
(3, 3, 28, 28, 7), 
(4, 4, 27, 27, 8), 
(5, 5, 26, 26, 9), 
(6, 6, 25, 25, 10), 
(7, 7, 24, 24, 11), 
(8, 8, 23, 23, 12), 
(9, 9, 22, 22, 13), 
(10, 10, 21, 21, 14), 
(11, 11, 20, 20, 15), 
(12, 12, 19, 19, 16), 
(13, 13, 18, 18, 17), 
(14, 14, 17, 17, 18), 
(15, 15, 16, 16, 19), 
(16, 16, 15, 15, 20), 
(17, 17, 14, 14, 21), 
(18, 18, 13, 13, 22), 
(19, 19, 12, 12, 23), 
(20, 20, 11, 11, 24), 
(21, 21, 10, 10, 25), 
(22, 22, 9, 9, 26), 
(23, 23, 8, 8, 27), 
(24, 24, 7, 7, 28), 
(25, 25, 6, 6, 29), 
(26, 26, 5, 5, 30), 
(27, 27, 4, 4, 31), 
(28, 28, 3, 3, 32), 
(29, 29, 2, 2, 33), 
(30, 30, 1, 1, 34);
