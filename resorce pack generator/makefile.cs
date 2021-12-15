using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using resorce_pack_generator;
using System.IO;
using System.IO.Compression;
using System.Threading;


namespace resorce_pack_generator
{
    class generator
    {
        public static void Generate(string jar, string name, bool music)
        {
            System.IO.Directory.Delete("c:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resourcepacksgenerator/temp.zip_folder", true);
            Directory.CreateDirectory("c:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resourcepacksgenerator");
            File.Copy(jar, "c:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resourcepacksgenerator/temp.zip");
            System.IO.Directory.CreateDirectory("c:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resourcepacksgenerator/temp.zip_folder");
            generator.Comp("c:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resourcepacksgenerator/temp.zip", "c:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resourcepacksgenerator/temp.zip_folder");
            File.Delete("c:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resourcepacksgenerator/temp.zip");
            string folder = "c:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resourcepacksgenerator/temp.zip_folder";
            string path = "C:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resourcepacks/" + name;
            Directory.CreateDirectory(path);

            Directory.Move(folder + "/assets", path + "/assets");

            string mcmeta = "{ \"pack\": {\"pack_format\": 5,\"description\": \"" + name + "\"}}";
            File.WriteAllText(path + "/pack.mcmeta", mcmeta);

            if (music == true)
            {
                Directory.Move("C:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resources/sound3", path + "/assets/sounds");

            }
        }
        public static void Comp(string zip1, string extract1)
        {
            ZipFile.ExtractToDirectory(zip1, extract1);

        }

        public static void Create(string folder, string name, bool music)
        {
            string path = "C:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resourcepacks/" + name;
            Directory.CreateDirectory(path);

            Directory.Move(folder + "/assets", path + "/assets");

            string mcmeta = "{ \"pack\": {\"pack_format\": 5,\"description\": \"" + name + "\"}}";
            File.WriteAllText(path + "/pack.mcmeta", mcmeta);

            if (music == true)
            {
                Directory.Move("C:/Users/" + Environment.UserName + "/AppData/Roaming/.minecraft/resources/sound3", path + "/assets/sounds");

            }
        }
    }

}
