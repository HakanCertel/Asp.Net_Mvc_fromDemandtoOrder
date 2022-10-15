using Microsoft.AspNetCore.Mvc;
using Senfoni.Data.Concrete.EfCore;
using Senfoni.Entity.Dto;

namespace Senfoni.Satis.Webui.Controllers
{
    public class StokController : Controller
    {
        private IBaseBll bll;

        public StokController()
        {
            bll = new StokBll();
        }
        public IActionResult Index()
        {
            var stokList = ((StokBll)bll).List(null).EntityListConvert<StokL>(); 
            return View(stokList);
        }
    }
}