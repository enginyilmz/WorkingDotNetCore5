using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using Bogus;
//https://github.com/bchavez/Bogus
namespace API.Fake
{
    public static class FakeData
    {
        public static List<AppUser> GetFakeUsers(int count)
        {
            var _users = new Faker<AppUser>()
                .RuleFor(u => u.Id, f => f.IndexFaker)
                .RuleFor(u => u.Gender, f => f.PickRandom<Bogus.DataSets.Name.Gender>())
                .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(u.Gender))
                .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(u.Gender))
                .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .Generate(count);
            return _users;
        }

        // public static async Task<List<AppUser>> GetFakeUsersAsync(int count)
        // {
        //     var _users = new Faker<AppUser>()
        //         .RuleFor(u => u.Id, f => f.IndexFaker)
        //         .RuleFor(u => u.Gender, f => f.PickRandom<Bogus.DataSets.Name.Gender>())
        //         .RuleFor(u => u.FirstName, (f, u) => f.Name.FirstName(u.Gender))
        //         .RuleFor(u => u.LastName, (f, u) => f.Name.LastName(u.Gender))
        //         .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
        //         .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
        //         .Generate(count);
        //     return await _users.ToListAsync();
        // }
    }
}