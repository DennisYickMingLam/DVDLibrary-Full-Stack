using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DVDLibraryDatabase.Models {
    public class DvdRepositoryADO : IDvdRepository {

        
        public void Create(Dvd dvd) {
            using (SqlConnection conn = new SqlConnection()) {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString; 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CreatingNewDvd";
                conn.Open();

                cmd.Parameters.AddWithValue("@title", dvd.title);
                cmd.Parameters.AddWithValue("@director", dvd.director);
                cmd.Parameters.AddWithValue("@rating", dvd.rating);
                cmd.Parameters.AddWithValue("@releaseYear", dvd.releaseYear);
                cmd.Parameters.AddWithValue("@notes", dvd.notes);
                
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int dvdId) {
            using (SqlConnection conn = new SqlConnection()) {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString; 
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeletingDvd";
                conn.Open();

                cmd.Parameters.AddWithValue("@DvdId", dvdId);
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Dvd dvd) {
            using (SqlConnection conn = new SqlConnection()) {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdatingDvd";
                conn.Open();

                cmd.Parameters.AddWithValue("@dvdId", dvd.dvdId);
                cmd.Parameters.AddWithValue("@title", dvd.title);
                cmd.Parameters.AddWithValue("@director", dvd.director);
                cmd.Parameters.AddWithValue("@rating", dvd.rating);
                cmd.Parameters.AddWithValue("@releaseYear", dvd.releaseYear);
                cmd.Parameters.AddWithValue("@notes", dvd.notes);

                cmd.ExecuteNonQuery();
            }
        }

        public Dvd Get(int dvdId) {
            Dvd dvd = new Dvd();
            using (SqlConnection conn = new SqlConnection()) {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RetrievingDvdById";

                cmd.Parameters.AddWithValue("@DvdId", dvdId);
                using (SqlDataReader dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        dvd.title = dr["title"].ToString();
                        dvd.releaseYear = dr["releaseYear"].ToString();
                        dvd.director = dr["director"].ToString();
                        dvd.rating = dr["rating"].ToString();
                        if (dr["notes"] != DBNull.Value) {
                            dvd.notes = dr["notes"].ToString();
                        }
                        dvd.dvdId = (int) dr["dvdId"];
                    }
                }
            }
            return dvd;
        }

        public List<Dvd> GetAll() {
            List<Dvd> dvds = new List<Dvd>();
            using (SqlConnection conn = new SqlConnection()) {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RetrievingAllDvd";
            
                using (SqlDataReader dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        Dvd currentRow = new Dvd();
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        if (dr["notes"] != DBNull.Value) {
                            currentRow.notes = dr["notes"].ToString();
                        }
                        currentRow.dvdId = (int)dr["dvdId"];
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetDirector(string dvdDirector) {
            List<Dvd> dvds = new List<Dvd>();
            using (SqlConnection conn = new SqlConnection()) {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RetrievingDvdByDirector";
                conn.Open();

                cmd.Parameters.AddWithValue("@director", dvdDirector);

                using (SqlDataReader dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        Dvd currentRow = new Dvd();
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        if (dr["notes"] != DBNull.Value) {
                            currentRow.notes = dr["notes"].ToString();
                        }
                        currentRow.dvdId = (int)dr["dvdId"];
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetTitle(string dvdTitle) {
            List<Dvd> dvds = new List<Dvd>();
            using (SqlConnection conn = new SqlConnection()) {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RetrievingDvdByTitle";
                conn.Open();

                cmd.Parameters.AddWithValue("@title", dvdTitle);

                using (SqlDataReader dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        Dvd currentRow = new Dvd();
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        if (dr["notes"] != DBNull.Value) {
                            currentRow.notes = dr["notes"].ToString();
                        }
                        currentRow.dvdId = (int)dr["dvdId"];
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetRating(string dvdRating) {
            List<Dvd> dvds = new List<Dvd>();
            using (SqlConnection conn = new SqlConnection()) {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RetrievingDvdByRating";
                conn.Open();

                cmd.Parameters.AddWithValue("@rating", dvdRating);

                using (SqlDataReader dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        Dvd currentRow = new Dvd();
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        if (dr["notes"] != DBNull.Value) {
                            currentRow.notes = dr["notes"].ToString();
                        }
                        currentRow.dvdId = (int)dr["dvdId"];
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }

        public List<Dvd> GetYear(string dvdYear) {
            List<Dvd> dvds = new List<Dvd>();
            using (SqlConnection conn = new SqlConnection()) {

                conn.ConnectionString = ConfigurationManager.ConnectionStrings["DVDLibrary"].ConnectionString;
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RetrievingDvdByYear";
                conn.Open();

                cmd.Parameters.AddWithValue("@releaseYear", dvdYear);

                using (SqlDataReader dr = cmd.ExecuteReader()) {
                    while (dr.Read()) {
                        Dvd currentRow = new Dvd();
                        currentRow.title = dr["title"].ToString();
                        currentRow.releaseYear = dr["releaseYear"].ToString();
                        currentRow.director = dr["director"].ToString();
                        currentRow.rating = dr["rating"].ToString();
                        if (dr["notes"] != DBNull.Value) {
                            currentRow.notes = dr["notes"].ToString();
                        }
                        currentRow.dvdId = (int)dr["dvdId"];
                        dvds.Add(currentRow);
                    }
                }
            }
            return dvds;
        }
    }
}