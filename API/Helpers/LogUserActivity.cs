using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Extensions;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API.Helpers
{
    public class LogUserActivity : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var resultContext = await next();

            var username = resultContext.HttpContext.User.GetUsername();
            if (username == null) return;

            var repo = resultContext.HttpContext.RequestServices.GetService<IUserRepository>();

            if (repo == null) return;
            var user = await repo.GetUserByUsernameAsync(username);
            user.LastActive = DateTime.Now;
            await repo.SaveAllASync();
        }
    }
}