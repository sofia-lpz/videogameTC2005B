use colometa;

CREATE VIEW PlayerWins AS
SELECT player, COUNT(*) as Wins
FROM match
WHERE won = true
GROUP BY player;

CREATE VIEW PlayerDeck AS
SELECT player, GROUP_CONCAT(card) as Cards
FROM deck
GROUP BY player;

CREATE VIEW PlayerTeam AS
SELECT player, GROUP_CONCAT(villager) as Team
FROM team
GROUP BY player;

CREATE VIEW PlayerStats AS
SELECT player, most_used_card, most_used_villager, least_used_card, least_used_villager, found_objects
FROM stats
GROUP BY player;

CREATE VIEW PlayerMatches AS
SELECT player, COUNT(*) as Matches
FROM match
GROUP BY player;

CREATE VIEW VillagerTeam AS
--which players are teammates with each villager
SELECT villager, GROUP_CONCAT(player) as Team


create trigger update_wins
after insert on match
for each row
begin
    if new.won = true then
        update player
        set matches_won = matches_won + 1
        where username = new.player;
    end if;
end;

create trigger update_deck
-- after win, add the npc card to the player's deck

create trigger card_dialogue
-- after card is used, display the dialogue