using Microsoft.AspNetCore.Mvc;

namespace Senfoni.Satis.Webui.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        

        public CategoriesViewComponent()
        {
            
        }
        public IViewComponentResult Invoke()
        {
            if (RouteData.Values["category"] != null)
                ViewBag.SelectedCategory = RouteData?.Values["category"];
            
            //if (RouteData.Values["action"].ToString() == "List")
            //    ViewBag.SelectedCategory = RouteData?.Values["id"];
            return View(/*_categoryService.GetAll()*/);
        }
    }
}