using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPICars.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPICars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private readonly IConfiguration _configuration;

        public CarsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: api/<CarsController>
        

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select Id,Pedido,Bastidor,Modelo,Matricula,Fecha from dbo.CarsTable";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CarConection");
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


        // GET: api/<CarsController>
        [HttpGet("{page}")]
        public JsonResult Get(int page)
        {
            string query = @"select Id,Pedido,Bastidor,Modelo,Matricula,Fecha from dbo.CarsTable where Id <= " + page + @"";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CarConection");
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
        public JsonResult Post(Cars car)
        {
            string query = @"insert into dbo.CarsTable(Pedido,Bastidor,Modelo,Matricula,Fecha) values('"+car.Pedido+@"','"+car.Bastidor+@"','" + car.Modelo+ @"','"+car.Matricula+ @"','"+car.fecha+@"')";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CarConection");
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
            return new JsonResult("Added succesfuly");


        }


        [HttpPut]
        public JsonResult Put(Cars car)
        {
            string query = @"update dbo.CarsTable set 
                Pedido= '" + car.Pedido +@"'
                ,Bastidor= '"+ car.Bastidor +@"'
                ,Modelo= '"+ car.Modelo +@"'
                ,Matricula= '"+ car.Matricula +@"'
                ,Fecha= '"+ car.fecha + @"'
                where Id = " + car.id + @"";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CarConection");
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
            return new JsonResult("Update succesfuly");


        }


        [HttpDelete]
        public JsonResult Delete(Cars car)
        {
            string query = @"delete from dbo.CarsTable
                where Id = " + car.id + @"";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("CarConection");
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
            return new JsonResult("Delete succesfuly");


        }



        /*public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }*/

        // GET api/<CarsController>/5
        /*[HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CarsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
