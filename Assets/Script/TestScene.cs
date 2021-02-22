using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class TestScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        Debug.Log("TestScene===Start");

        var btn1 = GameObject.Find("btn1");

        //��ť����¼�
        btn1.GetComponent<Button>().onClick.AddListener(delegate() {

            Debug.Log("66");
            //GetRequest();
            StartCoroutine(GetRequest());
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator GetRequest()
    {
        // ����� url
        string url = "http://lee.free.vipnps.vip/hotupversion/configrelease";//��Ҫ�����url��ַ
        // ��ʲô����͵���ʲô����������� post/put ����������Ҫ����һ�� string ���͵�����
        // ������ JSON �����ཫ�����װ�� JSON
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {

            yield return webRequest.SendWebRequest();

            // �����������
            if (webRequest.isHttpError || webRequest.isNetworkError)
            {
                Debug.LogError(webRequest.error + "\n" + webRequest.downloadHandler.text);
            }
            else// ��������
            {
                // ��ȡ��������
                string jsonText = webRequest.downloadHandler.text;
                //Debug.Log(jsonText);


                //json ����
                JObject obj = JObject.Parse(jsonText);
                Debug.Log(obj["scriptVersion"]);

            }
        }
    }
}
