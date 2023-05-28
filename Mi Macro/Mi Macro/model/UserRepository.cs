using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;

namespace Mi_Macro.model
{
    public class UserRepository
    {
        FirebaseClient fbClient = new FirebaseClient("https://mimacro-447ef-default-rtdb.firebaseio.com/");

        public async Task<bool> Save(User user)
        {
            var data = await fbClient.Child(nameof(User)).PostAsync(JsonConvert.SerializeObject(user));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<User>> GetAll()
        {
            return (await fbClient.Child(nameof(User)).OnceAsync<User>()).Select(item => new User
            {
                firstName = item.Object.firstName,
                lastName = item.Object.lastName,
                balance = item.Object.balance,
                target = item.Object.target,
                username = item.Object.username,
                password = item.Object.password
            }).ToList();
        }
        public async Task<(string FirstName, string LastName, double balance, string target)> GetName(string username)
        {
            var users = (await fbClient
                .Child(nameof(User))
                .OnceAsync<User>())
                .Where(u => u.Object.username == username)
                .FirstOrDefault();

            return users != null ? (users.Object.firstName, users.Object.lastName, users.Object.balance, users.Object.target) : (null, null, 0, null);
        }

        public async Task<(string FirstName, string LastName, string username, string password)> GetDataProfile(string username)
        {
            var users = (await fbClient
                .Child(nameof(User))
                .OnceAsync<User>())
                .Where(u => u.Object.username == username)
                .FirstOrDefault();

            return users != null ? (users.Object.firstName, users.Object.lastName, users.Object.username, users.Object.password) : (null, null, null, null);
        }

        public async Task<bool> LogIn(string userr, string pass)
        {
            var users = (await fbClient
                .Child(nameof(User))
                .OnceAsync<User>())
                .Where(u => u.Object.username == userr && u.Object.password == pass)
                .FirstOrDefault();
            if (users != null)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateUserBalance(string userr, double newBalance)
        {
            var user = (await fbClient
                .Child(nameof(User))
                .OnceAsync<User>())
                .Where(u => u.Object.username == userr)
                .FirstOrDefault();

            if (user != null)
            {
                await fbClient
                .Child(nameof(User))
                .Child(user.Key)
                .Child("balance")
                .PutAsync(newBalance);
                return true;
            }

            return false;
        }

        public async Task<bool> UpdateUserProfile(string userr, string newFirstName, string newLastName, string newPassword)
        {
            var user = (await fbClient
                .Child(nameof(User))
                .OnceAsync<User>())
                .Where(u => u.Object.username == userr)
                .FirstOrDefault();

            if (user != null)
            {
                // Actualiza los campos en el objeto de Usuario existente
                user.Object.firstName = newFirstName;
                user.Object.lastName = newLastName;
                user.Object.password = newPassword;

                // Escribe el objeto de Usuario completo de vuelta en Firebase
                await fbClient
                    .Child(nameof(User))
                    .Child(user.Key)
                    .PutAsync(user.Object);

                return true;
            }

            return false;
        }

    }
}
