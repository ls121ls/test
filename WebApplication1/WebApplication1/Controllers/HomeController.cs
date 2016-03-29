using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Common;
using Model;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {  
        //48小时阅读排行
        string url = "http://wcf.open.cnblogs.com/blog/48HoursTopViewPosts/2";
        //分页获取推荐博客列表
        string url1 = "http://wcf.open.cnblogs.com/blog/bloggers/recommend/1/10";
        //获取推荐博客总数
        string url2 = "http://wcf.open.cnblogs.com/blog/bloggers/recommend/count";
        //根据作者名搜索博主
        string url3 = "http://wcf.open.cnblogs.com/blog/bloggers/search?t=Launcher";
        //获取文章评论
        string url4 = "http://wcf.open.cnblogs.com/blog/post/5293928/comments/1/10";

        //获取文章内容
        string url5 = "http://wcf.open.cnblogs.com/blog/post/body/5293928";
        //分页获取首页文章列表
        string url6 = "http://wcf.open.cnblogs.com/blog/sitehome/paged/1/10";
        //获取首页文章列表
        string url7 = "http://wcf.open.cnblogs.com/blog/sitehome/recent/10";
        //10天内推荐排行
        string url8 = "http://wcf.open.cnblogs.com/blog/TenDaysTopDiggPosts/10";
        //分页获取个人博客文章列表
        string url9 = "http://wcf.open.cnblogs.com/blog/u/Launchercher/posts/1/10";

        private string urlString = "";

        #region 测试

        public ActionResult Index()
        {
            //分页获取首页文章列表
            string url6 = "http://wcf.open.cnblogs.com/blog/sitehome/paged/1/10";
            HttpClient httpClient = new HttpClient();

            Stream stream = httpClient.GetStreamAsync(url6).Result;
            feed bookStore = (feed) XmlUtil.Deserialize(typeof (feed), stream);
            stream.Close();
            return View(bookStore);
        }

        public ActionResult About(string id)
        {
            string content = "";
            ManageContext db = new ManageContext();
            Article a = db.Articles.FirstOrDefault(d => d.Id == id);
            if (a == null)
            {
                //获取文章内容
                string url5 = "http://wcf.open.cnblogs.com/blog/post/body/" + id;
                HttpClient httpClient = new HttpClient();

                Stream stream = httpClient.GetStreamAsync(url5).Result;
                content = (string) XmlUtil.Deserialize(typeof (string), stream);
                stream.Close();

                db.Articles.Add(new Article() {Id = id, Content = content});
                db.SaveChanges();
            }
            else
            {
                content = a.Content;
            }
            ViewBag.Content = content;
            return View();
        }

        #endregion

        //48小时阅读排行
        public ActionResult FortyEight()
        {
            urlString = "http://wcf.open.cnblogs.com/blog/48HoursTopViewPosts/200";
            HttpClient httpClient = new HttpClient();

            Stream stream = httpClient.GetStreamAsync(urlString).Result;
            feed bookStore = (feed)XmlUtil.Deserialize(typeof(feed), stream);
            stream.Close();
            return View(bookStore);
        }
        //分页获取推荐博客列表
        public ActionResult RecommendPaging()
        {
            urlString = "http://wcf.open.cnblogs.com/blog/sitehome/paged/1/10";
            HttpClient httpClient = new HttpClient();

            Stream stream = httpClient.GetStreamAsync(urlString).Result;
            feed bookStore = (feed)XmlUtil.Deserialize(typeof(feed), stream);
            stream.Close();
            return View(bookStore);
        }
        //获取推荐博客总数
        public ActionResult RecommendTotal()
        {
            urlString = "http://wcf.open.cnblogs.com/blog/bloggers/recommend/count";
            HttpClient httpClient = new HttpClient();

            Stream stream = httpClient.GetStreamAsync(urlString).Result;
            int result = (int)XmlUtil.Deserialize(typeof(int), stream);
            stream.Close();
            return View(result);
        }
        //根据作者名搜索博主
        public ActionResult SearchBloger()
        {
            urlString = "http://wcf.open.cnblogs.com/blog/bloggers/search?t=Launcher";
            HttpClient httpClient = new HttpClient();

            Stream stream = httpClient.GetStreamAsync(urlString).Result;
            feed bookStore = (feed)XmlUtil.Deserialize(typeof(feed), stream);
            stream.Close();
            return View(bookStore);
        }
        //获取文章评论
        public ActionResult GetComments()
        {
            urlString = "http://wcf.open.cnblogs.com/blog/post/5293928/comments/1/10";
            HttpClient httpClient = new HttpClient();

            Stream stream = httpClient.GetStreamAsync(urlString).Result;
            feed bookStore = (feed)XmlUtil.Deserialize(typeof(feed), stream);
            stream.Close();
            return View(bookStore);
        }
        //获取文章内容
        public ActionResult GetContent()
        {
            urlString = "http://wcf.open.cnblogs.com/blog/post/body/5293928";
            HttpClient httpClient = new HttpClient();

            Stream stream = httpClient.GetStreamAsync(urlString).Result;
            feed bookStore = (feed)XmlUtil.Deserialize(typeof(feed), stream);
            stream.Close();
            return View(bookStore);
        }
        //分页获取首页文章列表
        public ActionResult ArticleIndexPaging()
        {
            urlString = "http://wcf.open.cnblogs.com/blog/sitehome/paged/1/10";
            HttpClient httpClient = new HttpClient();

            Stream stream = httpClient.GetStreamAsync(urlString).Result;
            feed bookStore = (feed)XmlUtil.Deserialize(typeof(feed), stream);
            stream.Close();
            return View(bookStore);
        }
        //获取首页文章列表
        public ActionResult ArticleIndexList()
        {
            urlString = "http://wcf.open.cnblogs.com/blog/sitehome/recent/10";
            HttpClient httpClient = new HttpClient();

            Stream stream = httpClient.GetStreamAsync(urlString).Result;
            feed bookStore = (feed)XmlUtil.Deserialize(typeof(feed), stream);
            stream.Close();
            return View(bookStore);
        }    
        //10天内推荐排行
        public ActionResult TenDaysTop()
        {
            urlString = "http://wcf.open.cnblogs.com/blog/TenDaysTopDiggPosts/10";
            HttpClient httpClient = new HttpClient();

            Stream stream = httpClient.GetStreamAsync(urlString).Result;
            feed bookStore = (feed)XmlUtil.Deserialize(typeof(feed), stream);
            stream.Close();
            return View(bookStore);
        }
        //分页获取个人博客文章列表
        public ActionResult PersonalBlog()
        {
            urlString = "http://wcf.open.cnblogs.com/blog/u/dashuailuoli/posts/1/10";
            HttpClient httpClient = new HttpClient();

            Stream stream = httpClient.GetStreamAsync(urlString).Result;
            feed bookStore = (feed)XmlUtil.Deserialize(typeof(feed), stream);
            stream.Close();
            return View(bookStore);
        }
    }
}