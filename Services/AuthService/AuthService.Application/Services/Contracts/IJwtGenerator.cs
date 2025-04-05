using AuthService.Application.Dtos.Responses;
using AuthService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Application.Services.Contracts
{
    public interface IJwtGenerator
    {
        AuthResponse Generate(User user);
    }
}
