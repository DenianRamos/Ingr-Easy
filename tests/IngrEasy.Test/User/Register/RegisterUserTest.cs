﻿using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using CommonTestUtilites.Requests;
using FluentAssertions;
using IngrEasy.Exception.Resources.User;
using IngrEasy.Test.InlineData;
using Microsoft.AspNetCore.Mvc.Testing;

namespace IngrEasy.Test.User.Register;

public class RegisterUserTest : IClassFixture<CustomWebApplicationFactory>
{

    private readonly HttpClient _httpClient;
    public RegisterUserTest(CustomWebApplicationFactory factory) => _httpClient = factory.CreateClient();
    
    [Fact]
    public async Task Sucess()
    {
        var request = RequestRegisterUserJsonBuilder.Build();
      var response =  await  _httpClient.PostAsJsonAsync("User", request);
        
      response.StatusCode.Should().Be(HttpStatusCode.Created);
      
      await using var responseBody = await response.Content.ReadAsStreamAsync();
      
      var responseData = await JsonDocument.ParseAsync(responseBody);
      
      responseData.RootElement.GetProperty("name").GetString().Should().NotBeNullOrWhiteSpace()
          .And.Be(request.Name);
    }
    
    [Theory]
    [ClassData(typeof(CultureInlineDataTest))]
    public async Task Error(string culture)
    {
        var request = RequestRegisterUserJsonBuilder.Build();
        request.Name = string.Empty;
        
        if (_httpClient.DefaultRequestHeaders.Contains("Accept-Language"))
            _httpClient.DefaultRequestHeaders.Remove("Accept-Language");
        
        _httpClient.DefaultRequestHeaders.Add("Accept-Language", culture);
        
        var response =  await  _httpClient.PostAsJsonAsync("User", request);
        
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        
        await using var responseBody = await response.Content.ReadAsStreamAsync();
        
        var responseData = await JsonDocument.ParseAsync(responseBody);

        var erros = responseData.RootElement.GetProperty("errors").EnumerateArray();
        
        var expectedMessage = ResourcesErrorMessage.ResourceManager.GetString("NAME_EMPTY", new CultureInfo(culture));

        erros.Should().ContainSingle().And.Contain(error => error.GetString().Equals(expectedMessage));
    }
}
    
    
