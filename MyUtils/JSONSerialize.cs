using System.Xml;
using System.Text.Json;
using System.Reflection;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace MyUtils
{
    public class JSONSerialize
    {
        protected JSONSerialize() { }


        public static T? ReadData<T>(string filePath)
        {
            string jsonRead;
            try
            {
                if (File.Exists(filePath))
                {
                    jsonRead = System.IO.File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<T>(jsonRead);
                }
                else
                {
                    string? outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                    string? absolutePath = Path.Combine(outPutDirectory, filePath);
                    absolutePath = absolutePath.Remove(0, 6);

                    jsonRead = System.IO.File.ReadAllText(absolutePath);
                    return JsonConvert.DeserializeObject<T>(jsonRead);
                }
            }
            catch (FileNotFoundException)
            {
                return default;
            }
        }

        public static void SaveData(Object saveObject, string filePath)
        {

            try
            {
                string json = JsonConvert.SerializeObject(saveObject, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
                if (File.Exists(filePath))
                {
                    System.IO.File.WriteAllText(filePath, json);
                }
                else
                {
                    string? outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);
                    string? absolutePath = Path.Combine(outPutDirectory, filePath);
                    absolutePath = absolutePath.Remove(0, 6);

                    string tmp = absolutePath;
                    for (int i = absolutePath.Length - 1; i >= 0; i--)
                    {
                        if (absolutePath[i] == '\\')
                        {

                            tmp = tmp.Remove(i, 1);
                            break;
                        }
                        else
                        {
                            tmp = tmp.Remove(i, 1);
                        }
                    }
                    if (!Directory.Exists(tmp))
                    {


                        DirectoryInfo di = Directory.CreateDirectory(tmp);
                    }
                    using (FileStream fs = File.Create(absolutePath)) ;
                    System.IO.File.WriteAllText(absolutePath, json);
                }

            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.WriteLine(ex);
            }

        }
    }
}