﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ConAppPlayingWithRestSharp.Errors;
using RestSharp;

namespace ConAppPlayingWithRestSharp.Service;

public interface IApiService 
{
    Task<T?> GetAsync<T>(string endpoint) where T: new();
}

public class ApiService : IApiService
{
    private readonly RestClient _client;

    public ApiService(RestClient client)
    {
        _client = client;
    }

    public async Task<T?> GetAsync<T>(string endpoint) where T : new()
    {
        var request = new RestRequest(endpoint, Method.Get);

        var response = await _client.ExecuteAsync<T>(request);

        if (!response.IsSuccessful)
        {
            HandleErrorResponse(response);
            return default;
        }
        return response.Data;
    }


    // I want this to be wrapped in its own type and each exception should be custom, inheriting from Exception;
    private static void HandleErrorResponse(RestResponse response)
    {
        throw response.StatusCode switch
        {
            HttpStatusCode.NotFound => new ResourceNotFoundException(),
            HttpStatusCode.Unauthorized => new UnauthorizedAccessException(),
            // Handle other status codes as needed
            _ => new Exception($"Unexpected error: {response.StatusCode}"),
        };
    }

}
