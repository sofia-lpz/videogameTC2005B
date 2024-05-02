DROP DATABASE IF EXISTS colometa;
create database colometa;
use colometa;

create table player(
    username varchar(50) NOT NULL DEFAULT 'name',
    password varchar(50) NOT NULL DEFAULT 'password',
    level SMALLINT NOT NULL DEFAULT 0,
    score INT NOT NULL DEFAULT 0, --matches won
    primary key (username)
); engine=myisam DEFAULT CHARSET=utf8mb4;

create table card(
    cardId varchar(15) NOT NULL DEFAULT 'card' AUTO_INCREMENT,
    name varchar(50) NOT NULL,
    energy_cost SMALLINT NOT NULL,
    effect enum ('healing', 'attack', 'defense', 'support') NOT NULL,
    type enum ('creature', 'hypnosis', 'snack', 'weapon', 'tool', 'skill') NOT NULL,
    description varchar(100) NOT NULL,
    self_health SMALL INT NOT NULL DEFAULT 0, --set this to positive if its healing
    oponent_health SMALL INT NOT NULL DEFAULT 0, --set this to negative if its attack
    
    primary key (cardId)
); engine=myisam DEFAULT CHARSET=utf8mb4;

create table match(
matchId varchar(15) NOT NULL DEFAULT 'match' AUTO_INCREMENT,
timestamp timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
player varchar(50) NOT NULL,
-- player life?
-- player energy?
won boolean NOT NULL,
primary key (matchId)
foreign key (player1) references player(username),
); engine= InnoDB DEFAULT CHARSET=utf8mb4;

create table deck(
    player varchar(50) NOT NULL,
    card varchar(15) NOT NULL,
    primary key (player, card),
    foreign key (player) references player(username),
    foreign key (card) references card(cardId)
); engine=myisam DEFAULT CHARSET=utf8mb4;
