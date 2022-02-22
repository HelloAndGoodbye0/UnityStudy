/*
 * Tencent is pleased to support the open source community by making xLua available.
 * Copyright (C) 2016 THL A29 Limited, a Tencent company. All rights reserved.
 * Licensed under the MIT License (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
 * http://opensource.org/licenses/MIT
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using XLua;
using System;
using System.IO;

[System.Serializable]
public class Injection
{
    public string name;
    public GameObject value;
}
public class LuaCompoent : MonoBehaviour
{
    

    internal static LuaEnv lua_Env = new LuaEnv(); //all lua behaviour shared one luaenv only!
    internal static float lastGCTime = 0;
    internal const float GCInterval = 1;//1 second
    private LuaTable scriptEnv = null;

    public Injection[] injections;

    //自定义Load
    byte[] CustomMyLoader(ref string file)
    {
        file = file.Replace(".","/");
        string fliePath = "";
        if (Application.platform == RuntimePlatform.WindowsEditor)//win 编辑器
        {
            fliePath = Application.dataPath + "/ScriptLua/" + file + ".lua.txt";
        }
        else//原生
        {
            fliePath = Application.persistentDataPath + "/ScriptLua/" + file + ".lua.txt";
        }

        return System.Text.Encoding.UTF8.GetBytes(File.ReadAllText(fliePath));
    }

    void Awake()
    {
        scriptEnv = lua_Env.NewTable();

        // 为每个脚本设置一个独立的环境，可一定程度上防止脚本间全局变量、函数冲突
        LuaTable meta = lua_Env.NewTable();
        meta.Set("__index", lua_Env.Global);
        scriptEnv.SetMetaTable(meta);
        meta.Dispose();

        scriptEnv.Set("self", this);
        foreach (var injection in injections)
        {
            scriptEnv.Set(injection.name, injection.value);
        }

        lua_Env.AddLoader(CustomMyLoader);

        string luaText = GetLuaAssets();
        lua_Env.DoString(luaText, this.gameObject.name, scriptEnv);
        //string flieName = string.Format(@"require  '{0}'", luaScriptName);// + luaScriptName;
        // lua_Env.DoString(flieName, luaScriptName, scriptEnv);
        //lua_Env.DoString(luaScript.text, luaScriptName, scriptEnv);
        CallLuaFunction("awake");
    }

    private string GetLuaAssets()
    {
        string fileName = this.gameObject.name;
        string filePath = null;
        string text = null;

        #if UNITY_EDITOR
                filePath = Application.dataPath + "/ScriptLua/" + fileName + ".lua.txt";
                if (File.Exists(filePath))
                {
                    text = File.ReadAllText(filePath);
                }
        #endif

        return text;
    }
    private void CallLuaFunction(string funcName)
    {
        if (scriptEnv!=null)
        {
            Action func = scriptEnv.Get<Action>(funcName);
            if (func != null)
            {
                func();
            }
        }
    }

    void OnEnable()
    {
        CallLuaFunction("onEnable");

    }

    private void OnDisable()
    {
        CallLuaFunction("onDisable");
    }
    void FixedUpdate()
    {
        CallLuaFunction("fixedUpdate");
    }


    private void LateUpdate()
    {
        CallLuaFunction("lateUpdate");
    }

    // Use this for initialization
    void Start()
    {
        CallLuaFunction("onStart");
    }

    // Update is called once per frame
    void Update()
    {
        CallLuaFunction("update");
        if (Time.time - LuaCompoent.lastGCTime > GCInterval)
        {
            lua_Env.Tick();
            LuaCompoent.lastGCTime = Time.time;
        }
    }

    void OnDestroy()
    {
        CallLuaFunction("onDestroy");
        scriptEnv.Dispose();

    }
}

