namespace Vsk.VooDoo.Core.Attributes
{
    using Microsoft.AspNetCore.Mvc.Routing;
    using VooDoo.Core.Extensions;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class RouteWithoutAsyncAttribute : Attribute, IRouteTemplateProvider
    {
        private int? _order;

        /// <summary>
        /// Creates a new <see cref="RouteAttribute"/> with the given route template.
        /// </summary>
        /// <param name="template">Шаблон маршрута. Может быть null.</param>
        /// <param name="isLowercase">Перевод в нижний регистр</param>
        public RouteWithoutAsyncAttribute(string template, bool isLowercase = false)
        {
            Template = template?.RemoveAsync() ?? throw new ArgumentNullException(nameof(template));

            if (isLowercase)
            {
                Template = Template.ToLower();
            }
        }

        /// <inheritdoc />
        public string Template { get; }

        /// <summary>
        /// Gets the route order. The order determines the order of route execution. Routes with a lower order
        /// value are tried first. If an action defines a route by providing an <see cref="IRouteTemplateProvider"/>
        /// with a non <c>null</c> order, that order is used instead of this value. If neither the action nor the
        /// controller defines an order, a default value of 0 is used.
        /// </summary>
        public int Order
        {
            get { return _order ?? 0; }
            set { _order = value; }
        }

        /// <inheritdoc />
        int? IRouteTemplateProvider.Order => _order;

        /// <inheritdoc />
        public string? Name { get; set; }
    }
}
