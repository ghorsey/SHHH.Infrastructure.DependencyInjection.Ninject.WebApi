// <copyright file="NinjectResolver.cs" company="SHHH Innovations">
//   Copyright © SHHH Innovations. All rights reserved.
// </copyright>

namespace SHHH.Infrastructure.DI.Ninject.WebApi
{
    using System.Diagnostics.CodeAnalysis;
    using System.Web.Http.Dependencies;
    using global::Ninject;

    /// <summary>
    /// Ninject Resolver
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        /// <summary>
        /// The kernel
        /// </summary>
        private readonly IKernel kernel;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectResolver" /> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        /// <summary>
        /// Starts a resolution scope.
        /// </summary>
        /// <returns>
        /// The dependency scope.
        /// </returns>
        public IDependencyScope BeginScope()
        {
            return new NinjectScope(this.kernel.BeginBlock());
        }
    }
}