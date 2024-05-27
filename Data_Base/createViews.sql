CREATE VIEW PlayerInfo AS
SELECT username, matches_won
FROM player;

CREATE VIEW PlayerVillagers AS
SELECT p.username, v.name AS villager_name, v.description, v.element
FROM player p
JOIN team t ON p.username = t.username
JOIN villager v ON t.villager = v.name;

CREATE VIEW PlayerCards AS
SELECT p.username, c.cardId, c.name AS card_name, c.energy_cost, c.effect, c.type, c.description
FROM player p
JOIN deck d ON p.username = d.username
JOIN card c ON d.cardId = c.cardId;

CREATE VIEW PlayerCardStats AS
SELECT s.username, s.most_used_card, s.least_used_card, s.found_objects
FROM stats s;

CREATE VIEW PlayerVillagerStats AS
SELECT s.username, s.most_used_villager, s.least_used_villager
FROM stats s;

CREATE VIEW MatchHistory AS
SELECT m.matchId, m.timestamp, m.username, m.won
FROM tcg_match m;

CREATE VIEW AttackCards AS
SELECT c.cardId, c.name AS card_name, c.energy_cost, c.effect, c.type, c.description
FROM card c
WHERE c.effect = 'attack';

CREATE VIEW DefenseCards AS
SELECT c.cardId, c.name AS card_name, c.energy_cost, c.effect, c.type, c.description
FROM card c
WHERE c.effect = 'defense';

CREATE VIEW DetailedCardInfo AS
SELECT c.cardId, c.name AS card_name, c.energy_cost, c.effect, c.type, c.description, 
       c.player_health, c.player_attack, c.player_defense, c.player_support, c.enemy_defense
FROM card c;

CREATE VIEW PlayerDeckAndVillagers AS
SELECT p.username, d.cardId, c.name AS card_name, v.name AS villager_name
FROM player p
JOIN deck d ON p.username = d.username
JOIN card c ON d.cardId = c.cardId
JOIN team t ON p.username = t.username
JOIN villager v ON t.villager = v.name;


SELECT * FROM PlayerInfo;

SELECT * FROM PlayerVillagers;

SELECT * FROM PlayerCards;

SELECT * FROM PlayerCardStats;

SELECT * FROM PlayerVillagerStats;

SELECT * FROM MatchHistory;

SELECT * FROM AttackCards;

SELECT * FROM DefenseCards;

SELECT * FROM DetailedCardInfo;

SELECT * FROM PlayerDeckAndVillagers;
