create database colometa;
use colometa;

create table player
(
username varchar(50),
level int,
score int,
email varchar(50),
password varchar(50)
primary key(username)
);

create table card
(
name varchar(50) primary key,
type varchar(50),
);

create table match
(

);
