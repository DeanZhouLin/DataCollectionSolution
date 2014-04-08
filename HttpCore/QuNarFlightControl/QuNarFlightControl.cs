using System.Collections.Generic;
using System.Web;
using HttpCore.Annotations;

namespace HttpCore
{
    public sealed class QuNarFlightControl : BaseControl
    {
        private string FlightRegex { [UsedImplicitly] get; set; }

        private string UrlTemplate { get; set; }

        #region 构造区

        public QuNarFlightControl(string flightRegex, string urlTemplate)
        {
            FlightRegex = flightRegex;
            UrlTemplate = urlTemplate;
            CurrentHttpItem = new HttpItem();
            CurrentHttpHelper = new HttpHelper();
            SetHttpItem();
        }

        #endregion

        #region 方法区

        private void SetUrl(string from, string to, int getCount = 1)
        {
            CurrentHttpItem.URL = string.Format(UrlTemplate, HttpUtility.UrlEncode(from), HttpUtility.UrlEncode(to), getCount);
        }

        private string GetFlightHtml(string from, string to, int getCount = 1)
        {
            SetUrl(from, to, getCount);
            return CurrentHttpHelper.GetHtml(CurrentHttpItem).Html;
        }

        public QuNarFlightEntity GetLowestPriceEntity(string from = "上海", string to = "北京",
                                                      string regex = "\"entries\":\\s*(?<Flights>.*)\\s*,\"pageInfo\"")
        {
            var allHtml = GetFlightHtml(from, to);
            var matchJson = Match(allHtml, regex);
            bool hasError;
            var matchEntity = Match<QuNarFlightEntity>(matchJson[0].Groups["Flights"].Value.Trim(), out hasError);
            return matchEntity;
        }


        public List<QuNarFlightEntity> GetPriceEntityList(string from = "上海", string to = "北京", int getCount = 2,
                                                      string regex = "\"entries\":\\s*(?<Flights>.*)\\s*,\"pageInfo\"")
        {
            var allHtml = GetFlightHtml(from, to, getCount);
            var matchJson = Match(allHtml, regex);
            var matchEntity = Match<QuNarFlightEntity>(matchJson[0].Groups["Flights"].Value.Trim());
            return matchEntity;
        }

        #endregion

    }
}
