namespace StudentsLearning.Server.Api.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;

    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class CheckNullAttribute : ActionFilterAttribute
    {
        private readonly Func<Dictionary<string, object>, bool> validate;

        public CheckNullAttribute()
            : this(arguments => arguments.ContainsValue(null))
        {

        }

        public CheckNullAttribute(Func<Dictionary<string, object>, bool> checkCondition)
        {
            this.validate = checkCondition;
        }

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (this.validate(actionContext.ActionArguments))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
       HttpStatusCode.BadRequest, "The argument cannot be null");
            }
        }
    }
}