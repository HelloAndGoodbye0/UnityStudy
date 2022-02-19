using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//using UnityEngine.SceneManagement;

public class AppLaunch : SingletonMono<AppLaunch>
{
    // Start is called before the first frame update
    public override void Awake()
    {
        base.Awake();
        this.gameObject.AddComponent<XLuaMgr>();
    }
    void Start()
    {
        //Application.LoadLevel(1);
        //SceneManager.LoadScene("TestScene");
        XLuaMgr.Instance.EnterGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
