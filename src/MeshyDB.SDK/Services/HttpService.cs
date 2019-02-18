﻿using MeshyDB.SDK.Models;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MeshyDB.SDK.Services
{
    /// <summary>
    /// Implementation of <see cref="IHttpService"/>
    /// </summary>
    internal class HttpService : IHttpService
    {
        HttpClient _client = new HttpClient();
     
        /// <inheritdoc/>
        public async Task<T> SendRequestAsync<T>(HttpServiceRequest request)
        {
            var httpClient = _client;
            var message = new HttpRequestMessage();

            message.Method = request.Method;

            message.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            message.RequestUri = request.RequestUri;

            if (!string.IsNullOrEmpty(request.Content))
            {
                message.Content = new StringContent(request.Content, Encoding.UTF8, request.ContentType);
            }

            if (request.Headers.TryGetValue("Authorization", out var token))
            {
                message.Headers.Add("Authorization", token);
            }

            var response = await httpClient.SendAsync(message);
            response = response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
