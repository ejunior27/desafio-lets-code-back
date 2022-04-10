using LetsAuth.Models.Entities;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LetsBoard.Domain.Helpers
{
    public class LogAttribute : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {            
            context.ActionArguments.TryGetValue("id", out object id);
            Console.WriteLine($"{DateTime.Now} - Card {id} - {context.HttpContext.Request.Method}");
            await next();
        }
    }
}
