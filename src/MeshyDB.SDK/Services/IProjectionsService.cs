﻿// <copyright file="IProjectionsService.cs" company="Yeti Softworks LLC">
// Copyright (c) Yeti Softworks LLC. All rights reserved.
// </copyright>

using System.Threading.Tasks;
using MeshyDB.SDK.Models;

namespace MeshyDB.SDK.Services
{
    /// <summary>
    /// Defines methods for projections.
    /// </summary>
    public interface IProjectionsService
    {
        /// <summary>
        /// Gets data for a given projection name.
        /// </summary>
        /// <typeparam name="TData">Type of data to be returned.</typeparam>
        /// <param name="projectionName">Name of projection to retrieve.</param>
        /// <param name="orderBy">Defines order for data.</param>
        /// <param name="page">Page number to find results on.</param>
        /// <param name="pageSize">Number of items to bring back from search.</param>
        /// <returns>Page result data for the given projection.</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        Task<PageResult<TData>> GetAsync<TData>(string projectionName, OrderByDefinition<TData> orderBy, int page = 1, int pageSize = 25)
            where TData : class;

        /// <summary>
        /// Gets data for a given projection name.
        /// </summary>
        /// <typeparam name="TData">Type of data to be returned.</typeparam>
        /// <param name="projectionName">Name of projection to retrieve.</param>
        /// <param name="page">Page number to find results on.</param>
        /// <param name="pageSize">Number of items to bring back from search.</param>
        /// <returns>Page result data for the given projection.</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        Task<PageResult<TData>> GetAsync<TData>(string projectionName, int page = 1, int pageSize = 25)
            where TData : class;

        /// <summary>
        /// Gets data for a given projection name.
        /// </summary>
        /// <typeparam name="TData">Type of data to be returned.</typeparam>
        /// <param name="projectionName">Name of projection to retrieve.</param>
        /// <param name="orderBy">Order data in Mongo DB sort format.</param>
        /// <param name="page">Page number to find results on.</param>
        /// <param name="pageSize">Number of items to bring back from search.</param>
        /// <returns>Page result data for the given projection.</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        Task<PageResult<TData>> GetAsync<TData>(string projectionName, string orderBy, int page = 1, int pageSize = 25)
            where TData : class;

        /// <summary>
        /// Gets data for a given projection name.
        /// </summary>
        /// <typeparam name="TData">Type of data to be returned.</typeparam>
        /// <param name="projectionName">Name of projection to retrieve.</param>
        /// <returns>Page result data for the given projection.</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        Task<PageResult<TData>> GetAsync<TData>(string projectionName)
            where TData : class;

        /// <summary>
        /// Gets data for a given projection name.
        /// </summary>
        /// <typeparam name="TData">Type of data to be returned.</typeparam>
        /// <param name="projectionName">Name of projection to retrieve.</param>
        /// <param name="orderBy">Defines order for data.</param>
        /// <param name="page">Page number to find results on.</param>
        /// <param name="pageSize">Number of items to bring back from search.</param>
        /// <returns>Page result data for the given projection.</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        PageResult<TData> Get<TData>(string projectionName, OrderByDefinition<TData> orderBy = null, int page = 1, int pageSize = 25)
            where TData : class;

        /// <summary>
        /// Gets data for a given projection name.
        /// </summary>
        /// <typeparam name="TData">Type of data to be returned.</typeparam>
        /// <param name="projectionName">Name of projection to retrieve.</param>
        /// <param name="page">Page number to find results on.</param>
        /// <param name="pageSize">Number of items to bring back from search.</param>
        /// <returns>Page result data for the given projection.</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        PageResult<TData> Get<TData>(string projectionName, int page = 1, int pageSize = 25)
            where TData : class;

        /// <summary>
        /// Gets data for a given projection name.
        /// </summary>
        /// <typeparam name="TData">Type of data to be returned.</typeparam>
        /// <param name="projectionName">Name of projection to retrieve.</param>
        /// <returns>Page result data for the given projection.</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        PageResult<TData> Get<TData>(string projectionName)
            where TData : class;

        /// <summary>
        /// Gets data for a given projection name.
        /// </summary>
        /// <typeparam name="TData">Type of data to be returned.</typeparam>
        /// <param name="projectionName">Name of projection to retrieve.</param>
        /// <param name="orderBy">Order data in Mongo DB sort format.</param>
        /// <param name="page">Page number to find results on.</param>
        /// <param name="pageSize">Number of items to bring back from search.</param>
        /// <returns>Page result data for the given projection.</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        PageResult<TData> Get<TData>(string projectionName, string orderBy, int page = 1, int pageSize = 25)
            where TData : class;
    }
}
