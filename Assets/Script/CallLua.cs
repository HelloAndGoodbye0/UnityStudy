using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class CallLua : MonoBehaviour
{
    // Start is called before the first frame update
    public string LuaScriptName;
    private LuaTable scriptEnv;

    private void Awake()
    {
        string luaFile = string.Format("require( \"{0}\")", LuaScriptName);
        
        XLuaMgr.Instance.DoString(luaFile);
    }
    void Start()
    {
        string luaFile = string.Format("{0}.Start()", LuaScriptName);
        XLuaMgr.Instance.DoString(luaFile);
    }

    // Update is called once per frame
    void Update()
    {
        string luaFile = string.Format("{0}.Update()", LuaScriptName);
        XLuaMgr.Instance.DoString(luaFile);
    }
}
