using AutoMapper;
using NetCoreAssignment.Service.Contracts.Services;
using NetCoreAssignment.Service.Contracts.Dtos.Users;
using NetCoreAssignment.Domain.Entities;
using NetCoreAssignment.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using NetCoreAssignment.Service.Authorization;
using NetCoreAssignment.Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace NetCoreAssignment.Service.Services
{
    public class UserService: IUserService
    {
        private IJwtUtils _jwtUtils;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository,IJwtUtils jwtUtils,
        IMapper mapper)
        {
            _userRepository = userRepository;
            _jwtUtils = jwtUtils;
            _mapper = mapper;
        }

        public async Task<LoginResponseDto> AuthenticateAsync(LoginDto model)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email);

            // validate
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
                throw new AppException("Email or password is incorrect");

            // authentication successful
            var response = _mapper.Map<LoginResponseDto>(user);

            response.Token = _jwtUtils.GenerateToken(user);

            return response;
        }

        public async Task ChangePasswordAsync(ChangePasswordDto model)
        {
            var user = await _userRepository.GetUserByEmailAsync(model.Email);

            // validate
            if (user == null) throw new KeyNotFoundException("User not found");

            if(!BCrypt.Net.BCrypt.Verify(model.OldPassword, user.Password))
                throw new KeyNotFoundException("Old password is incorrect");

            user.Password = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
            _userRepository.Update(user);
            await _userRepository.SaveAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) throw new KeyNotFoundException("User not found");
            return user;
        }

        public async Task RegisterAsync(RegisterDto model)
        {
            var users= _userRepository.GetList();
            // validate
            if (users.Any(x => x.Email == model.Email))
                throw new AppException("Email '" + model.Email + "' is already taken");

            // map model to new user object
            var user = _mapper.Map<User>(model);
            // hash password
            user.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            // save user
            await _userRepository.CreateAsync(user);
            await _userRepository.SaveAsync();
        }
    }
}
