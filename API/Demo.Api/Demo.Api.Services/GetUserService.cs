using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Api.Data;
using Microsoft.Extensions.Logging;

namespace Demo.Api.Services
{
    public class GetUserService : IGetUserService
    {
        private readonly ILogger<GetUserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserService(ILogger<GetUserService> logger,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Demo.Api.Models.User> Get(long id)
        {
            var dtoUser = await _userRepository.Get(id);

            return _mapper.Map<Demo.Api.Models.User>(dtoUser);
        }
    }
}
