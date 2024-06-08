use colometa;

-- Create a stored procedure that will insert a new player into the player table
DELIMITER //
CREATE PROCEDURE insert_player(
    IN username VARCHAR(50),
    IN password VARCHAR(50),
    IN matches_won SMALLINT,
    IN level SMALLINT
)
BEGIN
    INSERT INTO player (username, password, matches_won, level) VALUES (username, password, matches_won, level);
END //

-- Create a stored procedure that will insert a new villager into the villager table
CREATE PROCEDURE add_card_to_deck(
    IN username VARCHAR(50),
    IN cardId SMALLINT
)
BEGIN
    INSERT INTO deck (username, cardId) VALUES (username, cardId);
END //

-- Create a stored procedure that will insert a new team into the team table
CREATE PROCEDURE update_player_stats(
    IN username VARCHAR(50),
    IN matches_won SMALLINT,
    IN level SMALLINT
)
BEGIN
    UPDATE player SET matches_won = matches_won, level = level WHERE username = username;
END //