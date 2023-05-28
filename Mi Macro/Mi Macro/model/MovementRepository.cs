using Firebase.Database;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace Mi_Macro.model
{
    public class MovementRepository
    {
        FirebaseClient fbClient = new FirebaseClient("https://mimacro-447ef-default-rtdb.firebaseio.com/");

        public async Task<bool> Save(Movements movements)
        {
            var data = await fbClient.Child(nameof(Movements)).PostAsync(JsonConvert.SerializeObject(movements));
            if (!string.IsNullOrEmpty(data.Key))
            {
                return true;
            }
            return false;
        }

        public async Task<List<Movements>> GetAll(string username)
        {
            return (await fbClient.Child(nameof(Movements)).OnceAsync<Movements>()).Where(u => u.Object.username == username).Select(item => new Movements
            {
                date = item.Object.date,
                time = item.Object.time,
                amount = item.Object.amount,
                line = item.Object.line,
                codeQR = item.Object.codeQR
            }).ToList();
        }
    }
}
