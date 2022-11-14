using INV1._1._1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace INV1._1._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
      
            private readonly IConfiguration _configuration;
            private readonly IWebHostEnvironment _env;
            public CustomerController(IConfiguration configuration, IWebHostEnvironment env)
            {
                _configuration = configuration;
                _env = env;
            }


            [HttpGet]
            public JsonResult Get()
            {
                string query = @"
                            select CustomerId, CustomerName,Home,
                            convert(varchar(10),DateOfJoining,120) as DateOfJoining
                            from
                            dbo.Customer
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                    myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }

                return new JsonResult(table);
            }

            [HttpPost]
            public JsonResult Post(Customer emp)
            {
                string query = @"
                           insert into dbo.Customer
                           (CustomerName,Home,DateOfJoining)
                    values (@CustomerName,@Home,getdate())
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@CustomerName", emp.CustomerName);
                        myCommand.Parameters.AddWithValue("@Home", emp.Home);
                        //myCommand.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining);
                    //myCommand.Parameters.AddWithValue("@PhotoFileName", emp.PhotoFileName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
                }

                return new JsonResult("Added Successfully");
            }


            [HttpPut]
            public JsonResult Put(Customer emp)
            {
                string query = @"
                           update dbo.Customer
                           set CustomerName= @CustomerName,
                            Home=@Home,
                            DateOfJoining=@DateOfJoining
                            where CustomerId=@CustomerId
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@CustomerId", emp.CustomerId);
                        myCommand.Parameters.AddWithValue("@CustomerName", emp.CustomerName);
                        myCommand.Parameters.AddWithValue("@Home", emp.Home);
                        myCommand.Parameters.AddWithValue("@DateOfJoining", emp.DateOfJoining);
                        //myCommand.Parameters.AddWithValue("@PhotoFileName", emp.PhotoFileName);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }

                return new JsonResult("Updated Successfully");
            }

            [HttpDelete("{id}")]
            public JsonResult Delete(int id)
            {
                string query = @"
                           delete from dbo.Customer
                            where CustomerId=@CustomerId
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@CustomerId", id);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }

                return new JsonResult("Deleted Successfully");
            }


            //[Route("SaveFile")]
            //[HttpPost]
            //public JsonResult SaveFile()
            //{
            //    try
            //    {
            //        var httpRequest = Request.Form;
            //        var postedFile = httpRequest.Files[0];
            //        string filename = postedFile.FileName;
            //        var physicalPath = _env.ContentRootPath + "/Photos/" + filename;

            //        using (var stream = new FileStream(physicalPath, FileMode.Create))
            //        {
            //            postedFile.CopyTo(stream);
            //        }

            //        return new JsonResult(filename);
            //    }
            //    catch (Exception)
            //    {

            //        return new JsonResult("anonymous.png");
            //    }
            //}
        }
    }
