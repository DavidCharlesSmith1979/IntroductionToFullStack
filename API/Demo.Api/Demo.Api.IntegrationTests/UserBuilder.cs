using System;
using Demo.Api.Models;

namespace Demo.Api.IntegrationTests
{
    public class UserBuilder
    {
        private long? _id;
        private string _firstName;
        private string _lastName;

        public UserBuilder SetId(long id)
        {
            _id = id;
            return this;
        }

        public UserBuilder SetFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public UserBuilder SetLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public User Build()
        {
            var user = new User();
            user.FirstName = _firstName ?? "FirstName";
            user.LastName = _lastName ?? "LastName";
            user.Id = _id ?? 1;

            return user;
        }
    }
}
