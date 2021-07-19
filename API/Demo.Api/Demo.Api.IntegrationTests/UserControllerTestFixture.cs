using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;
using Demo.Api.Data;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Demo.Api.IntegrationTests
{
    public class UserControllerTestFixture : IClassFixture<IntegrationTestWebApplicationFactory<Demo.Api.Startup>>
    {
        private readonly HttpClient _client;
        private readonly IntegrationTestWebApplicationFactory<Demo.Api.Startup> _factory;

        public UserControllerTestFixture(IntegrationTestWebApplicationFactory<Demo.Api.Startup> factory)
        {
            _factory = factory;
            _client = factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

        }

        [Fact]
        public async Task GET_GivenIRequestAUserById_IShouldSeeTheUser()
        {
            // Arrange
            var id = new Random().Next(int.MaxValue);

            var user = new DTOUserBuilder()
                        .SetId(id)
                        .Build();

            using (var scope = _factory.Services.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                await userRepository.Create(user);
            }

            // Act
            var result = await _client.GetFromJsonAsync<Models.User>($"/users/{id}");

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(user.Id);
            result.FirstName.Should().Be(user.FirstName);
            result.LastName.Should().Be(user.LastName);
        }

        [Fact]
        public async Task POST_GivenICreateANewUser_IShouldSeeANewUserCreatedInTheDB()
        {
            // Arrange
            var user = new UserBuilder()
                        .Build();

            // Act
            var response = await _client.PostAsJsonAsync("/users", user);
            var newUser = await response.Content.ReadFromJsonAsync<User>();

            // Assert
            using (var scope = _factory.Services.CreateScope())
            {
                newUser.Should().NotBeNull();
                newUser.FirstName.Should().Be(user.FirstName);
                newUser.LastName.Should().Be(user.LastName);

                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var dtoUser = await userRepository.Get(newUser.Id);
                dtoUser.Should().NotBeNull();
                dtoUser.Id.Should().Be(newUser.Id);
                dtoUser.FirstName.Should().Be(user.FirstName);
                dtoUser.LastName.Should().Be(user.LastName);
            }
        }

        [Fact]
        public async Task GET_GivenIRequestAllUsers_IShouldSeeMultipleUsers()
        {
            // Arrange
            var id1 = new Random().Next(int.MaxValue);
            var id2 = new Random().Next(int.MaxValue);

            var user1 = new DTOUserBuilder()
                        .SetId(id1)
                        .Build();

            var user2 = new DTOUserBuilder()
                        .SetId(id2)
                        .Build();

            using (var scope = _factory.Services.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                await userRepository.Create(user1);
                await userRepository.Create(user2);
            }

            // Act
            var results = await _client.GetFromJsonAsync<List<Models.User>>("/users");

            // Assert
            results.Should().NotBeNull();
            results.Should().Contain(x => x.Id == id1);
            results.Should().Contain(x => x.Id == id2);
        }

        [Fact]
        public async Task DELETE_GivenIDeleteAUser_IShouldNotSeeTheUserInTheDB()
        {
            // Arrange
            var id = new Random().Next(int.MaxValue);

            var user = new DTOUserBuilder()
                        .SetId(id)
                        .Build();

            using (var scope = _factory.Services.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                await userRepository.Create(user);

                // Act
                await _client.DeleteAsync($"/users/{id}");

                // Assert
                var dtoUser = await userRepository.Get(id);
                dtoUser.Should().BeNull();
            }
        }

        [Fact]
        public async Task PUT_GivenIUpdateAUser_IShouldSeeTheUserInTheDBISUpdated()
        {
            // Arrange
            var id = new Random().Next(int.MaxValue);

            var dtoUser = new DTOUserBuilder()
                        .SetId(id)
                        .Build();

            using (var scope = _factory.Services.CreateScope())
            {
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                await userRepository.Create(dtoUser);

            }

            var user = new User();
                user.Id = id;
                user.FirstName = "NewFirstName";
                user.LastName = "NewLastName";

            // Act
            await _client.PutAsJsonAsync("/users", user);

            using (var scope = _factory.Services.CreateScope())
            {
                // Assert
                var userRepository = scope.ServiceProvider.GetRequiredService<IUserRepository>();
                var updatedDTOUser = await userRepository.Get(id);
                updatedDTOUser.Should().NotBeNull();
                updatedDTOUser.Id.Should().Be(user.Id);
                updatedDTOUser.FirstName.Should().Be(user.FirstName);
                updatedDTOUser.LastName.Should().Be(user.LastName);
            }
        }
    }
}
