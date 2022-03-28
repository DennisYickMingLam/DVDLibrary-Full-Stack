using DVDLibraryDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDLibraryDatabase {
    public interface IDvdRepository {
        
        List<Dvd> GetAll();
        Dvd Get(int dvdId);
        void Update(Dvd dvd);
        List<Dvd> GetTitle(string dvdTitle);
        List<Dvd> GetDirector(string dvdDirector);
        List<Dvd> GetRating(string dvdRating);
        List<Dvd> GetYear(string dvdYear);
        void Delete(int dvdId);
        void Create(Dvd dvd);
        
    }
}
