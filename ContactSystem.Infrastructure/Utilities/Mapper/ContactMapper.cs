using ContactSystem.Application.Dtos;
using ContactSystem.Application.Entities;

namespace ContactSystem.Infrastructure.Utilities.Mapper
{
    public static class ContactMapper
    {
        public static ContactDto ToDto(this Contact contact)
        {
            if (contact == null)
            {
                return null;
            }

            return new ContactDto
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email
            };
        }

        public static Contact ToDomain(this ContactDto contact)
        {
            if (contact == null)
            {
                return null;
            }

            return new Contact
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email
            };
        }
    }
}
