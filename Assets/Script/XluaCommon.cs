using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XLua;
using System.IO;

public class XluaCommon
{
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

    public LuaEnv luaEnv
    {
        private set;
        get;
    }

    public XluaCommon()
    {
        luaEnv = new LuaEnv();

        luaEnv.AddLoader(CustomerLoader);
    }

    //�Զ���Load
    byte[] CustomerLoader(ref string flie)
    {
        string fliePath = Application.dataPath + "/Script/lua/" + flie + ".lua.txt";
        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(fliePath));
    }

    //����lua��
    public void LoadLuaTable(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.Log("name is null");
            return;
        }
        string flieName = string.Format("require'{0}'", name);
        luaEnv.DoString(flieName);
    }
    //�õ�Lua��
    public LuaTable GetLuaTable(string name, string Testid)
    {
        if (string.IsNullOrEmpty(name))
        {
            Debug.Log("name is null");
            return null;
        }
        LuaTable table = luaEnv.Global.Get<LuaTable>(name);
        if (table == null)
        {
            //����
            LoadLuaTable(name);
            table = luaEnv.Global.Get<LuaTable>(name);
        }
        return table;
    }

    // delegate void test(int id);

    public void Dispose()
    {

        Dispose(true);
    }
    private void Dispose(bool isDispose)
    {
        if (isDispose)
        {
            if (luaEnv != null)
            {
                luaEnv.GC();
                luaEnv.Dispose();
            }
        }
        //�ÿ�
        luaEnv = null;
        _instance = null;
    }

    //����
    ~XluaCommon()
    {
        Dispose(false);
    }

}