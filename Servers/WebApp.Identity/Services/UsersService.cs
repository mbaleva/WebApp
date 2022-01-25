﻿using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WebApp.Identity.Data.Models;
using WebApp.Identity.ViewModels.Users;

namespace WebApp.Identity.Services
{
    public class UsersService : IUsersService
    {
        private const string InvalidCredentials = "Invalid username or password";
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IJwtService jwtService;

        public UsersService(UserManager<ApplicationUser> userManager,
            IJwtService jwtService)
        {
            this.userManager = userManager;
            this.jwtService = jwtService;
        }
        public async Task<LoginSuccesModel> Login(LoginInputModel model)
        {
            var user = await this.userManager.FindByEmailAsync(model.Email);


            var password = await this.userManager.CheckPasswordAsync(user, model.Password);
            if (user != null && password)
            {
                var token = this.jwtService.GenerateToken(user);
                return new LoginSuccesModel(user.Id, token);
            }
            return null;
        }

        public async Task Register(RegisterInputModel model)
        {
            var user = new ApplicationUser()
            { 
                Email = model.Email,
                UserName = model.Username,
                FullName = model.FullName,
            };
            var result = await this.userManager.CreateAsync(user, model.Password);
        }
    }
}
