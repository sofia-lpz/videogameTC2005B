use colometa;

CREATE VIEW villager_use_view AS
SELECT villager.name, SUM(villager_use.times_used) as total_used 
FROM villager_use 
INNER JOIN villager ON villager_use.villager_id = villager.villager_id 
GROUP BY villager.name;

CREATE VIEW card_use_view AS
SELECT card.name, SUM(card_use.times_used) as total_used 
FROM card_use 
INNER JOIN card ON card_use.cardId = card.cardId 
GROUP BY card.name;

CREATE VIEW player_cards AS
SELECT player.username, card.name
FROM card_use
JOIN player ON card_use.username = player.username
JOIN card ON card_use.cardId = card.cardId;

CREATE VIEW player_villagers AS
SELECT player.username, villager.name
FROM villager_use
JOIN player ON villager_use.username = player.username
JOIN villager ON villager_use.villager_id = villager.villager_id;

CREATE VIEW player_most_used_card AS
SELECT stats.username, card.name AS most_used_card
FROM stats
JOIN card ON stats.most_used_card = card.cardId;

CREATE VIEW player_least_used_card AS
SELECT stats.username, card.name AS least_used_card
FROM stats
JOIN card ON stats.least_used_card = card.cardId;

CREATE VIEW player_most_used_villager AS
SELECT stats.username, villager.name AS most_used_villager
FROM stats
JOIN villager ON stats.most_used_villager = villager.villager_id;

CREATE VIEW player_least_used_villager AS
SELECT stats.username, villager.name AS least_used_villager
FROM stats
JOIN villager ON stats.least_used_villager = villager.villager_id;

CREATE VIEW average_memories_found AS
SELECT AVG(memories_found) AS avg_memories_found
FROM stats;

CREATE VIEW player_matches_won AS
SELECT username, COUNT(won) AS matches_won
FROM tcg_match
WHERE won = 1
GROUP BY username;

DELIMITER //
CREATE TRIGGER update_player_stats
AFTER INSERT ON tcg_match
FOR EACH ROW
BEGIN
    UPDATE stats SET matches_won = matches_won + 1 WHERE username = NEW.username;
END //
DELIMITER ;

DELIMITER //
CREATE TRIGGER update_total_cards_used
AFTER INSERT ON card_use
FOR EACH ROW
BEGIN
    UPDATE stats 
    SET total_cards_used = total_cards_used + 1 
    WHERE username = NEW.username;
END //
DELIMITER ;

DELIMITER //
CREATE TRIGGER create_stats
AFTER INSERT ON player
FOR EACH ROW
BEGIN
    INSERT INTO stats (username) VALUES (NEW.username);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE delete_villager_use(
    IN p_villager_id SMALLINT,
    IN p_username VARCHAR(50)
)
BEGIN
    DELETE FROM villager_use WHERE villager_id = p_villager_id AND username = p_username;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE insert_villager_use(
    IN p_username VARCHAR(50),
    IN p_villager_id SMALLINT,
    IN p_times_used SMALLINT
)
BEGIN
    INSERT INTO villager_use (username, villager_id, times_used) VALUES (p_username, p_villager_id, p_times_used);
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE delete_card_use(
    IN p_cardId SMALLINT,
    IN p_username VARCHAR(50)
)
BEGIN
    DELETE FROM card_use WHERE cardId = p_cardId AND username = p_username;
END //
DELIMITER ;

DELIMITER //
CREATE PROCEDURE insert_card_use(
    IN p_username VARCHAR(50),
    IN p_cardId SMALLINT,
    IN p_times_used SMALLINT
)
BEGIN
    INSERT INTO card_use (username, cardId, times_used) VALUES (p_username, p_cardId, p_times_used);
END //
DELIMITER ;

-- Create event that will update global stats everyday
DELIMITER //

CREATE EVENT IF NOT EXISTS update_global_stats
ON SCHEDULE EVERY 1 DAY
DO
BEGIN
    DECLARE most_used_card_id SMALLINT;
    DECLARE least_used_card_id SMALLINT;
    DECLARE most_used_villager_id SMALLINT;
    DECLARE least_used_villager_id SMALLINT;
    DECLARE avg_memories_found SMALLINT;

    -- Find most used card
    SELECT cardId INTO most_used_card_id
    FROM card_use
    GROUP BY cardId
    ORDER BY SUM(times_used) DESC
    LIMIT 1;

    -- Find least used card
    SELECT cardId INTO least_used_card_id
    FROM card_use
    GROUP BY cardId
    ORDER BY SUM(times_used) ASC
    LIMIT 1;

    -- Find most used villager
    SELECT villager_id INTO most_used_villager_id
    FROM villager_use
    GROUP BY villager_id
    ORDER BY SUM(times_used) DESC
    LIMIT 1;

    -- Find least used villager
    SELECT villager_id INTO least_used_villager_id
    FROM villager_use
    GROUP BY villager_id
    ORDER BY SUM(times_used) ASC
    LIMIT 1;

    -- Calculate average memories found
    SELECT AVG(memories_found) INTO avg_memories_found
    FROM stats;

    -- Update global stats
    UPDATE global_stats
    SET most_used_card = most_used_card_id,
        least_used_card = least_used_card_id,
        most_used_villager = most_used_villager_id,
        least_used_villager = least_used_villager_id,
        memories_found_avg = avg_memories_found
    WHERE global_stats_id = 1;
END //

DELIMITER ;

DELIMITER //
CREATE EVENT IF NOT EXISTS update_total_matches_played
ON SCHEDULE EVERY 1 DAY
DO
BEGIN
    UPDATE stats s
    JOIN (
        SELECT username, COUNT(*) as total_matches
        FROM tcg_match
        GROUP BY username
    ) m ON s.username = m.username
    SET s.total_matches_played = m.total_matches;
END //
DELIMITER ;