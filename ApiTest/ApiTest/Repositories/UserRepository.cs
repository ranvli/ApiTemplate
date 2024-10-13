using ApiTest.Entities;
using ApiTest.Repositories;
using System.Text.Json;

public class UserRepository : IUserRepository
{
    private const string DataFilePath = "data.json";
    private Data data;

    public UserRepository()
    {
        LoadData();
    }

    private void LoadData()
    {
        var jsonData = File.ReadAllText(DataFilePath);
        data = JsonSerializer.Deserialize<Data>(jsonData) ?? new Data();
    }

    public IEnumerable<User> GetAllUsers() => data.Users;

    public User? GetUserById(int id) => data.Users.FirstOrDefault(u => u.Id == id);

    public void AddUser(User user)
    {
        data.Users.Add(user);
        SaveData();
    }

    public void UpdateUser(User user)
    {
        var existingUser = GetUserById(user.Id);
        if (existingUser != null)
        {
            existingUser.Name = user.Name;
            existingUser.Email = user.Email;
            existingUser.DateOfBirth = user.DateOfBirth;
            existingUser.Country = user.Country;
            SaveData();
        }
    }

    public void DeleteUser(int id)
    {
        var user = GetUserById(id);
        if (user != null)
        {
            data.Users.Remove(user);
            SaveData();
        }
    }

    private void SaveData()
    {
        var jsonData = JsonSerializer.Serialize(data);
        File.WriteAllText(DataFilePath, jsonData);
    }
}
