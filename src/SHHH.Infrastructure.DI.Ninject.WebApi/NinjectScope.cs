// <copyright file="NinjectScope.cs" company="SHHH Innovations">
//   Copyright © SHHH Innovations. All rights reserved.
// </copyright>

namespace SHHH.Infrastructure.DI.Ninject.WebApi
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Web.Http.Dependencies;
    using global::Ninject.Activation;
    using global::Ninject.Parameters;
    using global::Ninject.Syntax;

    /// <summary>
    /// Ninject Scope
    /// </summary>
    [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Generated code")]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
    public class NinjectScope : IDependencyScope
    {
        /// <summary>
        /// The resolution root
        /// </summary>
        private IResolutionRoot resolutionRoot;

        /// <summary>
        /// Initializes a new instance of the <see cref="NinjectScope" /> class.
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        public NinjectScope(IResolutionRoot kernel)
        {
            this.resolutionRoot = kernel;
        }

        /// <summary>
        /// Retrieves a service from the scope.
        /// </summary>
        /// <param name="serviceType">The service to be retrieved.</param>
        /// <returns>
        /// The retrieved service.
        /// </returns>
        public object GetService(Type serviceType)
        {
            var request = this.CreateRequest(serviceType);
            return this.resolutionRoot.Resolve(request).SingleOrDefault();
        }

        /// <summary>
        /// Retrieves a collection of services from the scope.
        /// </summary>
        /// <param name="serviceType">The collection of services to be retrieved.</param>
        /// <returns>
        /// The retrieved collection of services.
        /// </returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            var request = this.CreateRequest(serviceType);
            return this.resolutionRoot.Resolve(request).ToList();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        [SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "Generated code")]
        public void Dispose()
        {
            var disposable = this.resolutionRoot as IDisposable;
            if (disposable == null)
            {
                return;
            }

            disposable.Dispose();
            this.resolutionRoot = null;
        }

        /// <summary>
        /// Creates the request.
        /// </summary>
        /// <param name="serviceType">Type of the service.</param>
        /// <returns><see>
        ///         <cref>global::Ninject.Activation.IRequest</cref>
        ///     </see>
        /// </returns>
        private IRequest CreateRequest(Type serviceType)
        {
            return this.resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
        }
    }
}