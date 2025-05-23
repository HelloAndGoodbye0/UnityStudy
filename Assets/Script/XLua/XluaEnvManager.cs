
using UnityEngine;
using XLua;
using System.IO;

namespace LuaUsage
{
    public class XluaEnvManager : SingletonMono<XluaEnvManager>
    {

        /**
         * _luaEnv
         */
        private LuaEnv _luaEnv = null;


        public LuaEnv LuaEnv
        {
            get { return _luaEnv; }
        }


        protected XluaEnvManager()
        {
            _luaEnv = new LuaEnv();
#if UNITY_EDITOR
            _luaEnv.AddLoader(EditorLoader);
#else
            _luaEnv.AddLoader(NativeLoader);
#endif
        }

        /**
         *  编辑器内的自定义loader
         */
        byte[] EditorLoader(ref string flie)
        {
            string filepath = filepath = Application.dataPath + "/ScriptLua/" + flie.Replace('.', '/') + ".lua";
            if (File.Exists(filepath))
            {
                return File.ReadAllBytes(filepath);
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 原生自定义注释
        /// </summary>
        /// <param name="flie"></param>
        /// <returns></returns>
        byte[] NativeLoader(ref string flie)
        {
            string filepath = filepath = Application.persistentDataPath + "/ScriptLua/" + flie.Replace('.', '/') + ".lua";
            if (File.Exists(filepath))
            {
                return File.ReadAllBytes(filepath);
            }
            else
            {
                return null;
            }
        }

        public void say()
        {
            Debug.Log("666");
        }

        /// <summary>
        /// 释放luaEnv
        /// </summary>
        public void dispose()
        {
            if (_luaEnv != null)
            {
                _luaEnv.Dispose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        public void doString(string str)
        {
            if (_luaEnv != null)
            {
                _luaEnv.DoString(str);
            }
        }

    }

}
