using System;
using System.IO;
using System.Reflection;
using MelonLoader;
using Harmony;

namespace PhotoOrganization
{
    public static class BuildInfo
    {
        public const string Name = "PhotoOrganization";
        public const string Author = "Herp Derpinstine";
        public const string Company = "Lava Gang";
        public const string Version = "1.0.0";
        public const string DownloadLink = "https://github.com/HerpDerpinstine/PhotoOrganization";
    }

    public class PhotoOrganization : MelonMod
    {
        private static string FolderPath;

        public override void OnApplicationStart()
        {
            FolderPath = string.Format("{0}/VRChat", new object[] { Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) });
            if (Directory.Exists(FolderPath))
            {
                string[] filepaths = Directory.GetFiles(FolderPath, "VRChat_*.png", SearchOption.TopDirectoryOnly);
                if (filepaths.Length > 0)
                {
                    foreach (string file in filepaths)
                    {
                        DateTime fileinfo = File.GetLastWriteTime(file);
                        string filefolderpath = string.Format("{0}/{1}", new object[] { FolderPath, fileinfo.ToString("yyyy-MM-dd") });
                        if (!Directory.Exists(filefolderpath))
                            Directory.CreateDirectory(filefolderpath);
                        string newfile = string.Format("{0}/{1}.png", new object[] { filefolderpath, fileinfo.ToString("HH-mm-ss.fff") });
                        if (!File.Exists(newfile))
                            File.Move(file, newfile);
                    }
                }
            }

            HarmonyInstance harmonyInstance = HarmonyInstance.Create("PhotoOrganization");
            harmonyInstance.Patch(typeof(ObjectPublicCaUnique).GetMethod("Method_Private_Static_String_Int32_Int32_0", BindingFlags.Public | BindingFlags.Static), new HarmonyMethod(typeof(PhotoOrganization).GetMethod("CameraFolderOrganize", BindingFlags.Static | BindingFlags.NonPublic)));
        }

        private static bool CameraFolderOrganize(ref string __result) { __result = string.Format("{0}/{1}/{2}.png", new object[] { FolderPath, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH-mm-ss.fff") }); return false; }
    }
}