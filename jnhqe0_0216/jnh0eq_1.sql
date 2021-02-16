create database msc;
use msc;

 

-- drop table gyarto;
-- drop table termek;

 

create table gyarto(adoszam int primary key, nev varchar(30) not null, telephely varchar(200), irsz varchar(4), varos varchar(40), utca varchar(100));
create table termek(tkod int primary key, nev char(50), ear int check(ear>0), gyarto int  references gyarto);

 

create table alkatresz(akod int primary key, nev varchar(50) not null);
create table egysegek(aru int references termek, db int check (db > 0));
create table komponens(termek int references termek, alkatresz int references alkatresz);

 

insert into gyarto values (8000, 'gyarto1', 'telephely1', '3530', 'Miskolc', 'Városház tér');
insert into termek values (7000, 'termek1', 1, 8000);
insert into termek values (7001, 'termek2', 2, 8000);
insert into termek values (7002, 'termek3', 5, 8000);
insert into termek values (7003, 'termek4', 1, 8000);
insert into termek values (7004, 'termek5', 1, 8000);
-- insert into termek values (7004, 'termek5', -2, 8000);
insert into termek values (7005, 'terem', 1, 8000);

 

select * from gyarto;
select * from termek;
select * from alkatresz;
select * from egysegek;
select * from komponens;