using INV1._1._1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace INV1._1._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        Login users = new Login();
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public LoginController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpPost]
        public Users Post(Login login)
        {
            Users userdetails = new Users();
            userdetails.result = new Result();
            try
            {
                if (login != null && !string.IsNullOrWhiteSpace(login.username) && !string.IsNullOrWhiteSpace(login.password))
                {
                    string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                    //SqlDataReader myReader;
                    using (SqlConnection myCon = new SqlConnection(sqlDataSource))

                    {
                        SqlCommand cmd = new SqlCommand("sp_users", myCon);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", login.username);
                        cmd.Parameters.AddWithValue("@password", login.password);
                        cmd.Parameters.AddWithValue("@stmttype", "userlogin");
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        if (dt != null && dt.Rows.Count > 0)
                        {

                            userdetails.Firstname = dt.Rows[0]["Firstname"].ToString();
                            userdetails.Lastname = dt.Rows[0]["Lastname"].ToString();
                            userdetails.Email = dt.Rows[0]["Email"].ToString();
                            userdetails.PhoneNo = dt.Rows[0]["PhoneNo"].ToString();
                            userdetails.username = dt.Rows[0]["username"].ToString();
                            userdetails.Password = dt.Rows[0]["password"].ToString();

                           
                            userdetails.result.result = true;
                            userdetails.result.message = "success";
                        }
                        else
                        {
                            userdetails.result.result = false;
                            userdetails.result.message = "Invalid user";
                        }
                    }
                }
                else
                {
                    userdetails.result.result = false;
                    userdetails.result.message = "Please enter username and password";
                }
            }
            catch (Exception ex)
            {
                userdetails.result.result = false;
                userdetails.result.message = "Error occurred: " + ex.Message.ToString();
            }
            return userdetails;
        }
    }
}

