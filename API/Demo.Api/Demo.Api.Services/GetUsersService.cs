using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Api.Data;
using Microsoft.Extensions.Logging;

namespace Demo.Api.Services
{
    public class GetUsersService : IGetUsersService
    {
        private readonly ILogger<GetUsersService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUsersService(ILogger<GetUsersService> logger,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<List<Demo.Api.Models.User>> Get()
        {
            var dtoUsers = await _userRepository.Get();

            return _mapper.Map<List<Models.User>>(dtoUsers);
        }
    }
}
