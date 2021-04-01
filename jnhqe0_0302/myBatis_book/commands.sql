create database book;
use book;

create table books (isbn varchar(14) primary key, title varchar(50), price int);

insert into books values ('A412', 'A412 könyv címe', 6000);
insert into books values ('A413', 'A413 könyv címe', 5000);

SELECT isbn, title, price FROM books;