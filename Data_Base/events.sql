USE colometa;
DROP EVENT IF EXISTS update_global_stats;



-- Create event that will update global stats everyday
DELIMITER //
CREATE EVENT IF NOT EXISTS update_global_stats
ON SCHEDULE EVERY 1 DAY
STARTS CURRENT_DATE + INTERVAL 1 DAY;
DO
BEGIN
    DECLARE avg_memories_found SMALLINT;

    --Calculate average memories found
    SELECT AVG(memories_found) INTO avg_memories_found FROM stats;

    --Update global stats
    UPDATE global_stats
    SET
        most_used_card = (SELECT most_used_card FROM stats GROUP BY most_used_card ORDER BY COUNT(*) DESC LIMIT 1),
        most_used_villager = (SELECT most_used_villager FROM stats GROUP BY most_used_villager ORDER BY COUNT(*) DESC LIMIT 1),
        least_used_card = (SELECT least_used_card FROM stats GROUP BY least_used_card ORDER BY COUNT(*) ASC LIMIT 1),
        least_used_villager = (SELECT least_used_villager FROM stats GROUP BY least_used_villager ORDER BY COUNT(*) ASC LIMIT 1),
        memories_found_avg = avg_memories_found;
END //