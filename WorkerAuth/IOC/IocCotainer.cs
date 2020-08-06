using Microsoft.Extensions.DependencyInjection;


/// <summary>
/// so basically what this code wil do is it will alter the life cycle of the code which means the applicationdbcontext
/// </summary>

namespace WorkerAuth
{
    /// <summary>
    /// a shorthand class to get DI with a nice clean shorthand code
    /// </summary>
    
    public static class Ioc
    {
        /// <summary>
        /// the scoped version of applicationdb context
        /// </summary>
        public static ApplicationDbContext ApplicationDbContext => IocCotainer.Provider.GetService<ApplicationDbContext>();
    }
    
    /// <summary>
    /// the dependency injection container making use of the built in .net core service provider
    /// </summary>
    public class IocCotainer
    {
        
        /// <summary>
        /// the servicde provider for this application
        /// </summary>
        public static ServiceProvider Provider   { get; set; }

    }
}
