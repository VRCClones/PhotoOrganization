using System.Resources;
using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;

[assembly: AssemblyTitle(PhotoOrganization.BuildInfo.Name)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany(PhotoOrganization.BuildInfo.Company)]
[assembly: AssemblyProduct(PhotoOrganization.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + PhotoOrganization.BuildInfo.Author)]
[assembly: AssemblyTrademark(PhotoOrganization.BuildInfo.Company)]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]
//[assembly: Guid("")]
[assembly: AssemblyVersion(PhotoOrganization.BuildInfo.Version)]
[assembly: AssemblyFileVersion(PhotoOrganization.BuildInfo.Version)]
[assembly: NeutralResourcesLanguage("en")]
[assembly: MelonModInfo(typeof(PhotoOrganization.PhotoOrganization), PhotoOrganization.BuildInfo.Name, PhotoOrganization.BuildInfo.Version, PhotoOrganization.BuildInfo.Author, PhotoOrganization.BuildInfo.DownloadLink)]


// Create and Setup a MelonModGame to mark a Mod as Universal or Compatible with specific Games.
// If no MelonModGameAttribute is found or any of the Values for any MelonModGame on the Mod is null or empty it will be assumed the Mod is Universal.
// Values for MelonModGame can be found in the Game's app.info file or printed at the top of every log directly beneath the Unity version.
[assembly: MelonModGame(null, null)]