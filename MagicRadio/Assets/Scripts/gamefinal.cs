using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gamefinal : MonoBehaviour
{
    public Image Dead;
    public Image success;
    public GameObject QTime;
    public GameObject QRoad;

    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count==2)
        {
            
            success.gameObject.SetActive(true);
        }
    }
    public void successQTime()
    {
        Destroy(QTime.gameObject);
        count++;
    }
    public void successQRoad()
    {
        Destroy(QRoad.gameObject);
        count++;
    }
    public void fall()
    {
        Dead.gameObject.SetActive(true);
    }

    public void quxiaoziji()
    {
        gameObject.SetActive(false);
    }
}
