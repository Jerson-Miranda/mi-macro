using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mi_Macro.model
{
    public class LineRepository
    {
        FirebaseClient fbClient = new FirebaseClient("https://mimacro-447ef-default-rtdb.firebaseio.com/");
        public async Task<double> GetPrice(string name_)
        {
            var lines = (await fbClient
                .Child(nameof(Line))
                .OnceAsync<Line>())
                .Where(u => u.Object.name == name_)
                .FirstOrDefault();

            return lines != null ? lines.Object.price : 0;
        }

        public async Task<List<Line>> GetAllLines()
        {
            var result = await fbClient.Child(nameof(Line)).OnceAsync<Line>();
            return result.Select(item => item.Object).ToList();
        }
    }
}
