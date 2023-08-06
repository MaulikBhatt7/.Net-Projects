using Data_Annotation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data;

namespace Data_Annotation.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration;

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SQLView() {
            SqlConnection sqlConnection = new SqlConnection(this.Configuration.GetConnectionString("default"));
            sqlConnection.Open();

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

            sqlCommand.CommandText = "PR_Country_SelectAll";

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(sqlDataReader);
            return View(dt);
        }
    }
}