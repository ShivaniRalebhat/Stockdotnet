using CompanyServices.Model;
using CompanyServices.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyServices.Translator.Utility
{
    public static class StockTranslator
    {
        public static StockModel TranslateAsStock(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new StockModel();
            //if (reader.IsColumnExists("id"))
            //    item.id = SqlHelper.GetNullableInt32(reader, "id");

            if (reader.IsColumnExists("companycode"))
                item.companycode = SqlHelper.GetNullableInt32(reader, "companycode");

            if (reader.IsColumnExists("startdate"))
                item.startdate = SqlHelper.GetNullableDatetime(reader, "startdate");

            if (reader.IsColumnExists("enddate"))
                item.enddate = SqlHelper.GetNullableDatetime(reader, "enddate");

            if (reader.IsColumnExists("stockprice"))
                item.stockprice = SqlHelper.GetNullableInt32(reader, "stockprice");

            
            return item;
        }

        public static List<StockModel> TranslateAsStockListList(this SqlDataReader reader)
        {
            var list = new List<StockModel>();
            while (reader.Read())
            {
                list.Add(TranslateAsStock(reader, true));
            }
            return list;
        }
    }
}
