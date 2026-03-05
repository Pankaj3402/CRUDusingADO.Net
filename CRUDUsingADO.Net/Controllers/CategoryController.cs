using CRUDUsingADO.Net.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace CRUDUsingADO.Net.Controllers
{
    public class CategoryController : Controller
    {
        private readonly string connectionString =
            "Server=DESKTOP-LBV85A4\\SQLEXPRESS;Database=MVCDatabase;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;";

        // =========================
        // INDEX (LIST ALL)
        // =========================
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM dbo.Category";

                using (SqlCommand cmd = new SqlCommand(query, con))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        categories.Add(new Category
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            OwnerName = reader["OwnerName"].ToString()
                        });
                    }
                }
            }

            return View(categories);
        }

        // =========================
        // DETAILS
        // =========================
        public IActionResult Details(int id)
        {
            Category category = new Category();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM dbo.Category WHERE Id=@Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category.Id = Convert.ToInt32(reader["Id"]);
                            category.Name = reader["Name"].ToString();
                            category.OwnerName = reader["OwnerName"].ToString();
                        }
                    }
                }
            }

            return View(category);
        }

        // =========================
        // CREATE (GET)
        // =========================
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // =========================
        // CREATE (POST)
        // =========================
        [HttpPost]
        public IActionResult Create(Category category)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = @"INSERT INTO dbo.Category (Name, OwnerName) 
                                 VALUES (@Name, @OwnerName)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.Parameters.AddWithValue("@OwnerName", category.OwnerName);

                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        // =========================
        // EDIT (GET)
        // =========================
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Category category = new Category();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM dbo.Category WHERE Id=@Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category.Id = Convert.ToInt32(reader["Id"]);
                            category.Name = reader["Name"].ToString();
                            category.OwnerName = reader["OwnerName"].ToString();
                        }
                    }
                }
            }

            return View(category);
        }

        // =========================
        // EDIT (POST)
        // =========================
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = @"UPDATE dbo.Category 
                                 SET Name=@Name, OwnerName=@OwnerName 
                                 WHERE Id=@Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", category.Id);
                    cmd.Parameters.AddWithValue("@Name", category.Name);
                    cmd.Parameters.AddWithValue("@OwnerName", category.OwnerName);

                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }

        // =========================
        // DELETE (GET) - SHOW CONFIRMATION
        // =========================
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category category = new Category();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "SELECT * FROM dbo.Category WHERE Id=@Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category.Id = Convert.ToInt32(reader["Id"]);
                            category.Name = reader["Name"].ToString();
                            category.OwnerName = reader["OwnerName"].ToString();
                        }
                    }
                }
            }

            return View(category);   // ⚠ Only shows confirmation page
        }
        // =========================
        // DELETE (POST) - CONFIRMED
        // =========================
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();

                string query = "DELETE FROM dbo.Category WHERE Id=@Id";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }

            return RedirectToAction("Index");
        }
    }
}