namespace Vsk.VooDoo.Core.Attributes
{
    using Microsoft.AspNetCore.Mvc;

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Interface, AllowMultiple = true, Inherited = true)]
    public class InterfaceRouteAttribute : RouteAttribute
    {
        public InterfaceRouteAttribute(string prefix)
            : base(prefix)
        {
        }
    }
}
