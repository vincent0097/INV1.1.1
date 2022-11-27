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
    public class SalesController : ControllerBase
    {

            private readonly IConfiguration _configuration;
            private readonly IWebHostEnvironment _env;
            public SalesController(IConfiguration configuration, IWebHostEnvironment env)
            {
                _configuration = configuration;
                _env = env;
            }


            [HttpGet]
            public JsonResult Get()
            {
                string query = @"
                           select * from dbo.Sales
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
            public JsonResult Post(Sales Sales)
            {
                string query = @"
                           insert into dbo.Sales (CustomerID,DateOfSale,ProductID,Unit_price,CustomerName)
                           values (@CustomerID,@DateOfSale,@ProductID,@Unit_price,@CustomerName)
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@CustomerID", Sales.CustomerID);
                        myCommand.Parameters.AddWithValue("@DateOfSale", Sales.DateOfSale);
                        myCommand.Parameters.AddWithValue("@ProductID", Sales.ProductID);
                        myCommand.Parameters.AddWithValue("@Unit_price", Sales.Unit_price);
                    myCommand.Parameters.AddWithValue("@CustomerName", Sales.CustomerName);
                    myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }

                return new JsonResult("Added Successfully");
            }


            [HttpPut]
            public JsonResult Put(Sales Sales)
            {
                string query = @"
                           update dbo.Sales
                           set CustomerID=@CustomerID,
                           DateOfSale=@DateOfSale,
                           Unit_price=@Unit_price,
CustomerName=@CustomerName
                            where SalesID=@SalesID
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@SalesID", Sales.SalesID); 
                        myCommand.Parameters.AddWithValue("@CustomerID", Sales.CustomerID);
                        myCommand.Parameters.AddWithValue("@DateOfSale", Sales.DateOfSale);
                        myCommand.Parameters.AddWithValue("@ProductID", Sales.ProductID);
                        myCommand.Parameters.AddWithValue("@Unit_price", Sales.Unit_price);
                    myCommand.Parameters.AddWithValue("@CustomerName", Sales.CustomerName);
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
                           delete from dbo.Sales
                            where SalesID=@SalesID
                            ";

                DataTable table = new DataTable();
                string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
                SqlDataReader myReader;
                using (SqlConnection myCon = new SqlConnection(sqlDataSource))
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand(query, myCon))
                    {
                        myCommand.Parameters.AddWithValue("@SalesID", id);

                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();
                    }
                }

                return new JsonResult("Deleted Successfully");
            }
        }
}
