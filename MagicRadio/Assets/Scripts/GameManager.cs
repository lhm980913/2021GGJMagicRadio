using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum GameState
{
    All,
    RadioScene
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState;

    public Transform All;
    public Transform RadioScene;
    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        //TurnGameState(GameState.All);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            TurnGameState(GameState.All);
        }
        if(GetMouseButtonDown()&&GameUI.Instance.DuiHuaKuang.activeSelf)
        {
            if (GameUI.Instance.messageTextDatas.Length-1 > GameUI.Instance.nowMessageIndex)
            {
                GameUI.Instance.NextMessage();
            }
            else
            {
                GameUI.Instance.CloseRadioMessage();
            }
        }
    }
    public void TurnGameState(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.All:
                {
                    Camera.main.transform.position = new Vector3(All.transform.position.x, All.transform.position.y, -10);
                    AudioController.Instance.TryPlayAudio(AudioType.切换场景或者道具);
                }
                break;
            case GameState.RadioScene:
                {
                    Camera.main.transform.position = new Vector3(RadioScene.transform.position.x, RadioScene.transform.position.y, -10);
                    AudioController.Instance.TryPlayAudio(AudioType.切换场景或者道具);
                }
                break;
            default:
                break;
        }
    }

    public static bool GetMouseButtonDown()
    {
        return Input.GetMouseButtonDown(0);
    }
    public static bool GetMouseButton()
    {
        return Input.GetMouseButton(0);
    }
    public static bool GetMouseButtonUp()
    {
        return Input.GetMouseButtonUp(0);
    }
}
