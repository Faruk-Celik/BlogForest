using Microsoft.AspNetCore.Mvc;

namespace BlogForest.WebUI.ViewComponents.UserViewComponents
{
    public class _AboutAuthorUserComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
