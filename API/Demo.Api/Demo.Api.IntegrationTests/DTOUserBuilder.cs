using System;
using Demo.Api.Data;

namespace Demo.Api.IntegrationTests
{
    public class DTOUserBuilder
    {
        private long? _id;
        private string _firstName;
        private string _lastName;
        private Address _address;

        public DTOUserBuilder SetId(long id)
        {
            _id = id;
            return this;
        }

        public DTOUserBuilder SetFirstName(string firstName)
        {
            _firstName = firstName;
            return this;
        }

        public DTOUserBuilder SetLastName(string lastName)
        {
            _lastName = lastName;
            return this;
        }

        public DTOUserBuilder SetAddress(Address address)
        {
            _address = address;
            return this;
        }

        public User Build()
        {
            var user = new User();
            user.Address = _address;
            user.FirstName = _firstName ?? "FirstName";
            user.LastName = _lastName ?? "LastName";
            user.Id = _id ?? 1;

            return user;
        }
    }
}
