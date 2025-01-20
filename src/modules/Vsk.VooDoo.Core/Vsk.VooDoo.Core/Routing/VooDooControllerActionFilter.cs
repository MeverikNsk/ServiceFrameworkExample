namespace Vsk.VooDoo.Core.Routing
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Threading.Tasks;

    public class VooDooControllerActionFilter : IAsyncActionFilter, IOrderedFilter
    {
        // Controller-filter methods run farthest from the action by default.

        /// <inheritdoc />
        public int Order { get; set; } = int.MinValue;

        /// <inheritdoc />
        public Task OnActionExecutionAsync(
            ActionExecutingContext context,
            ActionExecutionDelegate next)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(next);

            var controller = context.Controller ?? throw new InvalidOperationException("controller");

            if (controller is IAsyncActionFilter asyncActionFilter)
            {
                return asyncActionFilter.OnActionExecutionAsync(context, next);
            }
            else if (controller is IActionFilter actionFilter)
            {
                return ExecuteActionFilter(context, next, actionFilter);
            }
            else
            {
                return next();
            }
        }

        private static async Task ExecuteActionFilter(
            ActionExecutingContext context,
            ActionExecutionDelegate next,
            IActionFilter actionFilter)
        {
            actionFilter.OnActionExecuting(context);
            if (context.Result == null)
            {
                actionFilter.OnActionExecuted(await next());
            }
        }
    }
}
