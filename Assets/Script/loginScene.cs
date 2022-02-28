using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loginScene : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform obj;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void btnClick()
    {
        GameObject go = Resources.Load<GameObject>("prefabs/alert");
        GameObject alert =  Instantiate(go);
        alert.transform.SetParent(obj.transform);
        alert.transform.localPosition = Vector3.zero;

        //RectTransform rect = alert.GetComponent<RectTransform>();
        //rect.sizeDelta = obj.GetComponent<RectTransform>().sizeDelta;
    }
}
