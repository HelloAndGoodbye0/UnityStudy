
using System.IO;
using UnityEngine;
using XLua;

public class XluaCommon {

    public  LuaEnv lua_Env = null;

    private static XluaCommon _instance;
    public static XluaCommon Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new XluaCommon();
            }
            return _instance;
        }

    }

    public XluaCommon()
    {
        lua_Env = new LuaEnv();

        lua_Env.AddLoader(CustomerLoader);
    }

    public  LuaEnv GetLuaEnv() {

        return lua_Env;
    
    
    }
    //�Զ���Load
    byte[] CustomerLoader(ref string flie)
    {
        string fliePath = "";
        if (Application.platform == RuntimePlatform.WindowsEditor)//win �༭��
        {
            fliePath  = Application.dataPath + "/Script/lua/" + flie + ".lua.txt";
        }
        else//ԭ��
        {
            fliePath = Application.persistentDataPath + "/Script/lua/" + flie + ".lua.txt";
        }
       
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(fliePath));
    }


    public void DoString(string chunk, string chunkName = "chunk", LuaTable env = null) {

        string flieName = string.Format("require'{0}'", chunk);
        lua_Env.DoString(flieName, chunkName, env);
        lua_Env.Dispose();
    }


    public void Dispose() {
        if (lua_Env!= null)
        {
            lua_Env.Dispose();
        }
    
    }
}
