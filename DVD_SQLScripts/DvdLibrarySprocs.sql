use DVDLibrary
go

----------------------------Retrieving a Dvd by Id--------------------------
if exists (select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME = 'RetrievingDvdById')
begin
	drop procedure RetrievingDvdById
end
go

create procedure RetrievingDvdById (
	@dvdId int
)
as
	select dvdId, title, releaseYear, director, rating, notes
	from Dvd
	where dvdId = @dvdId
go

----------------------------Retrieving all Dvds--------------------------
if exists (select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME = 'RetrievingAllDvd')
begin
	drop procedure RetrievingAllDvd
end
go

create procedure RetrievingAllDvd
as
	select dvdId, title, releaseYear, director, rating, notes
	from Dvd
go

----------------------------Retrieving Dvds by Title--------------------------
if exists (select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME = 'RetrievingDvdByTitle')
begin
	drop procedure RetrievingDvdByTitle
end
go

create procedure RetrievingDvdByTitle (
	@title varchar(50)
)
as
	select dvdId, title, releaseYear, director, rating, notes
	from Dvd
	where title like( '%' + @title + '%')
go

----------------------------Retrieving Dvds by Release Year--------------------------
if exists (select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME = 'RetrievingDvdByYear')
begin
	drop procedure RetrievingDvdByYear
end
go

create procedure RetrievingDvdByYear (
	@releaseYear varchar(4)
)
as
	select dvdId, title, releaseYear, director, rating, notes
	from Dvd
	where releaseYear = @releaseYear
go

----------------------------Retrieving Dvds by Director Name--------------------------
if exists (select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME = 'RetrievingDvdByDirector')
begin
	drop procedure RetrievingDvdByDirector
end
go

create procedure RetrievingDvdByDirector (
	@director varchar(50)
)
as
	select dvdId, title, releaseYear, director, rating, notes
	from Dvd
	where director like( '%' + @director + '%')  
go

----------------------------Retrieving Dvds by Rating--------------------------
if exists (select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME = 'RetrievingDvdByRating')
begin
	drop procedure RetrievingDvdByRating
end
go

create procedure RetrievingDvdByRating (
	@rating varchar(10)
)
as
	select dvdId, title, releaseYear, director, rating, notes
	from Dvd
	where rating = @rating
go

----------------------------Creating a new Dvd--------------------------
if exists (select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME = 'CreatingNewDvd')
begin
	drop procedure CreatingNewDvd
end
go

create procedure CreatingNewDvd (
	@title varchar(50),
	@releaseYear varchar(4),
	@director varchar(50),
	@rating varchar(10),
	@notes varchar(300)
)
as
	begin
		insert into Dvd(title,releaseYear,director,rating,notes)
		values(@title,@releaseYear,@director,@rating,@notes)
	end
go

----------------------------Updating an Existing Dvd--------------------------
if exists (select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME = 'UpdatingDvd')
begin
	drop procedure UpdatingDvd
end
go

create procedure UpdatingDvd (
	@dvdId int,
	@title varchar(50),
	@releaseYear varchar(4),
	@director varchar(50),
	@rating varchar(10),
	@notes varchar(300)
)
as
	begin
		update Dvd
		set 
			title = @title,
			releaseYear = @releaseYear,
			director = @director,
			rating = @rating,
			notes = @notes
		where
			dvdId = @dvdId
	end
go

----------------------------Deleting a Dvd--------------------------
if exists (select * from INFORMATION_SCHEMA.ROUTINES where ROUTINE_NAME = 'DeletingDvd')
begin
	drop procedure DeletingDvd
end
go

create procedure DeletingDvd (
	@dvdId int
)
as
	begin
		delete from Dvd
		where dvdId = @dvdId
	end
go