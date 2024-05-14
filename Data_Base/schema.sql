DROP schema IF EXISTS colometa;
create schema colometa;
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
    element enum('fire', 'water', 'earth', 'wind', 'light', 'dark') NOT NULL,
    primary key (name)
); engine=myisam DEFAULT CHARSET=utf8mb4;

create table team(
    username varchar(50) NOT NULL,
    villager varchar(50) NOT NULL,
    primary key (username, villager)
);

create table card(
    cardId varchar(15) NOT NULL DEFAULT 'card' AUTO_INCREMENT,
    name varchar(50) NOT NULL,
    energy_cost SMALLINT NOT NULL,
    effect enum ('healing', 'attack', 'defense', 'support') NOT NULL,
    type enum ('creature', 'hypnosis', 'snack', 'weapon', 'skill') NOT NULL,
    description varchar(100) NOT NULL,

--change names, check effects to card relations

    player_health SMALL INT NOT NULL DEFAULT 0, --(to add to player health)
    player_attack SMALL INT NOT NULL DEFAULT 0, --(to subtract from enemy health) 

    player_defense SMALL INT NOT NULL DEFAULT 0, --(to be subtracted from enemy attack in the turn)
    player_support SMALL INT NOT NULL DEFAULT 0, --(to be added to player attack in the turn)
    
    enemy_defense SMALL INT NOT NULL DEFAULT 0, --(to be subtracted from enemy if hypnosis card type)

    primary key (cardId)
); engine=myisam DEFAULT CHARSET=utf8mb4;

create table match(
    matchId varchar(15) NOT NULL DEFAULT 'match' AUTO_INCREMENT,
    timestamp timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
    player varchar(50) NOT NULL,
    won boolean NOT NULL,
    primary key (matchId, player)
    constraint fk_match_player foreign key (player) references player(username) on delete restrict on update cascade,
); engine= InnoDB DEFAULT CHARSET=utf8mb4;

create table stats(
    player varchar(50) NOT NULL,
    most_used_card varchar(50) NOT NULL,
    most_used_villager varchar(50) NOT NULL,
    least_used_card varchar(50) NOT NULL,
    least_used_villager varchar(50) NOT NULL,
    found_objects SMALLINT NOT NULL DEFAULT 0,

    primary key (player),
    constraint stats_player foreign key (player) references player(username) on delete restrict on update cascade,
    constraint stats_MU_card foreign key (most_used_card) references card(cardId) on delete restrict on update cascade,
    foreign key stats_MU_villager foreign key (most_used_villager) references villager(name) on delete restrict on update cascade,
    foreign key stats_LU_card foreign key (least_used_card) references card(cardId) on delete restrict on update cascade,
    foreign key stats_LU_villager foreign key (least_used_villager) references villager(name) on delete restrict on update cascade,
); engine=myisam DEFAULT CHARSET=utf8mb4;
--save stats here after match for stats page

create table deck(
    player varchar(50) NOT NULL,
    card varchar(15) NOT NULL,
    primary key (player, card),
    constraint deck_player foreign key (player) references player(username) on delete restrict on update cascade,
    constraint deck_card foreign key (card) references card(cardId) on delete restrict on update cascade,
); engine=myisam DEFAULT CHARSET=utf8mb4;

create table dialogue(
    dialogueId varchar(15) NOT NULL DEFAULT 'dialogue' AUTO_INCREMENT,
    speaker varchar(50) NOT NULL CHECK (speaker IN ('player', 'Colometa', '?') OR speaker IN (SELECT name FROM villager)), 
    text varchar(200) NOT NULL,
    primary key (dialogueId, speaker),
); engine=myisam DEFAULT CHARSET=utf8mb4;
