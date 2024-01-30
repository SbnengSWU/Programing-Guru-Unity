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
    public DialogueManager dManager;

    public Inventory inven;

    public AudioSource audioSource;

    public bool isAction;
    public int talkIndex;
    public int eventIndex;

    public GameObject isClear;
    public GameObject isClear2;

    public GameObject prologue;
    public GameObject livingroom;

    public Text nameText1;
    public Text nameText2;
    public string nameName;


    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        print("Start");

        nameName = PlayerPrefs.GetString("PlayerName");
        nameText1.text = nameName + "�� ��";
        nameText2.text = nameName + "�� ��";
        GameLoad();
    }


    void Update()
    {
        //ESC�� ������ �� ������ â
        if (Input.GetButtonDown("Cancel"))
        {
            if (menuSet.activeSelf)
            {
                menuSet.SetActive(false);
                audioSource.Play();
            }
            else
                menuSet.SetActive(true);
        }

        //�κ��丮�� ������ ������ 3�̸� �������� ����
        if (inven.GetItemCount() == 3)
        {
            isClear.SetActive(true);
        }
        //4�� ��� ���� �� ����
        else if(inven.GetItemCount() == 4)
        {
            isClear2.SetActive(true);
        }
    }

    public void GameSave()
    {
        Scene scene = SceneManager.GetActiveScene();

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

        // + ������� ���� ������ ���

        // + ����Ʈ ���൵

        // ���丮 ���൵
        PlayerPrefs.SetInt("Event", eventIndex);
        Debug.Log(eventIndex);


        PlayerPrefs.Save();

        menuSet.SetActive(false);

        Debug.Log("Save");
    }

    public void GameLoad()
    {
        if (PlayerPrefs.GetInt("SaveKey") != 1 || !PlayerPrefs.HasKey("SaveKey"))
            return;

        float camX = PlayerPrefs.GetFloat("CameraX");
        float camY = PlayerPrefs.GetFloat("CameraY");

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        eventIndex = PlayerPrefs.GetInt("Event");

        switch (eventIndex)
        {
            case 1:
                prologue.SetActive(false);
                break;

            case 2:
                prologue.SetActive(false);
                livingroom.SetActive(false);
                break;
        }

        theCamera.transform.position = new Vector3(x, y, -10);
        player.transform.position = new Vector3(x, y, -1);
    }

    public void GameExit()
    {
        Application.Quit();
    }



}
