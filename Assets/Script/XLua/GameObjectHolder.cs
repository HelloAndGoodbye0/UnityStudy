using UnityEngine;
using XLua;

namespace LuaUsage
{
    [Hotfix]
    [System.Serializable]
    public class Injection
    {
        [SerializeField]
        public string name;
        [SerializeField]
        public GameObject value;
    }
    [Hotfix]
    [LuaCallCSharp]
    public class GameObjectHolder : MonoBehaviour
    {
        [SerializeField]
        public Injection[] _Injections;

        public LuaTable GetObjects()
        {
            var le = XluaEnvManager.Instance.LuaEnv;
            LuaTable l = le.NewTable();
            
            GetObjectsWithTab(l);

            return l;
        }

        public void GetObjectsWithTab(LuaTable tab)
        {
            foreach (var injection in _Injections)
            {
                tab.Set(injection.name, injection.value);
            }
        }
    }
}
