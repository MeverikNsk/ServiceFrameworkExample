namespace Vsk.VooDoo.Core.Routing
{
    using Microsoft.AspNetCore.Mvc.Filters;
    using System;
    using System.Threading.Tasks;

    public class VooDooControllerResultFilter : IAsyncResultFilter, IOrderedFilter
    {
        // Controller-filter methods run farthest from the result by default.

        /// <inheritdoc />
        public int Order { get; set; } = int.MinValue;

        /// <inheritdoc />
        public Task OnResultExecutionAsync(
            ResultExecutingContext context,
            ResultExecutionDelegate next)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(next);

            var controller = context.Controller ?? throw new InvalidOperationException("controller");

            if (controller is IAsyncResultFilter asyncResultFilter)
            {
                return asyncResultFilter.OnResultExecutionAsync(context, next);
            }
            else if (controller is IResultFilter resultFilter)
            {
                return ExecuteResultFilter(context, next, resultFilter);
            }
            else
            {
                return next();
            }
        }

        private static async Task ExecuteResultFilter(
            ResultExecutingContext context,
            ResultExecutionDelegate next,
            IResultFilter resultFilter)
        {
            resultFilter.OnResultExecuting(context);
            if (!context.Cancel)
            {
                resultFilter.OnResultExecuted(await next());
            }
        }
    }
}
