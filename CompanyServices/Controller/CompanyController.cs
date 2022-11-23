using CompanyServices.Model;
using CompanyServices.Repository;
using CompanyServices.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CompanyServices.Controller
{
    [Route("api/[controller]")]
    //[Route("v2")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        // private readonly IOptions<MySettingModel> appSettings;

        //public CompanyController(IOptions<MySettingModel> app)
        //{
        //    appSettings = app;
        //}
        private IConfiguration configuration;
        public CompanyController(IConfiguration iConfig)
        {
            configuration = iConfig;
        }


        [HttpGet]
        public ActionResult Demo()
        {
            return Ok(200);
           // return new string[] { "value1", "value2" };
        }

        [Route("GetCompanyList")]
        [HttpGet]
        public IActionResult GetCompanyList()
        {
            string dbConn2 = configuration.GetValue<string>("MySettings:DbConnection");
            
            var data = DbClientFactory<CompanyDbClient>.Instance.GetCompanyList(dbConn2);
            return Ok(data);
        }

        [Route("info")]
        [HttpGet]
        public IActionResult info(int companycode)
        {
            Company model = new Company();
            string dbConn2 = configuration.GetValue<string>("MySettings:DbConnection");
            var data = DbClientFactory<CompanyDbClient>.Instance.info(companycode, dbConn2);

            //foreach (var item in data)
            //{
            //    model.companycode = item.companycode;
            //    model.comanyceo = item.comanyceo;
            //    model.companyname = item.companyname;
            //    model.stockexchange = item.stockexchange;
            //    model.turnover = item.turnover;
            //    model.website = item.website;
            //    model.isdelete = item.isdelete;

            //}
            return Ok(data);
            //return StatusCode(Convert.ToInt32(HttpStatusCode.OK), new { data });
        }

        [Route("register")]
        [HttpPost]
        public IActionResult register([FromBody] Company model)
        {
             var msg = new MessageModel<Company>();
            string dbConn2 = configuration.GetValue<string>("MySettings:DbConnection");
            var data = DbClientFactory<CompanyDbClient>.Instance.register(model, dbConn2);
            if (data == 100)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Company Added Successfully";
            }

            return Ok(msg);
        }

        [Route("deletecompany")]
        [HttpPost]
        public IActionResult deletecompany(int companycode)
        {
             var msg = new MessageModel<Company>();
            string dbConn2 = configuration.GetValue<string>("MySettings:DbConnection");
            var data = DbClientFactory<CompanyDbClient>.Instance.deletecompany(companycode, dbConn2);
            if (data == 100)
            {
                msg.IsSuccess = true;
                msg.ReturnMessage = "Company deleted Successfully";
            }

            return Ok();
        }

        [Route("GetCompanydrpdwn")]
        [HttpGet]
        public IActionResult GetCompanydrpdwn()
        {
            Company model = new Company();
            string dbConn2 = configuration.GetValue<string>("MySettings:DbConnection");
            var data = DbClientFactory<CompanyDbClient>.Instance.GetCompanydrpdwn(dbConn2);

            //foreach (var item in data)
            //{
            //    model.companycode = item.companycode;
            //    model.comanyceo = item.comanyceo;
            //    model.companyname = item.companyname;
            //    model.stockexchange = item.stockexchange;
            //    model.turnover = item.turnover;
            //    model.website = item.website;
            //    model.isdelete = item.isdelete;

            //}

            //return StatusCode(Convert.ToInt32(HttpStatusCode.OK), new { model });
            return Ok(data);
        }


    }
}
