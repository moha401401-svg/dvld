using System.IO;

namespace DVLD.Presentation.UI
{
    public static class ThemeSettings
    {

        private static string path =
            "ThemeSettings.txt";



        public static void Save(bool dark)
        {

            File.WriteAllText(
                path,
                dark ? "Dark" : "Light");

        }



        public static bool Load()
        {

            if (!File.Exists(path))
                return false;


            string value =
                File.ReadAllText(path);


            return value == "Dark";

        }

    }
}