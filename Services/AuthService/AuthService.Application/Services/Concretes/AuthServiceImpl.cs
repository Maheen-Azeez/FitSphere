using AuthService.Application.Dtos.Requests;
using AuthService.Application.Dtos.Responses;
using AuthService.Application.Services.Contracts;
using AuthService.Domain.Entities;
using AuthService.Infrastructure.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Services.Concretes
{
    public class AuthServiceImpl : IAuthService
    {
        private readonly IUserRepository _repo;
        private readonly IJwtGenerator _jwt;
        private readonly IPasswordHasher _hasher;
        public AuthServiceImpl(IUserRepository repo, IJwtGenerator jwt, IPasswordHasher hasher)
        {
            _repo = repo;
            _jwt = jwt;
            _hasher = hasher;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest req)
        {
            if (await _repo.GetByEmailAsync(req.Email) != null)
                throw new Exception("User already exists");

            var user = new User
            {
                FullName = req.FullName,
                Email = req.Email,
                BranchId = req.BranchId,
                PasswordHash = _hasher.Hash(req.Password)
            };

            user = await _repo.AddAsync(user);

            return _jwt.Generate(user);
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest req)
        {
            var user = await _repo.GetByEmailAsync(req.Email);
            if (user == null || !_hasher.Verify(user.PasswordHash, req.Password))
                throw new Exception("Invalid credentials");

            return _jwt.Generate(user);
        }
    }
}
