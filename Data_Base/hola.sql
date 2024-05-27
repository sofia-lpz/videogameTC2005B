-- Dummy data for player table
INSERT INTO player (username, password, matches_won) VALUES
('player1', 'password1', 3),
('player2', 'password2', 5),
('player3', 'password3', 2);

-- Dummy data for villager table
INSERT INTO villager (name, description, element) VALUES
('Villager1', 'Description 1', 'Reason'),
('Villager2', 'Description 2', 'Dream'),
('Villager3', 'Description 3', 'Terror');

-- Dummy data for team table
INSERT INTO team (username, villager) VALUES
('player1', 'Villager1'),
('player1', 'Villager2'),
('player2', 'Villager3');

-- Dummy data for card table
INSERT INTO card (name, energy_cost, effect, type, description, player_health, player_attack, player_defense, player_support, enemy_defense) VALUES
('hola luis', 2, 'attack', 'creature', 'Description 1', 2, 5, 0, 0, 0),
('holaluis', 3, 'defense', 'skill', 'Description 2', 0, 3, 5, 0, 0),
('soy yo', 1, 'support', 'snack', 'Description 3', 0, 4, 0, 5, 0);

-- Dummy data for tcg_match table
INSERT INTO tcg_match (timestamp, username, won) VALUES
('2022-01-01 10:00:00', 'player1', true),
('2022-01-02 15:30:00', 'player2', false),
('2022-01-03 12:45:00', 'player3', true);

-- Dummy data for stats table
INSERT INTO stats (username, most_used_card, most_used_villager, least_used_card, least_used_villager, found_objects) VALUES
('player1', 'Card1', 'Villager1', 'Card2', 'Villager2', 10),
('player2', 'Card3', 'Villager3', 'Card1', 'Villager1', 5),
('player3', 'Card2', 'Villager2', 'Card3', 'Villager3', 8);

-- Dummy data for deck table
INSERT INTO deck (username, cardId) VALUES
('player1', 'Card1'),
('player1', 'Card2'),
('player2', 'Card3');