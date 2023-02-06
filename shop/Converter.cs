using Newtonsoft.Json;
namespace shop_final_project
{
    internal class Converter
    {
        static string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        
        public static void Serialize<T>(T data, string fileName)
        {
            if (File.Exists(desktop + "\\data\\" + fileName)) 
            {
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText(desktop + "\\data\\" + fileName, json);
            }
            else 
            {
                Directory.CreateDirectory(desktop + "\\data");
                File.Create(desktop + "\\data\\" + fileName);
                string json = JsonConvert.SerializeObject(data);
                File.WriteAllText(desktop + "\\data\\" + fileName, json);
            }
        }

        public static T Deserialize<T>(string fileName)
        {
            string json = File.ReadAllText(desktop + "\\data\\" + fileName);
            T data = JsonConvert.DeserializeObject<T>(json);
            return data;

        }
    }
}
