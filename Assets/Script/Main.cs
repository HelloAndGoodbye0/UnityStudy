
using UnityEngine;
using LuaUsage;
public class Main : MonoBehaviour
{


    void Start()
    {
        XluaEnvManager.Instance.doString("require 'main'");
    }


    //public void btnClick()
    //{
    //    GameObject go = Resources.Load<GameObject>("prefabs/alert");
    //    GameObject alert =  Instantiate(go);
    //    alert.transform.SetParent(obj);
    //    alert.transform.localPosition = Vector3.zero;

    //    go.transform.GetComponent<Animation>().Play("fumo_right_foot");
    //    //RectTransform rect = alert.GetComponent<RectTransform>();
    //    //rect.sizeDelta = obj.GetComponent<RectTransform>().sizeDelta;
    //}
}
