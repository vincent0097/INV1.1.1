using INV1._1._1.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace INV1._1._1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuppliersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public SuppliersController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                            select * from Suppliers
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
        public JsonResult Post(Suppliers Suppliers)
        {
            string query = @"
                           insert into dbo.Suppliers (SupplierName,ProductID,Email,PhoneNo,Address)
                           values (@SupplierName,@ProductID,@Email,@PhoneNo,@Address)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@SupplierName", Suppliers.SupplierName);
                    myCommand.Parameters.AddWithValue("@ProductID", Suppliers.ProductID);
                    myCommand.Parameters.AddWithValue("@Email", Suppliers.Email);
                    myCommand.Parameters.AddWithValue("@PhoneNo", Suppliers.PhoneNo);
                    myCommand.Parameters.AddWithValue("@Address", Suppliers.Address);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Suppliers Suppliers)
        {
            string query = @"
                           update dbo.Suppliers
                           set SupplierName=@SupplierName,
                           ProductID=@ProductID,
                           Email=@Email,
                           PhoneNo=@PhoneNo,
                           Address=@Address
                           where SupplierID=@SupplierID
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@SupplierID", Suppliers.SupplierID);
                    myCommand.Parameters.AddWithValue("@SupplierName", Suppliers.SupplierName);
                    myCommand.Parameters.AddWithValue("@ProductID", Suppliers.ProductID);
                    myCommand.Parameters.AddWithValue("@PhoneNo", Suppliers.PhoneNo);
                    myCommand.Parameters.AddWithValue("@Address", Suppliers.Address);
                    //myCommand.Parameters.AddWithValue("@PhotoFileName", emp.PhotoFileName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        [HttpDelete("{ID}")]
        public JsonResult Delete(Suppliers Suppliers)
        {
            string query = @"
                           delete Suppliers from dbo.Suppliers
                            where SupplierID=@SupplierID
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@SupplierID", Suppliers.SupplierID);

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
