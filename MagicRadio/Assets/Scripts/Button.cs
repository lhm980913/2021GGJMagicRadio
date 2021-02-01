using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ButtonType
{
    Hz,
    Date,
    Time,
    NowTime
}

public class Button : MonoBehaviour
{
    public ButtonType buttonType;

    public SpriteRenderer kedu;
    public float MaxRotateZ;

    public bool Select = false;


    float timecount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ForHzButton();
        if(Radio.Instance.HistoryMode)
        {
            ForDateButton();
            ForTimeButton();
        }
        ForNowTimeButton();
    }

    public void ForHzButton()
    {
        if(buttonType== ButtonType.Hz)
        {
            if (GameManager.GetMouseButtonDown())
            {
                //从摄像机发出到点击坐标的射线
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.GetComponent<Button>() == this)
                    {
                        Select = true;
                        //kedu.color = Color.green;
                    }
                }
            }
            else if (GameManager.GetMouseButtonUp())
            {
                Select = false;
                //kedu.color = Color.black;
            }

            if (Select)
            {
                float LastKedu = kedu.transform.localRotation.eulerAngles.z + 180;
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
                Vector3 dir = pos - transform.position;
                Quaternion target = Quaternion.Euler(0, 0, -Maths.AngleBetween(dir));
                kedu.transform.localRotation = Quaternion.Lerp(kedu.transform.localRotation, target, 10000000 / Quaternion.Angle(target, kedu.transform.localRotation) * Time.deltaTime);
                float NowKedu = kedu.transform.localRotation.eulerAngles.z + 180;
                float KeduBianhua = NowKedu - LastKedu;
                if (Mathf.Abs(KeduBianhua) > 180)
                {
                    if (KeduBianhua < 0)
                        KeduBianhua += 360;
                    else
                    {
                        KeduBianhua -= 360;
                    }
                }
           
                Radio.Instance.Hz -= KeduBianhua * 0.06f;
                if(timecount>0.2f)
                {
                    timecount = 0;
                    AudioController.Instance.TryPlayAudio(AudioType.收音机旋钮);
                }
                timecount += Mathf.Abs(KeduBianhua)*0.01f;
            }
        }
    }
    public void ForDateButton()
    {
        if (buttonType == ButtonType.Date)
        {
      

            if (GameManager.GetMouseButtonDown())
            {
                //从摄像机发出到点击坐标的射线
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.GetComponent<Button>() == this)
                    {
                        Select = true;
//kedu.color = Color.green;
                    }
                }
            }
            else if (GameManager.GetMouseButtonUp() && Select)
            {
                Select = false;
               // kedu.color = Color.black;
               Radio.Instance.CheckRadioMessage();
            }

            if (Select)
            {
                float LastKedu = kedu.transform.localRotation.eulerAngles.z + 180;
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
                Vector3 dir = pos - transform.position;
                Quaternion target = Quaternion.Euler(0, 0, -Maths.AngleBetween(dir));
                kedu.transform.localRotation = Quaternion.Lerp(kedu.transform.localRotation, target, 10000000 / Quaternion.Angle(target, kedu.transform.localRotation) * Time.deltaTime);
                float NowKedu = kedu.transform.localRotation.eulerAngles.z + 180;
                float KeduBianhua = NowKedu - LastKedu;
                if (Mathf.Abs(KeduBianhua) > 180)
                {
                    if (KeduBianhua < 0)
                        KeduBianhua += 360;
                    else
                    {
                        KeduBianhua -= 360;
                    }
                }
              
                Radio.Instance.TargetHistoryDateTime.Day -= KeduBianhua * 0.02f;
                Radio.Instance.SetTargetTimeUI();
            }
        }
    }
    public void ForTimeButton()
    {
        if (buttonType == ButtonType.Time)
        {
            if (GameManager.GetMouseButtonDown())
            {
                //从摄像机发出到点击坐标的射线
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.GetComponent<Button>() == this)
                    {
                        Select = true;
                        //kedu.color = Color.green;
                    }
                }
            }
            else if (GameManager.GetMouseButtonUp() && Select)
            {
                Select = false;
                Radio.Instance.CheckRadioMessage();
                //kedu.color = Color.black;
            }

            if (Select)
            {
                float LastKedu = kedu.transform.localRotation.eulerAngles.z + 180;
                Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                pos.z = 0;
                Vector3 dir = pos - transform.position;
                Quaternion target = Quaternion.Euler(0, 0, -Maths.AngleBetween(dir));
                kedu.transform.localRotation = Quaternion.Lerp(kedu.transform.localRotation, target, 10000000 / Quaternion.Angle(target, kedu.transform.localRotation) * Time.deltaTime);
                float NowKedu = kedu.transform.localRotation.eulerAngles.z + 180;
                float KeduBianhua = NowKedu - LastKedu;
                if (Mathf.Abs(KeduBianhua) > 180)
                {
                    if (KeduBianhua < 0)
                        KeduBianhua += 360;
                    else
                    {
                        KeduBianhua -= 360;
                    }
                }
              
                Radio.Instance.TargetHistoryDateTime.Minute -= KeduBianhua * 1f;
                Radio.Instance.SetTargetTimeUI();
            }
        }
    }
    public void ForNowTimeButton()
    {
        Clock.Instance.SetTargetTimeUI(Radio.Instance.NowTime);
        if (buttonType == ButtonType.NowTime)
        {
            if (GameManager.GetMouseButtonDown())
            {
                //从摄像机发出到点击坐标的射线
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.GetComponent<Button>() == this)
                    {
                        Select = true;
      
                    }
                }
            }
            else if (GameManager.GetMouseButtonUp())
            {
                Select = false;
     
            }

            if (Select)
            {
            
                Radio.Instance.NowTime.Minute += Time.deltaTime * 300f;
               
            }
        }
    }
}
