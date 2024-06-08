USE colometa;

-- Create a trigger that will update the player stats when a match is won
DELIMITER //
CREATE TRIGGER update_player_stats
AFTER INSERT ON tcg_match
FOR EACH ROW
BEGIN
    UPDATE player SET matches_won = matches_won + 1 WHERE username = NEW.username;
END //
DELIMITER ;
