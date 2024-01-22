using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    public GameObject menuSet;

    public GameObject player;

    public Image portraitImg;
    public Text talkText;
    public GameObject talkPanel;
    public GameObject scanObject;

    public TalkManager talkManager;
    private CameraManager theCamera;

    public bool isAction;
    public int talkIndex;


    // Start is called before the first frame update
    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        print("Start");
        GameLoad();
    }

    // Update is called once per frame
    void Update()
    {
        //ESC를 눌렀을 때 나오는 창
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
                menuSet.SetActive(false);
            else
                menuSet.SetActive(true);
        }

    }

    public void GameSave()
    {
        Scene scene = SceneManager.GetActiveScene();

        //string bound = theCamera.GetBound();

        //세이브 된 적이 있는지 확인하는 용도, 1이면 있음
        PlayerPrefs.SetInt("SaveKey", 1);

        //카메라의 위치
        PlayerPrefs.SetFloat("CameraX", Camera.main.transform.position.x);
        PlayerPrefs.SetFloat("CameraY", Camera.main.transform.position.y);
        //PlayerPrefs.SetString("Bound", bound);

        //플레이어의 위치
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetString("PlayerMap", scene.name);

        //현재까지 얻은 아이템 목록

        PlayerPrefs.Save();

        menuSet.SetActive(false);

        Debug.Log("Save");
    }

    public void GameLoad()
    {
        if (PlayerPrefs.GetInt("SaveKey") != 1 || !PlayerPrefs.HasKey("SaveKey"))
            return;

        //Scene Scene = SceneManager.GetActiveScene();

        //string bound = PlayerPrefs.GetString("Bound");
        float camX = PlayerPrefs.GetFloat("CameraX");
        float camY = PlayerPrefs.GetFloat("CameraY");

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");
        string scene = PlayerPrefs.GetString("PlayerMap");

        //if (Scene.name == "Start Scene")
        //    SceneManager.LoadScene(scene);

        theCamera.transform.position = new Vector3(x, y, -10);
        //theCamera.SetBound(bound); 플레이어가 현재 있는 위치에 있는 bound로 newBound를 설정할 수 없을까?,,,,
        //Camera.main.transform.position = new Vector3(camX, camY, -10);
        player.transform.position = new Vector3(x, y, -1);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void Action(GameObject scanObj)
    {
        //액션 컨트롤 -> Talk로 위임
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (talkData == null)
        {
            isAction = false;
            talkIndex = 0;
            return;
        }

        if (isNpc)
        {
            talkText.text = talkData;

            portraitImg.color = new Color(1, 1, 1, 1);
        }
        else
        {
            talkText.text = talkData;

            portraitImg.color = new Color(1, 1, 1, 0);
        }

        isAction = true;
        talkIndex++;
    }

}
