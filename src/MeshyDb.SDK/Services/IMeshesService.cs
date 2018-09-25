﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using MeshyDb.SDK.Models;

namespace MeshyDb.SDK.Services
{
    /// <summary>
    /// Defines methods for meshes
    /// </summary>
    public interface IMeshesService
    {
        /// <summary>
        /// Get mesh data for a given id
        /// </summary>
        /// <typeparam name="TModel">Type of mesh data to be returned</typeparam>
        /// <param name="mesh">Name of mesh to be retrieved</param>
        /// <param name="id">Identifier of mesh record to be retrieved</param>
        /// <returns>Data result of request</returns>
        TModel Get<TModel>(string mesh, string id) where TModel : MeshData;

        /// <summary>
        /// Get mesh data for a given id
        /// </summary>
        /// <typeparam name="TModel">Type of mesh data to be returned</typeparam>
        /// <param name="mesh">Name of mesh to be retrieved</param>
        /// <param name="id">Identifier of mesh record to be retrieved</param>
        /// <returns>Data result of request</returns>
        Task<TModel> GetAsync<TModel>(string mesh, string id) where TModel : MeshData;

        /// <summary>
        /// Searches mesh data for a given filter
        /// </summary>
        /// <typeparam name="TModel">Type of mesh data to be returned</typeparam>
        /// <param name="mesh">Name of mesh to be searched</param>
        /// <param name="filter">Filter of data in mongo db filter format</param>
        /// <param name="page">Page number to find results on</param>
        /// <param name="pageSize">Number of items to bring back from search</param>
        /// <returns>Page result data for the given mesh with applied filter</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        PageResult<TModel> Search<TModel>(string mesh, string filter = null, int page = 1, int pageSize = 200) where TModel : MeshData;

        /// <summary>
        /// Searches mesh data for a given filter
        /// </summary>
        /// <typeparam name="TModel">Type of mesh data to be returned</typeparam>
        /// <param name="mesh">Name of mesh to be searched</param>
        /// <param name="filter">Filter of data in mongo db filter format</param>
        /// <param name="page">Page number to find results on</param>
        /// <param name="pageSize">Number of items to bring back from search</param>
        /// <returns>Page result data for the given mesh with applied filter</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        Task<PageResult<TModel>> SearchAsync<TModel>(string mesh, string filter = null, int page = 1, int pageSize = 200) where TModel : MeshData;

        /// <summary>
        /// Searches mesh data for a given filter
        /// </summary>
        /// <typeparam name="TModel">Type of mesh data to be returned</typeparam>
        /// <param name="mesh">Name of mesh to be searched</param>
        /// <param name="filter">Filter predicate for data</param>
        /// <param name="page">Page number to find results on</param>
        /// <param name="pageSize">Number of items to bring back from search</param>
        /// <returns>Page result data for the given mesh with applied filter</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        PageResult<TModel> Search<TModel>(string mesh, Expression<Func<TModel, bool>> filter, int page = 1, int pageSize = 200) where TModel : MeshData;

        /// <summary>
        /// Searches mesh data for a given filter
        /// </summary>
        /// <typeparam name="TModel">Type of mesh data to be returned</typeparam>
        /// <param name="mesh">Name of mesh to be searched</param>
        /// <param name="filter">Filter predicate for data</param>
        /// <param name="page">Page number to find results on</param>
        /// <param name="pageSize">Number of items to bring back from search</param>
        /// <returns>Page result data for the given mesh with applied filter</returns>
        /// <remarks>
        /// The maximum page size is 200.
        /// </remarks>
        Task<PageResult<TModel>> SearchAsync<TModel>(string mesh, Expression<Func<TModel, bool>> filter, int page = 1, int pageSize = 200) where TModel : MeshData;

        /// <summary>
        /// Create mesh data
        /// </summary>
        /// <typeparam name="TModel">Type of mesh data to be returned</typeparam>
        /// <param name="mesh">Name of mesh to be retrieved</param>
        /// <param name="model">Mesh data to be commited</param>
        /// <returns>Result of committed mesh data</returns>
        TModel Create<TModel>(string mesh, TModel model) where TModel : MeshData;

        /// <summary>
        /// Create mesh data
        /// </summary>
        /// <typeparam name="TModel">Type of mesh data to be returned</typeparam>
        /// <param name="mesh">Name of mesh to be commited</param>
        /// <param name="model">Mesh data to be commited</param>
        /// <returns>Result of committed mesh data</returns>
        Task<TModel> CreateAsync<TModel>(string mesh, TModel model) where TModel : MeshData;

        /// <summary>
        /// Update mesh data for a given id
        /// </summary>
        /// <typeparam name="TModel">Type of mesh data to be returned</typeparam>
        /// <param name="mesh">Name of mesh to be updated</param>
        /// <param name="id">Identifier of mesh record to be updated</param>
        /// <param name="model">Mesh data to be updated</param>
        /// <returns>Result of updated mesh data</returns>
        TModel Update<TModel>(string mesh, string id, TModel model) where TModel : MeshData;

        /// <summary>
        /// Update mesh data for a given id
        /// </summary>
        /// <typeparam name="TModel">Type of mesh data to be returned</typeparam>
        /// <param name="mesh">Name of mesh to be updated</param>
        /// <param name="id">Identifier of mesh record to be updated</param>
        /// <param name="model">Mesh data to be updated</param>
        /// <returns>Result of updated mesh data</returns>
        Task<TModel> UpdateAsync<TModel>(string mesh, string id, TModel model) where TModel : MeshData;

        /// <summary>
        /// Get mesh data for a given id
        /// </summary>
        /// <param name="mesh">Name of mesh to be deleted</param>
        /// <param name="id">Identifier of mesh record to be deleted</param>
        void Delete(string mesh, string id);

        /// <summary>
        /// Get mesh data for a given id
        /// </summary>
        /// <param name="mesh">Name of mesh to be deleted</param>
        /// <param name="id">Identifier of mesh record to be deleted</param>
        Task DeleteAsync(string mesh, string id);
    }
}
