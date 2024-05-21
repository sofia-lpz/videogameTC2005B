use colometa;

--VIEWS

CREATE VIEW PlayerWins AS
SELECT username AS player, COUNT(*) AS Wins
FROM tcg_match
WHERE won = true
GROUP BY username;

CREATE VIEW PlayerDeck AS
SELECT d.player, GROUP_CONCAT(d.cardId) AS Cards
FROM deck AS d
GROUP BY d.player;

CREATE VIEW PlayerTeam AS
SELECT t.username AS player, GROUP_CONCAT(t.villager) AS Team
FROM team AS t
GROUP BY t.username;

CREATE VIEW PlayerStats AS
SELECT s.player, s.most_used_card, s.most_used_villager, s.least_used_card, s.least_used_villager, s.found_objects
FROM stats AS s;

CREATE VIEW PlayerMatches AS
SELECT username AS player, COUNT(*) AS Matches
FROM tcg_match
GROUP BY username;

--TRIGGERS
DELIMITER //

CREATE TRIGGER update_wins
AFTER INSERT ON tcg_match
FOR EACH ROW
BEGIN
    IF NEW.won = true THEN
        UPDATE player
        SET matches_won = matches_won + 1
        WHERE username = NEW.username;
    END IF;
END //


-- after win, add the npc card to the player's deck 'npc_card_id' missing
CREATE TRIGGER update_deck
AFTER INSERT ON tcg_match
FOR EACH ROW
BEGIN
    IF NEW.won = true THEN
        INSERT INTO deck (player, cardId)
        VALUES (NEW.username, 'npc_card_id');
    END IF;
END //


