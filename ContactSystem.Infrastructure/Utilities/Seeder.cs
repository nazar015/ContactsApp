using ContactAdministrationSystem.Infrastructure;
using ContactSystem.Application.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace ContactSystem.Infrastructure.Utilities
{
    public class Seeder
    {
        private readonly GraniteDataContext _context;

        public Seeder(GraniteDataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Apply()
        {
            #region Initial Seed Data

            await _context.Offices.AddAsync(new Office
            {
                Id = new Guid("ff0c022e-1aff-4ad8-2231-08db0378ac98"),
                Name = "Default Office"
            });

            await _context.Contacts.AddAsync(new Contact
            {
                Id = new Guid("c00b9ff3-b1b6-42fe-8b5a-4c28408fb64a"),
                FirstName = "Alejandro",
                LastName = "Alfonso",
                Email = "aalfonso@gmail.com",
                ContactOffices = new List<ContactOfficeRelation>
                {
                    new()
                    {
                        ContactId = new Guid("c00b9ff3-b1b6-42fe-8b5a-4c28408fb64a"),
                        OfficeId = new Guid("ff0c022e-1aff-4ad8-2231-08db0378ac98"),
                    }
                }
            });

            await _context.Contacts.AddAsync(new Contact
            {
                Id = new Guid("1ec2d3f7-8aa8-4bf5-91b8-045378919049"),
                FirstName = "Mark",
                LastName = "Costello",
                Email = "mcostello@gmail.com"
            });

            #endregion

            #region Random Seed Data

            var offices = new List<Office>();

            for (int i = 0; i < 4; i++)
            {
                var office = new Office()
                {
                    Id = Guid.NewGuid(),
                    Name = $"Office #{i + 1}"
                };

                offices.Add(office);
            }

            await _context.AddRangeAsync(offices);

            string[] names = ["Peter", "Paul", "Jane"];
            string[] surnames = ["Cliff", "Jackson", "Smith"];
            var rand = new Random();

            var contacts = new List<Contact>();

            for (int i = 0; i < 10; i++)
            {
                var name = names[rand.Next(0, 2)];
                var surname = surnames[rand.Next(0, 2)];
                var email = $"{name}.{surname}{rand.Next(1, 1000)}@gmail.com";

                var contact = new Contact()
                {
                    Id = Guid.NewGuid(),
                    FirstName = name,
                    LastName = surname,
                    Email = email
                };

                if (i % 2 == 0)
                {
                    var link = new ContactOfficeRelation()
                    {
                        ContactId = contact.Id,
                        OfficeId = offices[rand.Next(offices.Count)].Id
                    };

                    contact.ContactOffices.Add(link);
                }

                contacts.Add(contact);
            }

            await _context.Contacts.AddRangeAsync(contacts);

            #endregion

            await _context.SaveChangesAsync();
        }
    }
}
