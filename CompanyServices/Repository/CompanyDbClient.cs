using CompanyServices.Model;
using CompanyServices.Translator;
using CompanyServices.Translator.Utility;
using CompanyServices.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyServices.Repository
{
    public class CompanyDbClient
    {

        public List<Company> GetCompanyList(string connString)
        {
            return SqlHelper.ExtecuteProcedureReturnData<List<Company>>(connString, "GetCompanylist", r => r.TranslateAsCompanyList());
            // List<Airline> lt = new List<Airline>();
            //lt =  SqlHelper.ExtecuteProcedureReturnData<List<Airline>>(connString, "getflightlist", r => r.TranslateAsUsersList());
            // string fromplace = "Pune";
            // return lt.Where(p => p.fromplace  == fromplace).ToList();
        }

        public List<StockModel> info(int companycode, string connString)
        {
            //SqlParameter[] param = {
            //new SqlParameter("@companycode",companycode)};

            //return SqlHelper.ExtecuteProcedureReturnData<List<Company>>(connString, "GetSelectedCompanydetails", r => r.TranslateAsCompanyList(), param);

            SqlParameter[] param = {
            new SqlParameter("@companycode",companycode),
            
            };

            //SqlHelper.ExecuteProcedureReturnString(connString, "stocklistoncompanycode", param);
            return SqlHelper.ExtecuteProcedureReturnData(connString, "stocklistoncompanycode", r => r.TranslateAsStockListList(), param);

        }

        public int register(Company model, string connString)
        {
            string res = "";
            //DateTime dateTime = DateTime.Now;
            //res = model.emailid + '_' + dateTime;
           // string[] text = res.Split(" ");
            //var a = text[0];
            //var b = text[1];
           // model.PNR = a + b;
            var outparam = new SqlParameter("@response", SqlDbType.Int)
            { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] param = {
                new SqlParameter("@companycode",model.companycode),
            new SqlParameter("@companyname",model.companyname),
            new SqlParameter("@comanyceo",model.comanyceo),
            new SqlParameter("@website",model.website),
            new SqlParameter("@turnover",model.turnover),
            new SqlParameter("@stockexchange",model.stockexchange),
            new SqlParameter("@isdelete",model.isdelete),
            outparam};

            SqlHelper.ExecuteProcedureReturnString(connString, "savecompanydetails", param);
            return (int)outparam.Value;
            // return outparam.Value();
            //return (string)outparam.SqlValue();
        }

        public int deletecompany(int companycode, string connString)
        {
            string res = "";
            //DateTime dateTime = DateTime.Now;
            //res = model.emailid + '_' + dateTime;
            // string[] text = res.Split(" ");
            //var a = text[0];
            //var b = text[1];
            // model.PNR = a + b;
            var outparam = new SqlParameter("@response", SqlDbType.Int)
            { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] param = {
            new SqlParameter("@companycode",companycode),
            outparam};

            SqlHelper.ExecuteProcedureReturnString(connString, "deletecompanydetails", param);
            return (int)outparam.Value;
            // return outparam.Value();
            //return (string)outparam.SqlValue();
        }

        public int addstock(StockModel model, string connString)
        {
            string res = "";
            var outparam = new SqlParameter("@response", SqlDbType.Int)
            { Direction = System.Data.ParameterDirection.Output };
            SqlParameter[] param = {
            new SqlParameter("@companycode",model.companycode),
            new SqlParameter("@stockprice",model.stockprice),
            new SqlParameter("@startdate",model.startdate),
            new SqlParameter("@enddate",model.enddate),
            outparam};

            SqlHelper.ExecuteProcedureReturnString(connString, "AddStock", param);
            return (int)outparam.Value;
        }

        public List<StockModel> get(int companycode, DateTime startdate,DateTime enddate, string connString)
        {
           
            SqlParameter[] param = {
            new SqlParameter("@companycode",companycode),
            new SqlParameter("@startdate",startdate),
              new SqlParameter("@enddate",enddate),
            };

            //SqlHelper.ExecuteProcedureReturnString(connString, "searchstock", param);
            return SqlHelper.ExtecuteProcedureReturnData(connString, "searchstock", r => r.TranslateAsStockListList(),param);
            //return (int)outparam.Value;
            // return outparam.Value();
            //return (string)outparam.SqlValue();
        }

        public List<Company> GetCompanydrpdwn(string connString)
        {
            //SqlParameter[] param = {
            //new SqlParameter("@companycode",companycode)};

            return SqlHelper.ExtecuteProcedureReturnData<List<Company>>(connString, "GetCompanydrpdwn", r => r.TranslateAsCompanyList());

        }

    }
}
