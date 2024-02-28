using Scarpe.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scarpe.Controllers
{
    public class ScarpaController : Controller
    {
        // GET: Scarpa
        public ActionResult Index()
        {
            List<Scarpa> scarpeList = new List<Scarpa>();
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Prodotto WHERE Attivo = 1";

                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Scarpa s = new Scarpa();
                    s.Nome = reader["Nome"].ToString();
                    s.Prezzo = Convert.ToDecimal(reader["Prezzo"]);
                    s.Descrizione = reader["Descrizione"].ToString();
                    s.ImgCopertina = reader["ImgCopertina"].ToString();
                    s.ImgA = reader["ImgA"].ToString();
                    s.ImgB = reader["ImgB"].ToString();
                    s.Attivo = Convert.ToBoolean(reader["Attivo"]);
                    scarpeList.Add(s);

                }
            }
            catch(Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return View(scarpeList);
        }
        
        [HttpGet]
        public ActionResult Dettagli(Scarpa s, int id)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionstring);

            try
            {
                conn.Open();
                string query = "SELECT * FROM Prodotto WHERE IDProdotto = @id";
                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Nome", s.Nome);
                cmd.Parameters.AddWithValue("@Prezzo", s.Prezzo);
                cmd.Parameters.AddWithValue("@Descrizione", s.Descrizione);
                cmd.Parameters.AddWithValue("@ImgCopertina", s.ImgCopertina);
                cmd.Parameters.AddWithValue("@ImgA", s.ImgA);
                cmd.Parameters.AddWithValue("@ImgB", s.ImgB);
                cmd.Parameters.AddWithValue("@Attivo", s.Attivo);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Response.Write("Error: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return View();
        }
    }
}