using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DVDLibraryDatabase.Models {
    public class DvdFactory {
        public static IDvdRepository GetRepository() {
            
            string repositoryType = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (repositoryType) {
                case "SampleData":
                    return new DvdRepositoryMock();
                case "ADO":
                    return new DvdRepositoryADO();
                default:
                    throw new Exception("Invalid mode: something is wrong with <appSettings> in web.config ");
            }

        }
    }
}