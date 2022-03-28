using DVDLibraryDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace DVDLibraryDatabase.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class DvdController : ApiController
    {

        private static IDvdRepository _dvdRepo = DvdFactory.GetRepository();

        [Route("dvds/{type}/{term}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(string type, string term) {
            
            if (type == "title") {
                return Ok(_dvdRepo.GetTitle(term));
            } else if (type == "year") {
                return Ok(_dvdRepo.GetYear(term));
            } else if (type == "director") {
                return Ok(_dvdRepo.GetDirector(term));
            } else if (type == "rating") {
                return Ok(_dvdRepo.GetRating(term));
            } else {
                return NotFound();
            }
            
        }

        [Route("dvds/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult GetAll() {
            return Ok(_dvdRepo.GetAll());
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int id) {
            Dvd found = _dvdRepo.Get(id);

            if (found == null) {
                return NotFound();
            }

            return Ok(found);
        }

        [Route("dvd")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(Dvd dvd) {
            _dvdRepo.Create(dvd);

            return Created($"dvd/{dvd.dvdId}", dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("PUT")]
        public void Update(Dvd dvd) {
            _dvdRepo.Update(dvd);
        }

        [Route("dvd/{id}")]
        [AcceptVerbs("DELETE")]
        public void Delete(int id) {
            _dvdRepo.Delete(id);
        }
    }
}
