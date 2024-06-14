DROP DATABASE IF EXISTS colometa;
create schema colometa;
use colometa;

create table player(
    username varchar(50) NOT NULL DEFAULT 'name',
    password varchar(50) NOT NULL DEFAULT 'password',
    primary key (username)
) engine=InnoDB DEFAULT CHARSET=utf8mb4;

create table villager(
    villager_id SMALLINT NOT NULL AUTO_INCREMENT,
    name varchar(50) NOT NULL,
    description varchar(100) NOT NULL,
    element enum('Reason', 'Dream', 'Terror') NOT NULL,
    primary key (villager_id)
) engine=InnoDB DEFAULT CHARSET=utf8mb4;

create table card(
    cardId SMALLINT NOT NULL AUTO_INCREMENT,
    name varchar(50) NOT NULL,
    energy_cost SMALLINT NOT NULL,
    effect enum ('healing', 'attack', 'defense', 'support', 'special') NOT NULL,
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
    enemy_attack SMALLINT NOT NULL DEFAULT 0, 
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


create table card_use(
    cardId SMALLINT NOT NULL,
    username varchar(50) NOT NULL,
    times_used SMALLINT NOT NULL DEFAULT 0,
    primary key (cardId, username),
    constraint cardUse_card foreign key (cardId) references card(cardId) on delete restrict on update cascade,
    constraint cardUse_player foreign key (username) references player(username) on delete restrict on update cascade
) engine=myisam DEFAULT CHARSET=utf8mb4;

create table villager_use(
    villager_id SMALLINT NOT NULL,
    username varchar(50) NOT NULL,
    times_used SMALLINT NOT NULL DEFAULT 0,
    primary key (villager_id, username),
    constraint villagerUse_villager foreign key (villager_id) references villager(villager_id) on delete restrict on update cascade,
    constraint villagerUse_player foreign key (username) references player(username) on delete restrict on update cascade
) engine=myisam DEFAULT CHARSET=utf8mb4;

create table stats(
    username varchar(50) NOT NULL,
    most_used_card VARCHAR(50) NOT NULL DEFAULT 'none',
    most_used_villager VARCHAR(50) NOT NULL DEFAULT 'none',
    least_used_card VARCHAR(50) NOT NULL DEFAULT 'none',
    least_used_villager VARCHAR(50) NOT NULL DEFAULT 'none',
    memories_found SMALLINT NOT NULL DEFAULT 0,
    matches_won SMALLINT NOT NULL DEFAULT 0,
    total_matches_played SMALLINT NOT NULL DEFAULT 0,

    primary key (username),
    constraint stats_player foreign key (username) references player(username) on delete restrict on update cascade,
    constraint stats_MU_card foreign key (most_used_card) references card(cardId) on delete restrict on update cascade,
    constraint stats_MU_villager foreign key (most_used_villager) references villager(villager_id) on delete restrict on update cascade,
    constraint stats_LU_card foreign key (least_used_card) references card(cardId) on delete restrict on update cascade,
    constraint stats_LU_villager foreign key (least_used_villager) references villager(villager_id) on delete restrict on update cascade
) engine=myisam DEFAULT CHARSET=utf8mb4;

create table global_stats(
    global_stats_id SMALLINT NOT NULL AUTO_INCREMENT,
    most_used_card SMALLINT NOT NULL,
    most_used_villager SMALLINT NOT NULL,
    least_used_card SMALLINT NOT NULL,
    least_used_villager SMALLINT NOT NULL,
    memories_found_avg SMALLINT NOT NULL,
    primary key (global_stats_id)
) engine=myisam DEFAULT CHARSET=utf8mb4;