using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Api.Data;
using Microsoft.Extensions.Logging;

namespace Demo.Api.Services
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly ILogger<DeleteUserService> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserService(ILogger<DeleteUserService> logger,
            IUserRepository userRepository,
            IMapper mapper)
        {
            _logger = logger;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> Delete(long id)
        {
            return await _userRepository.Delete(id);
        }
    }
}
