using LDY.IPU.CSharp.Fundamentals.Class10.Interfaces;
using Newtonsoft.Json;

namespace LDY.IPU.CSharp.Fundamentals.Class10.Services {
    public class JSONSerializer : IJSONSerializer {
        public T Deserialize<T>(string text) {
            return JsonConvert.DeserializeObject<T>(text);
        }

        public string Serialize<T>(T obj) {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
