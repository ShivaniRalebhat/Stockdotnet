using CompanyServices.Model;
using CompanyServices.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyServices.Translator
{
    public static class CompanyTranslator
    {
        public static Company TranslateAsBooking(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new Company();
            //if (reader.IsColumnExists("id"))
            //    item.id = SqlHelper.GetNullableInt32(reader, "id");

            if (reader.IsColumnExists("companycode"))
                item.companycode = SqlHelper.GetNullableInt32(reader, "companycode");

            if (reader.IsColumnExists("companyname"))
                item.companyname = SqlHelper.GetNullableString(reader, "companyname");

            if (reader.IsColumnExists("comanyceo"))
                item.comanyceo = SqlHelper.GetNullableString(reader, "comanyceo");

            if (reader.IsColumnExists("turnover"))
                item.turnover = SqlHelper.GetNullableInt32(reader, "turnover");

            if (reader.IsColumnExists("stockexchange"))
                item.stockexchange = SqlHelper.GetNullableString(reader, "stockexchange");

            if (reader.IsColumnExists("website"))
                item.website = SqlHelper.GetNullableString(reader, "website");

            if (reader.IsColumnExists("isdelete"))
                item.isdelete = SqlHelper.GetBoolean(reader, "isdelete");


            return item;
        }

        public static List<Company> TranslateAsCompanyList(this SqlDataReader reader)
        {
            var list = new List<Company>();
            while (reader.Read())
            {
                list.Add(TranslateAsBooking(reader, true));
            }
            return list;
        }

    }
}
