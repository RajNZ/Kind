﻿using BlazorBoilerplate.Infrastructure.AuthorizationDefinitions;
using BlazorBoilerplate.UI.Base.Shared.Components;
using Microsoft.AspNetCore.Authorization;

namespace BlazorBoilerplate.Theme.Material.Main.Pages
{
    public class UsersBasePage : ItemsTableBase<Person>
    {
        protected bool isUserManager;
        protected override async Task OnInitializedAsync()
        {
            base.OnInitialized();

            var user = (await authenticationStateTask).User;
            isUserManager = (await authorizationService.AuthorizeAsync(user, Policies.For(UserFeatures.UserManager))).Succeeded;

            orderByDefaultField = "LastName";
        }
    }
}
