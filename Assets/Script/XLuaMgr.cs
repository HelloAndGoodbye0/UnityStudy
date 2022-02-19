
using System.IO;
using UnityEngine;
using XLua;
public class XLuaMgr : SingletonMono<XLuaMgr>
{
    private LuaEnv luaEnv = null;

    byte[] CustomMyLoader(ref string flie)
    {
        string fliePath = "";
        if (Application.platform == RuntimePlatform.WindowsEditor)//win ±à¼­Æ÷
        {
            fliePath = Application.dataPath + "/ScriptLua/" + flie + ".lua.txt";
        }
        else//Ô­Éú
        {
            fliePath = Application.persistentDataPath + "/ScriptLua/" + flie + ".lua.txt";
            if (!File.Exists(fliePath))
            {
                fliePath = Application.streamingAssetsPath + "/ScriptLua/" + flie + ".lua.txt";
            }
        }

        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(fliePath));
    }

    public override void Awake()
    {
        base.Awake();
        InitLuaEnv();
    }

    void InitLuaEnv(){
        if (luaEnv == null)
        {
            luaEnv = new LuaEnv();

            luaEnv.AddLoader(CustomMyLoader);
        }
    }
    public void EnterGame()
    {
        DoString("require('main')");
    }
    private void Start()
    {
        DoString("main.Start()");
    }

    public void DoString(string str)
    {
        if (luaEnv != null)
        {
            luaEnv.DoString(str);
        }
    }
}
