using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PersonalBlog.Interface;

namespace PersonalBlog.Services
{
    public class ProtectorAttribute : Attribute, IActionFilter
    {
        private readonly IAuthorize _authorizer;

        public ProtectorAttribute(IAuthorize authorizer)
        {
            _authorizer = authorizer;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (!_authorizer.IsAuthorized())
            {
                context.Result = new RedirectToActionResult("Error", "Home", null);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
