using CompanyServices.Model;
using CompanyServices.Repository;
using CompanyServices.Utility;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyServices.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private IConfiguration configuration;
        public StockController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }

        // GET: api/<StockController>
      
        [Route("Get")]
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StockController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StockController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StockController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [Route("add")]
        [HttpPost]
        public IActionResult add([FromBody] StockModel model)
        {
             var msg = new MessageModel<StockModel>();
            string dbConn2 = configuration.GetValue<string>("MySettings:DbConnection");
            var data = DbClientFactory<CompanyDbClient>.Instance.addstock(model, dbConn2);
            if (data == 100)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Stock Added Successfully";
            }

            return Ok(msg);
        }
        [Route("search")]
        [HttpGet]
        public IActionResult search(int companycode, DateTime startdate, DateTime enddate)
        {
           
            string dbConn2 = configuration.GetValue<string>("MySettings:DbConnection");
            var data = DbClientFactory<CompanyDbClient>.Instance.get(companycode, startdate, enddate, dbConn2);
           

            return Ok(data);
        }
    }
}
