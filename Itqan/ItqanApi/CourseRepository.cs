using Itqan.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Itqan.ItqanApi
{
    public class CourseRepository : IDisposable
    {
        private PlatformDBContext _context;
        private HttpContext _httpContext;
        public CourseRepository(HttpContext httpContext)
        {
            _context = new PlatformDBContext();
            _httpContext = httpContext;
        }

        public void Dispose()
        {
            _context.Dispose();
            _httpContext = null;
        }
        public IEnumerable<Tutorial> GetTutorials()
        {
            var _currentDate = DateTime.Now;
            //var langCode = "";
            //HttpCookie langCookie = _httpContext.Request.Cookies["culture"];

            //if (langCookie != null)
            //{
            //    langCode = langCookie.Value;
            //}
            //else
            //{
            //    langCode = "En";
            //}
            var db = new ItqanEntities();
            var userLang = _httpContext.Request.Cookies["userLang"];
            var langId =(userLang !=null && userLang["lang"]!=null)? userLang["lang"]:"ar";
            var langCode = db.Lang1.FirstOrDefault(a => a.Code == langId).Code.ToString();
            var tutorials = new List<Tutorial>();
            using (var ctx = new PlatformDBContext())
            {
                tutorials = ctx.Tutorials.Where(m => m.CloseDate > _currentDate && m.LangCode == langCode && m.Active).ToList();

            }
            return tutorials;
        }
    }
}