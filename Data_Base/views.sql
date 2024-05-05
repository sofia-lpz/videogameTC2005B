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