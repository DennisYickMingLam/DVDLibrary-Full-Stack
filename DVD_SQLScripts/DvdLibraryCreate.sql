use master
go

if exists (select * from sys.databases where name='DVDLibrary')
drop database DVDLibrary
go

create database DVDLibrary
go

use DVDLibrary
go

if exists (select * from sys.tables where name='Dvd')
drop table Dvd
go

create table Dvd(
	dvdId int identity(1,1) primary key not null,
	title varchar(50) not null,
	releaseYear varchar(4) not null,
	director varchar(50) not null,
	rating varchar(10) not null,
	notes varchar(300)
)
go