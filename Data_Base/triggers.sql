USE colometa;

-- Create a trigger that will update the player stats when a match is won
DELIMITER //
CREATE TRIGGER update_player_stats
AFTER INSERT ON tcg_match
FOR EACH ROW
BEGIN
    UPDATE stats SET matches_won = matches_won + 1 WHERE username = NEW.username;
END //
DELIMITER ;

-- Create an empty stats table for each player

DELIMITER //
CREATE TRIGGER create_stats
AFTER INSERT ON player
FOR EACH ROW
BEGIN
    INSERT INTO stats (username) VALUES (NEW.username);
END //
DELIMITER ;
