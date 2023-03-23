using MongoDB.Driver;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using webapi;
namespace webapi
{
    
    public class TehulaService
    {
        const string fileName = "./Data/db.json";
        public async Task<List<Tehula>> GetAll()
        {
            using FileStream stream = File.OpenRead(fileName);
            var tehulaList  = await JsonSerializer.DeserializeAsync<List<Tehula>>(stream);
            stream.Close(); 
            return tehulaList;
        }
        private async Task Save(List<Tehula> lst)
        {
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(lst);
            await System.IO.File.WriteAllTextAsync(fileName,json);
        }
        public async Task Add(Tehula tehula)
        {
            using FileStream stream = File.OpenRead(fileName);
            List<Tehula> tehulaList = await JsonSerializer.DeserializeAsync<List<Tehula>>(stream);
            stream.Close();
            tehulaList.Add(tehula);
            await Save(tehulaList);
        }
        public async Task Remove(string id)
        {
            using FileStream stream = File.OpenRead(fileName);
            List<Tehula> tehulaList = await JsonSerializer.DeserializeAsync<List<Tehula>>(stream);
            stream.Close();
            tehulaList.RemoveAll(t => t._id == id);
            await Save(tehulaList);
        }
        public async Task<Tehula> Get(string id)
        {
            using FileStream stream = File.OpenRead(fileName);
            List<Tehula> tehulaList = await JsonSerializer.DeserializeAsync<List<Tehula>>(stream);
            stream.Close();
            return tehulaList.Where(t => t._id == id).First();
        }
        public async Task Update(Tehula tehula)
        {
            await Remove(tehula._id);
            await Add(tehula);
        }
    }
}
