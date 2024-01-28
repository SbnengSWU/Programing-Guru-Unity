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

    public AudioSource audioSource;

    public bool isAction;
    public int talkIndex;
    public int eventIndex;

    public GameObject prologue;
    public GameObject livingroom;


    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>();
        print("Start");
        GameLoad();
    }


    void Update()
    {
        //ESC를 눌렀을 때 나오는 창
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

    }

    public void GameSave()
    {
        Scene scene = SceneManager.GetActiveScene();

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

        // + 현재까지 얻은 아이템 목록

        // + 퀘스트 진행도

        // 스토리 진행도
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
