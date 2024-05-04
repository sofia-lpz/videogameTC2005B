DROP DATABASE IF EXISTS colometa;
create database colometa;
use colometa;

create table player(
    username varchar(50) NOT NULL DEFAULT 'name',
    password varchar(50) NOT NULL DEFAULT 'password',
    matches_won SMALLINT NOT NULL DEFAULT 0,
    primary key (username)
); engine=myisam DEFAULT CHARSET=utf8mb4;

create table villager(
    name varchar(50) NOT NULL,
    description varchar(100) NOT NULL,
    primary key (name)
); engine=myisam DEFAULT CHARSET=utf8mb4;

create table team(
    username varchar(50) NOT NULL,
    villager varchar(50) NOT NULL,
    primary key (username, villager),
);

create table card(
    cardId varchar(15) NOT NULL DEFAULT 'card' AUTO_INCREMENT,
    name varchar(50) NOT NULL,
    energy_cost SMALLINT NOT NULL,
    effect enum ('healing', 'attack', 'defense', 'support') NOT NULL,
    type enum ('creature', 'hypnosis', 'snack', 'weapon', 'tool', 'skill') NOT NULL,
    description varchar(100) NOT NULL,
    dialogue varchar(100) NOT NULL, 
    --dialogue to display when card is used (for example, "you've made your opponent uncomfortable!")

    self_health SMALL INT NOT NULL DEFAULT 0, --set this to positive if its healing
    oponent_health SMALL INT NOT NULL DEFAULT 0, --set this to negative if its attack
    defense SMALL INT NOT NULL DEFAULT 0, --set this to positive if its defense
    luck SMALL INT NOT NULL DEFAULT 0, --set this to positive if its support
    foreign key (effect) references effect(effectId), --can be null
    primary key (cardId)
    key (energy_cost)
); engine=myisam DEFAULT CHARSET=utf8mb4;

create table effect( --used particularly by hypnosis cards
    effectId varchar(15) NOT NULL DEFAULT 'effect' AUTO_INCREMENT,
    ame enum ('chicken', 'sleep', 'confusion'),
    description varchar(100) NOT NULL,
    -- how to add if its sleep, enemy skips turn with trigger? <---
    accuracy SMALLINT NOT NULL DEFAULT 0, --decrease enemy accuracy by this many points
    attack_decrease SMALLINT NOT NULL DEFAULT 0, --decrease enemy attack by this many points
    defense_decrease SMALLINT NOT NULL DEFAULT 0, --decrease enemy defense by this many points
    primary key (effectId)

); engine=myisam DEFAULT CHARSET=utf8mb4;

create table match(
matchId varchar(15) NOT NULL DEFAULT 'match' AUTO_INCREMENT,
timestamp timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
player varchar(50) NOT NULL,
-- add player health?
-- add card used by player?
-- add number of turns?
won boolean NOT NULL,
primary key (matchId)
foreign key (player1) references player(username),
); engine= InnoDB DEFAULT CHARSET=utf8mb4;

create table stats();
--save stats here after match for stats page

create table deck(
    player varchar(50) NOT NULL,
    card varchar(15) NOT NULL,
    primary key (player, card),
    foreign key (player) references player(username),
    foreign key (card) references card(cardId)
); engine=myisam DEFAULT CHARSET=utf8mb4;

create table dialogue(
    dialogueId varchar(15) NOT NULL DEFAULT 'dialogue' AUTO_INCREMENT,
    speaker varchar(50) NOT NULL, 
    text varchar(200) NOT NULL,
    primary key (dialogueId, speaker),
); engine=myisam DEFAULT CHARSET=utf8mb4;

