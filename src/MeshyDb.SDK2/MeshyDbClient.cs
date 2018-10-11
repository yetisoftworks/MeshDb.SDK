﻿using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using MeshyDB.SDK.Services;

[assembly:InternalsVisibleTo("MeshyDB.SDK.Tests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace MeshyDB.SDK
{
    /// <summary>
    /// MeshyDB Client is used to connect with the MeshyDB REST API
    /// </summary>
    public class MeshyDBClient
    {
        /// <summary>
        /// Initializes a new instance of <seealso cref="MeshyDBClient"/> that is used to communicate with the MeshyDB REST API
        /// </summary>
        /// <param name="tenant">Name of MeshyDB tenant required for communication</param>
        /// <param name="publicKey">Public Api credential supplied from MeshyDB to communicate with tenant</param>
        /// <param name="privateKey">Private Api credential supplied from MeshyDB to communicate with tenant</param>
        /// <exception cref="ArgumentException">Thrown if any parameter is not configured</exception>
        public MeshyDBClient(string tenant, string publicKey, string privateKey)
        {
            if (string.IsNullOrWhiteSpace(tenant))
            {
                throw new ArgumentException($"{nameof(tenant)} was not supplied", nameof(tenant));
            }

            if (string.IsNullOrWhiteSpace(publicKey))
            {
                throw new ArgumentException($"{nameof(publicKey)} was not supplied", nameof(publicKey));
            }

            if (string.IsNullOrWhiteSpace(privateKey))
            {
                throw new ArgumentException($"{nameof(privateKey)} was not supplied", nameof(privateKey));
            }

            Tenant = tenant.Trim();

            ConfigureServices(publicKey.Trim(), privateKey.Trim());
        }

        /// <summary>
        /// Gets the name of the tenant for MeshyDB communication
        /// </summary>
        internal string Tenant { get; }

        /// <summary>
        /// Gets the Api Url configured for the supplied Tenant
        /// </summary>
        /// <returns>The configured tenant Api Url communication</returns>
        internal string GetApiUrl()
        {
            return Constants.TemplateApiUrl.Replace("{tenant}", this.Tenant);
        }

        /// <summary>
        /// Gets the Auth Url configured for the supplied Tenant
        /// </summary>
        /// <returns>The configured tenant Auth Url communication</returns>
        internal string GetAuthUrl()
        {
            return Constants.TemplateAuthUrl.Replace("{tenant}", this.Tenant);
        }

        /// <summary>
        /// Gets the service configured to communicate with tenant meshes endpoint
        /// </summary>
        public IMeshesService Meshes { get; private set; }

        /// <summary>
        /// Instantiates services used for api communication with required dependencies
        /// </summary>
        /// <param name="publicKey">Supplied Api public credential to configure the authentication service</param>
        /// <param name="privateKey">Supplied Api private credential to configure the authentication service</param>
        private void ConfigureServices(string publicKey, string privateKey)
        {
            var httpService = new HttpService();
            var authRequestService = new RequestService(httpService, this.GetAuthUrl());
            var tokenService = new TokenService(authRequestService, publicKey, privateKey);
            var requestService = new RequestService(httpService, this.GetApiUrl(), tokenService);
            Meshes = new MeshesService(requestService);
        }
    }
}
