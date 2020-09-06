using System;
using System.IO;
using System.Reflection;
using MelonLoader;
using Harmony;
using System.Linq;
using UnhollowerRuntimeLib.XrefScans;

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
            var TargetMethod = typeof(ObjectPublicCaUnique).GetMethods(BindingFlags.Static | BindingFlags.Public).Single(it => it.GetParameters().Length == 2 && XrefScanner.XrefScan(it).Any(jt => jt.Type == XrefType.Global && jt.ReadAsObject()?.ToString() == "{0}/VRChat/VRChat_{1}x{2}_{3}.png"));
            HarmonyInstance harmonyInstance = HarmonyInstance.Create("PhotoOrganization");
            harmonyInstance.Patch(TargetMethod, new HarmonyMethod(typeof(PhotoOrganization).GetMethod("CameraFolderOrganize", BindingFlags.Static | BindingFlags.NonPublic)));
        }

        private static bool CameraFolderOrganize(ref string __result) { __result = string.Format("{0}/{1}/{2}.png", new object[] { FolderPath, DateTime.Now.ToString("yyyy-MM-dd"), DateTime.Now.ToString("HH-mm-ss.fff") }); return false; }
    }
}