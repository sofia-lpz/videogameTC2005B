DROP schema IF EXISTS colometa;
create schema colometa;
use colometa;

create table player(
    username varchar(50) NOT NULL DEFAULT 'name',
    password varchar(50) NOT NULL DEFAULT 'password',
    matches_won SMALLINT NOT NULL DEFAULT 0,
    primary key (username)
); engine=InnoDB DEFAULT CHARSET=utf8mb4;

create table villager(
    name varchar(50) NOT NULL,
    description varchar(100) NOT NULL,
    element enum('fire', 'water', 'earth', 'wind', 'light', 'dark') NOT NULL,
    primary key (name)
) engine=InnoDB DEFAULT CHARSET=utf8mb4;

create table team(
    username varchar(50) NOT NULL,
    villager varchar(50) NOT NULL,
    primary key (username, villager),
    constraint fk_team_username foreign key (username) references player(username) on delete restrict on update cascade,
    constraint fk_team_villager foreign key (villager) references villager(name) on delete restrict on update cascade
) engine=InnoDB DEFAULT CHARSET=utf8mb4;

create table card(
    cardId varchar(15) NOT NULL DEFAULT 'card',
    name varchar(50) NOT NULL,
    energy_cost SMALLINT NOT NULL,
    effect enum ('healing', 'attack', 'defense', 'support') NOT NULL,
    type enum ('creature', 'hypnosis', 'snack', 'weapon', 'skill') NOT NULL,
    description varchar(100) NOT NULL,

    player_health SMALLINT NOT NULL DEFAULT 0, 
    -- (to add to player health)
    player_attack SMALLINT NOT NULL DEFAULT 0, 
    -- (to subtract from enemy health) 

    player_defense SMALLINT NOT NULL DEFAULT 0, 
    -- (to be subtracted from enemy attack in the turn)
    player_support SMALLINT NOT NULL DEFAULT 0, 
    -- (to be added to player attack in the turn)
    
    enemy_defense SMALLINT NOT NULL DEFAULT 0, 
    -- (to be subtracted from enemy if hypnosis card type)

    primary key (cardId)
) engine=myisam DEFAULT CHARSET=utf8mb4;

create table tcg_match(
    matchId SMALLINT NOT NULL AUTO_INCREMENT,
    timestamp timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
    username varchar(50) NOT NULL,
    won boolean NOT NULL,
    primary key (matchId, username),
    constraint fk_match_player foreign key (username) references player(username) on delete restrict on update cascade
) engine= InnoDB DEFAULT CHARSET=utf8mb4;

create table stats(
    username varchar(50) NOT NULL,
    most_used_card varchar(50) NOT NULL,
    most_used_villager varchar(50) NOT NULL,
    least_used_card varchar(50) NOT NULL,
    least_used_villager varchar(50) NOT NULL,
    found_objects SMALLINT NOT NULL DEFAULT 0,

    primary key (username),
    constraint stats_player foreign key (username) references player(username) on delete restrict on update cascade,
    constraint stats_MU_card foreign key (most_used_card) references card(cardId) on delete restrict on update cascade,
    constraint stats_MU_villager foreign key (most_used_villager) references villager(name) on delete restrict on update cascade,
    constraint stats_LU_card foreign key (least_used_card) references card(cardId) on delete restrict on update cascade,
    constraint stats_LU_villager foreign key (least_used_villager) references villager(name) on delete restrict on update cascade
) engine=myisam DEFAULT CHARSET=utf8mb4;

create table deck(
    username varchar(50) NOT NULL,
    cardId varchar(15) NOT NULL,
    primary key (username,cardId),
    constraint deck_player foreign key (username) references player(username) on delete restrict on update cascade,
    constraint deck_card foreign key (cardId) references card(cardId) on delete restrict on update cascade
) engine=myisam DEFAULT CHARSET=utf8mb4;

create table dialogue(
    speaker varchar(50) NOT NULL,
    lineIndex SMALLINT NOT NULL DEFAULT 0,
    storyIndex SMALLINT NOT NULL DEFAULT 0,
    
    text varchar(200) NOT NULL,

    primary key (speaker, lineIndex)
) engine=myisam DEFAULT CHARSET=utf8mb4;