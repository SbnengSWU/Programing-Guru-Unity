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
        //ESC�� ������ �� ������ â
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

        //���̺� �� ���� �ִ��� Ȯ���ϴ� �뵵, 1�̸� ����
        PlayerPrefs.SetInt("SaveKey", 1);

        //ī�޶��� ��ġ
        PlayerPrefs.SetFloat("CameraX", Camera.main.transform.position.x);
        PlayerPrefs.SetFloat("CameraY", Camera.main.transform.position.y);
        //PlayerPrefs.SetString("Bound", bound);

        //�÷��̾��� ��ġ
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);
        PlayerPrefs.SetString("PlayerMap", scene.name);

        //������� ���� ������ ���

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

        Debug.Log(camX);
        theCamera.transform.position = new Vector3(x, y, -10);
        //theCamera.SetBound(bound); �÷��̾ ���� �ִ� ��ġ�� �ִ� bound�� newBound�� ������ �� ������?,,,,
        //Camera.main.transform.position = new Vector3(camX, camY, -10);
        player.transform.position = new Vector3(x, y, -1);
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void Action(GameObject scanObj)
    {
        if (isAction)   //Exit Action
        {
            isAction = false;
        }
        else
        {   //Enter Action

            isAction = true;
            scanObject = scanObj;

            ObjData objData = scanObject.GetComponent<ObjData>();

            Talk(objData.id, objData.isNpc);
        }

        talkPanel.SetActive(isAction);
    }

    void Talk(int id, bool isNpc)
    {
        string talkData = talkManager.GetTalk(id, talkIndex);

        if (isNpc)
        {
            talkText.text = talkData;
        }
        else
        {
            talkText.text = talkData;
        }
    }

}
