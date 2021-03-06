﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TicketingSystem.BLL.Contracts;
using TicketingSystem.BLL.Helpers;
using TicketingSystem.DAL.Models;
using TicketingSystem.ViewModel.ViewModel;
using TicketingSystem.ViewModel.ViewModels;


namespace TicketingSystem.BLL.Services
{
    public class UserService : IUserService<UserVM, LoginVM, string>
    {
        
        private readonly ToViewModel toViewModel;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationSettingsVM _applicationSettings;
      


        // inject dependencies
        public UserService(UserManager<User> userManager, SignInManager<User> signInManager, IOptions<ApplicationSettingsVM> appSettings)
        {
            toViewModel = new ToViewModel();
            _userManager = userManager;
            _signInManager = signInManager;
            _applicationSettings = appSettings.Value;
        }
        //public UserService(TicketingSystemContext _context)
        //{
        //    context = _context;
        //}
        public async Task<ResponseVM> Register(UserVM userVM)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var user = new User()
                    {
                        UserName = userVM.UserName,
                        FirstName = userVM.FirstName,
                        MiddleName = userVM.MiddleName,
                        LastName = userVM.LastName,
                        Question = userVM.Question,
                        Answer = ComputeSha256Hash(userVM.Answer)
                    };
                    // save user and encrypts password
                    var result = await _userManager.CreateAsync(user, userVM.Password);
                    await _userManager.AddToRoleAsync(user, userVM.Role);

                    if (result.Succeeded)
                    {
                        scope.Complete();
                        return new ResponseVM("created", true, "User");
                    }
                    else
                        return new ResponseVM("created", false, "User", "", "", null, result.Errors);

                }
                catch (Exception ex)
                {
                    scope.Dispose();
                    return new ResponseVM("created", false, "User", ResponseVM.SOMETHING_WENT_WRONG, "", ex);
                }
            }
        }

        public async Task<ResponseVM> Login(LoginVM loginVM)
        {
            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            var userFound = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            if (user != null && userFound)
            {
                //Get role assigned to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID",user.Id.ToString()),
                        new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_applicationSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return new ResponseVM("authenticated", true, "User", "Login succcess!", token);
            }
            else
                return new ResponseVM("authenticated", false, "User", "Username or password is incorrect.");
        }

        

        public async Task<UserVM> UserProfile(string id)
        {
            using (_userManager)
            {
                var user = await _userManager.FindByIdAsync(id);
                UserVM userVm = null;
                if (user != null)
                {
                    userVm = toViewModel.User(user);

                }
                return userVm;
            }
        }

        public async Task<ForgotPasswordVM> GetSecurityQuestion(string username)
        {
            using (_userManager)
            {
                var user = await _userManager.FindByNameAsync(username);
                ForgotPasswordVM forgotPasswordVM = null;
                if (user != null)
                {
                    forgotPasswordVM = new ForgotPasswordVM
                    {
                        UserName = user.UserName,
                        Question = user.Question
                    };
                }
                return forgotPasswordVM;
            }
        }

        public async Task<ResponseVM> ResetPassword(ForgotPasswordVM forgotPasswordVM)
        {
            using (_userManager)
            {
                var user = await _userManager.FindByNameAsync(forgotPasswordVM.UserName);

                if (user == null)
                    return new ResponseVM("reset password", false, "User", "User not found.");

                // hashes the answer and compares to the saved in database
                var answerHash = ComputeSha256Hash(forgotPasswordVM.Answer);
                if (answerHash == user.Answer)
                {
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, forgotPasswordVM.NewPassword);
                    return new ResponseVM("reset password", true, "User", "You can now login with your new password.");
                }
                else
                {
                    return new ResponseVM("reset password", false, "User", "Wrong answer!");
                }
            }
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public Task<ResponseVM> Update(UserVM entity)
        {
            throw new NotImplementedException();
        }
        public UserVM GetSingleBy(string id)
        {
            throw new NotImplementedException();
        }
        public Task<ResponseVM> Deactivate(UserVM entity)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseVM> Validate(UserVM entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserVM> GetAll(UserVM userVM)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseVM> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<UserVM> GetAll()
        {
            throw new NotImplementedException();
        }
    }

}
