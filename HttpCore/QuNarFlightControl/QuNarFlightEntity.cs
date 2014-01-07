using System;
using System.Collections.Generic;
using System.Data;

namespace HttpCore
{
    [Serializable]
    public sealed class QuNarFlightEntity
    {
        public string fromCode { get; set; }
        public string price { get; set; }
        public string to { get; set; }
        public string toTime { get; set; }
        public string toCode { get; set; }
        public string discount { get; set; }
        public string proxy { get; set; }
        public string airCompany { get; set; }
        public string url { get; set; }
        public string from { get; set; }
        public string avc { get; set; }
        public string fromTime { get; set; }
    }

    public static class QuNarFlightEntityExtension
    {
        public static DataTable GenerateDataTableForQuNarFlightEntity(this IEnumerable<QuNarFlightEntity> items)
        {
            var dt = new DataTable();

            dt.Columns.Add("fromCode", typeof(string));
            dt.Columns.Add("price", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("toTime", typeof(string));
            dt.Columns.Add("toCode", typeof(string));
            dt.Columns.Add("discount", typeof(string));
            dt.Columns.Add("proxy", typeof(string));
            dt.Columns.Add("airCompany", typeof(string));
            dt.Columns.Add("url", typeof(string));
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("avc", typeof(string));
            dt.Columns.Add("fromTime", typeof(string));


            if (items != null)
            {
                foreach (var item in items)
                {
                    DataRow dataRow = dt.NewRow();
                    dataRow["fromCode"] = item.fromCode;
                    dataRow["price"] = item.price;
                    dataRow["to"] = item.to;
                    dataRow["toTime"] = item.toTime;
                    dataRow["toCode"] = item.toCode;
                    dataRow["discount"] = item.discount;
                    dataRow["proxy"] = item.proxy;
                    dataRow["airCompany"] = item.airCompany;
                    dataRow["url"] = item.url;
                    dataRow["from"] = item.from;
                    dataRow["avc"] = item.avc;
                    dataRow["fromTime"] = item.fromTime;
                    dt.Rows.Add(dataRow);
                }
            }
            return dt;
        }

        public static DataTable GenerateDataTableForQuNarFlightEntity(this QuNarFlightEntity item)
        {
            var dt = new DataTable();

            dt.Columns.Add("fromCode", typeof(string));
            dt.Columns.Add("price", typeof(string));
            dt.Columns.Add("to", typeof(string));
            dt.Columns.Add("toTime", typeof(string));
            dt.Columns.Add("toCode", typeof(string));
            dt.Columns.Add("discount", typeof(string));
            dt.Columns.Add("proxy", typeof(string));
            dt.Columns.Add("airCompany", typeof(string));
            dt.Columns.Add("url", typeof(string));
            dt.Columns.Add("from", typeof(string));
            dt.Columns.Add("avc", typeof(string));
            dt.Columns.Add("fromTime", typeof(string));


            if (item != null)
            {
                DataRow dataRow = dt.NewRow();
                dataRow["fromCode"] = item.fromCode;
                dataRow["price"] = item.price;
                dataRow["to"] = item.to;
                dataRow["toTime"] = item.toTime;
                dataRow["toCode"] = item.toCode;
                dataRow["discount"] = item.discount;
                dataRow["proxy"] = item.proxy;
                dataRow["airCompany"] = item.airCompany;
                dataRow["url"] = item.url;
                dataRow["from"] = item.from;
                dataRow["avc"] = item.avc;
                dataRow["fromTime"] = item.fromTime;
                dt.Rows.Add(dataRow);

            }
            return dt;
        }
    }
}
