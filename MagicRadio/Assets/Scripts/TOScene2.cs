using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TOScene2 : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.GetMouseButtonDown())
        {
            //从摄像机发出到点击坐标的射线
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.collider.gameObject==this.gameObject)
                    GameManager.Instance.TurnGameState(GameState.RadioScene);
            }
        }
     
       

    }
}
