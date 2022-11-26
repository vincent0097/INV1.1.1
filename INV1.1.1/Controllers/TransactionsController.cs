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
    public class TransactionsController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public TransactionsController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }


        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                           select * from dbo.Transactions
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
        public JsonResult Post(Transactions Transactions)
        {
            string query = @"
                           insert into dbo.Transactions (UsreID,CustomerID,DateOfPurchase,SalesID,AmountTransacted)
                           values (@UsreID,@CustomerID,@DateOfPurchase,@SalesID,@AmountTransacted)
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserID", Transactions.UserID);
                    myCommand.Parameters.AddWithValue("@CustomerID", Transactions.CustomerID);
                    myCommand.Parameters.AddWithValue("@DateOfPurchase", Transactions.DateOfPurchase);
                    myCommand.Parameters.AddWithValue("@SalesID", Transactions.SalesID);
                    myCommand.Parameters.AddWithValue("@AmountTransacted", Transactions.AmountTransacted);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Transactions Transactions)
        {
            string query = @"
                           update dbo.Transactions
                           set UserID=@UserID,
                           CustomerID=@CustomerID,
                           DateOfPurchase=@DateOfPurchase,
                           Costsold=@CostSold,
                           SalesID=@SalesID,
                           AmountTransacted=@AmountTransacted
                            where TransactionID=@TransactionID
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@UserID", Transactions.UserID);
                    myCommand.Parameters.AddWithValue("@CustomerID", Transactions.CustomerID);
                    myCommand.Parameters.AddWithValue("@DateOfPurchase", Transactions.DateOfPurchase);
                    myCommand.Parameters.AddWithValue("@SalesID", Transactions.SalesID);
                    myCommand.Parameters.AddWithValue("@AmountTransacted", Transactions.AmountTransacted);
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
                           delete from dbo.Transactions
                            where TransactionID=@TransactionID
                            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("DefaultConnection");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TransactionID", id);

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
