using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Api.Data;
using Microsoft.Extensions.Logging;

namespace Demo.Api.Services
{
    public class UpdateUserService : IUpdateUserService
    {
        private readonly ILogger<UpdateUserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserService(ILogger<UpdateUserService> logger,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<Demo.Api.Models.User> Update(Demo.Api.Models.User user)
        {
            var dtoUser = _mapper.Map<Demo.Api.Data.User>(user);

            var updatedDTOUser = await _userRepository.Update(dtoUser);

            return _mapper.Map<Demo.Api.Models.User>(updatedDTOUser);
        }
    }
}
