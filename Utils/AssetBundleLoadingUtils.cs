using System.IO;
using System.Reflection;
using UnityEngine;

namespace EchoesOf4546B;

public static class AssetBundleLoadingUtils
{
    public static AssetBundle LoadFromAssetsFolder(Assembly modAssembly, string assetBundleFileName)
    {
        return AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(modAssembly.Location), "Assets", assetBundleFileName));
    }
    public static AssetBundle LoadFromModFolder(Assembly modAssembly, string pathToBundle)
    {
        return AssetBundle.LoadFromFile(Path.Combine(Path.GetDirectoryName(modAssembly.Location), pathToBundle));
    }
}