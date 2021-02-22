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

-- 3.feladat 
                                                               
create table tanfolyam(tkod int primary key, ar int, tipus varchar(30), megnevezes varchar(30));
create table resztvevo(tajszam int primary key, nev varchar(30), lakcim varchar(30));
create table befizetes(tkod int, foreign key(tkod) references tanfolyam(tkod), tajszam int, foreign key(tajszam) references resztvevo(tajszam));

-- 6. feladat
                                                                                                                                      
create table konyv(isbn varchar(20) primary key, cim varchar(40), targy varchar(30), ar int);
insert into konyv values('12f','cim1','targy1',2000);
insert into konyv values('13a','cim2','targy2',2200);
insert into konyv values('45y','cim3','targy3',4800);
insert into konyv values('96n','cim4','targy4',3200);
insert into konyv values('34c','cim5','AB',200);
insert into konyv values('54b','cim6','AB',800);
insert into konyv values('50o','cim7','AB',1000);

select cim from konyv;
select * from konyv where ar>2000;
select cim from konyv where ar<1000;
select targy from konyv;
select cim, ar from konyv where targy='AB';
                                                                                                                                      
-- 7.feladat
                                                                                                                                      
select COUNT(*) from konyv;
select avg(ar) from konyv;
select MIN(ar) as legolcsobb from konyv;
select MAX(ar) as legdragabb from konyv;
select COUNT(*) from konyv where targy='AB';
select MAX(ar) as legdragabbAB from konyv where targy='AB';
select cim from konyv where ar > (select avg(ar) from konyv);
select COUNT(*) from konyv where ar > (select avg(ar) from konyv);
