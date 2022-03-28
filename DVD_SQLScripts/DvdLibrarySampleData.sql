Use DvdLibrary
GO

delete from Dvd
go

insert into Dvd(title,releaseYear,director,rating,notes)
		values	('Code Geass', '2006', 'Bandai', 'R', 'The best anime in the world'),
				('Kara no kyoukai', '2007', 'Type-moon', 'R', 'First type-moon movie'),
				('Arknights', '2023', 'Yostar', 'PG-13', 'still waiting'),
				('Gundam', '0079', 'Bandai', 'PG-13', 'not a real year'),
				('Fate stay night', '2002', 'Type-moon', 'R', 'its a series')
GO