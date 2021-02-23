using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using XLua;

public class LuaCustomCommon : MonoBehaviour
{
    //定义的Lua文件名字
    public string luaPanelName;

    Action lua_Update;

    public LuaTable luaTable
    {
        private set;
        get;
    }

    public bool LoadLuaFile()
    {
        if (string.IsNullOrEmpty(luaPanelName))
        {
            Debug.Log("luaPanelName is null");
            return false;
        }
        string s = "id";
        luaTable = XluaCommon.Instance.GetLuaTable(luaPanelName, s);
        if (luaTable == null)
        {
            Debug.Log("luaTable is null");
            return false;
        }
        luaTable.Set("transform", transform);

        lua_Update = luaTable.Get<Action>("Update");
        return true;
    }

    //调用Lua中的方法
    private void CallLuaFunction(string Name)
    {
        if (string.IsNullOrEmpty(Name))
        {
            Debug.Log("luafunction is null");
            return;
        }
        Action func = luaTable.Get<Action>(Name);
        //  Debug.Log("func:"+(func==null)+" 原luaTable:"+ (luaTable==null));
        if (func != null)
        {
            func();
        }
    }



    private void Awake()
    {

        if (LoadLuaFile())
        {
            //Debug.Log("Awake为true!");
            CallLuaFunction("awake");
        }
        else
        {
            Debug.Log("加载" + luaPanelName + "文件失败");
        }
    }

    void Start()
    {
        //如果是 Add component 的情况，会导致Tabel = null  应该在Add component 后调用一次LoadLuaFile()
        if (luaTable == null)
        {
            if (string.IsNullOrEmpty(luaPanelName))
            {
                Debug.Log("luaPanelName is null");
                return;
            }
            if (!LoadLuaFile())
            {
                Debug.Log("LoadLuaFile is false");
                return;
            }
        }

        CallLuaFunction("start");
    }


    void Update()
    {
        if (lua_Update != null)
        {
            lua_Update();
        }
    }

    private void OnEnable()
    {
        CallLuaFunction("onEnable");
    }

    private void OnDisable()
    {
        CallLuaFunction("onDisable");
    }

    private void OnDestroy()
    {
        CallLuaFunction("onDestroy");
        lua_Update = null;
        luaTable.Dispose();
        luaTable = null;

    }

}
