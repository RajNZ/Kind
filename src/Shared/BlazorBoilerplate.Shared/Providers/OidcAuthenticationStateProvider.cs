﻿using BlazorBoilerplate.Shared.Dto;
using BlazorBoilerplate.Shared.Interfaces;
using BlazorBoilerplate.Shared.Models;
using IdentityModel.OidcClient;
using Microsoft.Extensions.Logging;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace BlazorBoilerplate.Shared.Providers
{
    public class OidcAuthenticationStateProvider : IdentityAuthenticationStateProvider
    {
        private readonly OidcClient _oidcClient;
        private readonly ITokenStorage _tokenStorage;
        public OidcAuthenticationStateProvider(OidcClient oidcClient, ITokenStorage tokenStorage, IAccountApiClient accountApiClient, ILogger<IdentityAuthenticationStateProvider> logger) : base(accountApiClient, logger)
        {
            _oidcClient = oidcClient;
            _tokenStorage = tokenStorage;
        }

        public async Task<ApiResponseDto> Login()
        {
            try
            {
                var response = await _oidcClient.LoginAsync();

                if (!response.IsError)
                {
                    _logger.LogInformation($"Oidc Login successful {response.AccessTokenExpiration}");

                    await _tokenStorage.Set(new Tokens { AccessToken = response.AccessToken, RefreshToken = response.RefreshToken });

                    return new ApiResponseDto { StatusCode = Status200OK, Result = response.User };
                }
                else
                {
                    _logger.LogError($"Oidc Login: {response.Error} - {response.ErrorDescription}");

                    return new ApiResponseDto { StatusCode = Status500InternalServerError, Message = response.ErrorDescription };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponseDto { StatusCode = Status500InternalServerError, Message = ex.GetBaseException().Message };
            }
            finally
            {
                NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
            }
        }

        public async Task Logout()
        {
            await _tokenStorage.Clear();

            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}