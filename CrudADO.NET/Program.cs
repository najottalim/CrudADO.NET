using CrudADO.NET.Data.IRepositories;
using CrudADO.NET.Data.Repositories;

IUserRepository userRepository = new UserRepository();

var users = await userRepository.GetAllAsync();

foreach (var user in users)
    Console.WriteLine(user.Id + " " + user.FirstName);