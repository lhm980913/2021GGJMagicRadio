using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scene1111 : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.color = new Color(1, 1, 1, (Mathf.Sin(Time.time * 3) + 1) / 2);
    }
    public void GoLevel(int o)
    {
        //Application.LoadLevel(3);//切换到场景Scene_2
        UnityEngine.SceneManagement.SceneManager.LoadScene(o);
    }
}
