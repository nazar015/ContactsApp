# Problem to Solve
A customer needs to quickly and easily find key contacts at any of company's office locations. 

Your task is to build a simple web application that enables users to search for office locations and view relevant contact details. 

The application should offer a clean, user-friendly interface, a set of straightforward APIs, and leverage the provided data store and sample data.

# Project Overview
- Clean Architecture
- ASP.NET WEB API for BE
- ASP.NET MVC for FE, which calls APIs

# Flow of Implementation
Some namings where changed to gain more simplicity, e.g., OfficeEntity -> Office.

I added a seeder in a Program.cs file to seed data for the first time.

I moved ContactService to the Infrastructure layer, and removed OfficeService, because it was not needed.

I added an extension class for manual mapping, to avoid runtime errors which happen with mapping libraries.

I decided to add dtos and mapping, to ensure that noone will modify data object, tracked by EF, by mistake.

I enabled searching without a search term, so a client could see all contacts, related to a specific office.

I added paged result dto for requests with pagination instead of ApiResponse.

I added a Razor page in the MVC project that contains
- dropdown with offices
- search bar
- table with contacts
- pagination

# Improvements if there was more time
Move config related stuff from code to the appsettings

**Automated Error Handling**: I would throw exceptions on the repository level, and catch them in the custom middleware with a switch, to return proper status codes. 

**Decouple Filter and Sorting Logic**: having filtering and sorting for each entity separated into individual files would prevent complex methods in repositories. Example:

'''

    public class ComponentRepository : IRepository<Component, ComponentFilter>
    {
        private readonly ComponentDbContext _context;
        public ISorter<Component> Sorter { get; set; }
        public IFilterHandler<Component, ComponentFilter> Filter { get; set; }

        public ComponentRepository(ComponentDbContext context, ISorter<Component> sorter, IFilterHandler<Component, ComponentFilter> filter)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Sorter = sorter ?? throw new ArgumentNullException(nameof(sorter));
            Filter = filter ?? throw new ArgumentNullException(nameof(filter));
        }

        public async Task<IEnumerable<Component>> GetAllAsync(QueryString<ComponentFilter> query)
        {
            var components = _context.Components.AsQueryable().Include(_ => _.Rule).AsNoTracking();

            Filter.Apply(ref components, query.Filter);
            Sorter.Apply(ref components, query.SortField, query.Order);

            components = components.Skip((query.Page - 1) * query.Size).Take(query.Size);

            return await components.ToListAsync();
        }
    }
'''

# How to Run the App Locally
- Use Visual Studio Insiders
- Make sure to set ContatSystem.API and ContactSystem.UI as Startup project.
- Start the app

# Demo
See: https://seecontacts-h4cpfmgugnawgaax.canadacentral-01.azurewebsites.net/