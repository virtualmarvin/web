using Microsoft.AspNetCore.Mvc;

namespace Marvin.Web.Areas.Landing
{
    public class Error : BaseModel
    {
        #region Handlers

        public override IActionResult Get()
        {
            try 
            { 
                return View(); 
            }
            catch 
            { 
                return LocalRedirect("/error.htm"); 
            }
        }

        #endregion
    }
}
