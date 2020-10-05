using Microsoft.Extensions.DependencyInjection;

namespace Authentication.Configuration.Injection.Contract
{
    /// <summary>
    /// Inject module.
    /// </summary>
    public interface IInjectModule
    {
        /// <summary>
        /// Load dependecies.
        /// </summary>
        /// <param name="services">Current service collection.</param>
        /// <returns>Updated service collection.</returns>
        IServiceCollection Load(IServiceCollection services);
    }
}
