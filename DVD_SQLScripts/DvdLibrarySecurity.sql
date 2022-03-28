--login DvdLibraryApp
--pass testing123
--database DVDLibrary
--table Dvd


use master
go

create login DvdLibraryApp with password='Testing123'
go

use DVDLibrary
go

create user DvdLibraryApp for login DvdLibraryApp
go

--crud
GRANT SELECT ON Dvd TO DvdLibraryApp
GRANT INSERT ON Dvd TO DvdLibraryApp
GRANT UPDATE ON Dvd TO DvdLibraryApp
GRANT DELETE ON Dvd TO DvdLibraryApp
GO

--stored procedure
GRANT EXECUTE ON RetrievingDvdById TO DvdLibraryApp
GRANT EXECUTE ON RetrievingAllDvd TO DvdLibraryApp
GRANT EXECUTE ON RetrievingDvdByTitle TO DvdLibraryApp
GRANT EXECUTE ON RetrievingDvdByYear TO DvdLibraryApp
GRANT EXECUTE ON RetrievingDvdByDirector TO DvdLibraryApp
GRANT EXECUTE ON RetrievingDvdByRating TO DvdLibraryApp
GRANT EXECUTE ON CreatingNewDvd TO DvdLibraryApp
GRANT EXECUTE ON UpdatingDvd TO DvdLibraryApp
GRANT EXECUTE ON DeletingDvd TO DvdLibraryApp
GO