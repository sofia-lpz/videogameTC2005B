USE colometa;
DROP EVENT IF EXISTS update_global_stats;
DROP EVENT IF EXISTS update_player_stats;

-- Create an event that will update player stats when a match ends
DELIMITER //

CREATE EVENT IF NOT EXISTS update_player_stats
ON SCHEDULE EVERY 1 MINUTE
DO
BEGIN
    UPDATE stats s
    JOIN tcg_match m ON s.username = m.username
    SET s.matches_won = s.matches_won + 1
    WHERE m.won = 1
    AND m.timestamp >= NOW() - INTERVAL 1 MINUTE;
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