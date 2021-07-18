using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Api.Data;
using Microsoft.Extensions.Logging;

namespace Demo.Api.Services
{
    public class CreateUserService : ICreateUserService
    {
        private readonly ILogger<CreateUserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserService(ILogger<CreateUserService> logger,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(Demo.Api.Models.User user)
        {
            var dtoUser = _mapper.Map<Demo.Api.Data.User>(user);

            return await _userRepository.Create(dtoUser);
        }
    }
}
