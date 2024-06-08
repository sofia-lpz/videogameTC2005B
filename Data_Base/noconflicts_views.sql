--1
create view player_team
select v.name, v.description, v.element from villager as v
join team as t on v.name = t.villager
join player as p on t.username = p.username;

--2
create view player_tcg_match
select m.matchId, m.timestamp, m.username, m.won from tcg_match as m
join player as p on m.username = p.username;

--3
create view player_stats
select s.username, s.most_used_card, s.most_used_villager, s.least_used_card, s.least_used_villager, s.found_objects 
from stats as s
join player as p 
on s.username = p.username;

--4
create view player_deck
select d.username, c.cardId, c.name, c.energy_cost, c.effect, c.type, c.description 
from deck as d
join card as c on d.cardId = c.cardId
join player as p on d.username = p.username;
