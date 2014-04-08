using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using AsyncRegexHelper;
using JsonUtilNS;

namespace HttpCore
{
    /// <summary>
    /// http处理基类
    /// 抽象类
    /// 封装http访问参数对象和帮助对象
    /// 通过继承，实现方便、可扩展和可维护的具体访问类
    /// </summary>
    public class BaseControl
    {

        #region 访问参数

        /// <summary>
        /// 访问实体
        /// </summary>
        protected HttpItem CurrentHttpItem { get; set; }

        /// <summary>
        /// 访问执行
        /// </summary>
        protected HttpHelper CurrentHttpHelper { get; set; }

        #endregion

        #region 访问参数设置（设置HttpItem & URL）

        //设置访问实体
        /// <summary>
        /// 设置访问实体
        /// </summary>
        /// <param name="encoding">编码</param>
        /// <param name="method">Get | Post</param>
        /// <param name="userAgent">默认</param>
        /// <param name="accept">默认</param>
        /// <param name="contentType">内容类型：text/html</param>
        /// <param name="resultType">返回值类型：ResultType.String</param>
        /// <param name="allowautoredirect">允许重定向</param>
        /// <param name="cookieString">cookie</param>
        public virtual void SetHttpItem(Encoding encoding = null, string method = "GET", string userAgent = "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/29.0.1547.22 Safari/537.36",
                                        string accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
                                        string contentType = "text/html",
                                        ResultType resultType = ResultType.String,
                                        bool allowautoredirect = false,
                                        string cookieString = "")
        {
            CurrentHttpItem.ContentType = contentType;
            CurrentHttpItem.Method = method;
            CurrentHttpItem.UserAgent = userAgent;
            CurrentHttpItem.Accept = accept;
            CurrentHttpItem.Encoding = encoding ?? Encoding.UTF8;
            CurrentHttpItem.ResultType = resultType;
            CurrentHttpItem.Allowautoredirect = allowautoredirect;
            CurrentHttpItem.Cookie = cookieString;
        }

        //设置访问url
        /// <summary>
        /// 设置访问url
        /// </summary>
        /// <param name="url"></param>
        public virtual void SetUrl(string url)
        {
            CurrentHttpItem.URL = url;
        }

        #endregion

        #region 抓取网页源码

        //根据设置抓取网页源码
        /// <summary>
        /// 根据设置抓取网页源码
        /// </summary>
        /// <returns></returns>
        protected virtual string GetHtml()
        {
            return CurrentHttpHelper.GetHtml(CurrentHttpItem).Html;
        }

        #endregion

        #region 匹配获取需要的数据 UseRegex

        /// <summary>
        /// 匹配单个正则
        /// </summary>
        /// <param name="html">待匹配html</param>
        /// <param name="reg">正则</param>
        /// <returns>匹配结果</returns>
        protected virtual MatchCollection Match(string html, string reg)
        {
            var regex = new Regex(reg, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant);
            //异步的正则匹配（2000是超时时间）
            return new AsynchronousRegex(2000).Matchs(regex, html);
        }

        /// <summary>
        /// 匹配返回实体（json-> entity）
        /// </summary>
        /// <typeparam name="T">待返回实体</typeparam>
        /// <param name="jsonResult"></param>
        /// <param name="hasError"></param>
        /// <returns>T</returns>
        protected virtual T Match<T>(string jsonResult, out bool hasError)
        {
            try
            {
                hasError = false;
                jsonResult = jsonResult.Trim('[').Trim("]\n".ToArray());
                return JsonUtil.ConvertToObject<T>(jsonResult);
            }
            catch (Exception)
            {
                hasError = true;
                return default(T);
            }
        }

        /// <summary>
        /// 匹配返回实体列表（json-> entity list）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonResult"></param>
        /// <returns></returns>
        protected virtual List<T> Match<T>(string jsonResult)
        {
            try
            {
                //jsonResult = jsonResult.Trim('[').Trim("]\n".ToArray());
                return JsonUtil.ConvertToObject<List<T>>(jsonResult);
            }
            catch (Exception)
            {
                return new List<T>();
            }
        }

        #endregion

    }
}
