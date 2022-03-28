using DVDLibraryDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DVDLibraryDatabase.Models {
    public class DvdRepositoryMock : IDvdRepository {

        private List<Dvd> _dvds = new List<Dvd>()
            {
                new Dvd { dvdId=1, title="Sally", releaseYear="2000", director="Microsoft", rating="PG-13", notes="555-345-8756" },
                new Dvd { dvdId=2, title="Gary", releaseYear="2003", director="Apple", rating="R", notes="555-543-1234" },
                new Dvd { dvdId=3, title="John", releaseYear="2024", director="AMD", rating="R", notes="543-890-8756" },
                new Dvd { dvdId=4, title="Do", releaseYear="1958", director="Linx", rating="G", notes="345-234-5678" },
                new Dvd { dvdId=5, title="Ada", releaseYear="1988", director ="Babbage Industries", rating="R", notes="555-555-1212" },
            };

        public void Create(Dvd dvd) {
            dvd.dvdId = _dvds.Max(m => m.dvdId) + 1;
            _dvds.Add(dvd);
        }

        public void Delete(int dvdId) {
            _dvds.RemoveAll(m => m.dvdId == dvdId);
        }

        public void Update(Dvd dvd) {
            var found = _dvds.FirstOrDefault(m => m.dvdId == dvd.dvdId);

            if (found != null) {
                found.dvdId = dvd.dvdId;
                found.title = dvd.title;
                found.director = dvd.director;
                found.releaseYear = dvd.releaseYear;
                found.rating = dvd.rating;
                found.notes = dvd.notes;
            }
        }

        public Dvd Get(int dvdId) {
            return _dvds.FirstOrDefault(m => m.dvdId == dvdId);
        }

        public List<Dvd> GetAll() {
            return _dvds;
        }

        public List<Dvd> GetDirector(string dvdDirector) {
            List<Dvd> result = _dvds.FindAll(delegate (Dvd dvd) {
                return dvd.director.ToUpper() == dvdDirector.ToUpper();
            });
            
            return result;
        }

        public List<Dvd> GetTitle(string dvdTitle) {
            List<Dvd> result = _dvds.FindAll(delegate (Dvd dvd) {
                return dvd.title.ToUpper() == dvdTitle.ToUpper();
            });

            return result;
        }

        public List<Dvd> GetRating(string dvdRating) {
            List<Dvd> result = _dvds.FindAll(delegate (Dvd dvd) {
                return dvd.rating.ToUpper() == dvdRating.ToUpper();
            });

            return result;
        }

        public List<Dvd> GetYear(string dvdYear) {
            List<Dvd> result = _dvds.FindAll(delegate (Dvd dvd) {
                return dvd.releaseYear == dvdYear;
            });

            return result;
        }
    }
}