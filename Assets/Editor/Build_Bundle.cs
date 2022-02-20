using UnityEditor;
using System.IO;
public class AssetBuldle : Editor
{
    [MenuItem("Tools/CreatAssetBundle for Android")]
    static void CreatAssetBundle()
    {

        string path = "AssetBundles/Android";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        else
        {
            Directory.Delete(path);
        }
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.UncompressedAssetBundle, BuildTarget.Android);
        UnityEngine.Debug.Log("Android Finish!");
    }

    [MenuItem("Tools/CreatAssetBundle for IOS")]
    static void BuildAllAssetBundlesForIOS()
    {
        string path = "AssetBundles/IOS";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        else
        {
            Directory.Delete(path);
        }
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.CollectDependencies, BuildTarget.iOS);
        UnityEngine.Debug.Log("IOS Finish!");

    }


    [MenuItem("Tools/CreatAssetBundle for Win")]
    static void CreatPCAssetBundleForwINDOWS()
    {
        string path = "AssetBundles/Win32";
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
        else
        {
            Directory.Delete(path);
        }
        BuildPipeline.BuildAssetBundles(path, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
        UnityEngine.Debug.Log("Windows Finish!");
    }
}