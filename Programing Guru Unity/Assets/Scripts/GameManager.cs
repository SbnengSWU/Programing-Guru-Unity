using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject menuSet;

    public GameObject player;


    // Start is called before the first frame update
    void Start()
    {
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
        //세이브 된 적이 있는지 확인하는 용도, 1이면 있음
        PlayerPrefs.SetInt("SaveKey", 1);

        //플레이어의 위치
        PlayerPrefs.SetFloat("PlayerX", player.transform.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.transform.position.y);

        //현재까지 얻은 아이템 목록

        PlayerPrefs.Save();

        menuSet.SetActive(false);
    }

    public void GameLoad()
    {
        if (PlayerPrefs.GetInt("SaveKey") != 1)
            return;

        float x = PlayerPrefs.GetFloat("PlayerX");
        float y = PlayerPrefs.GetFloat("PlayerY");

        player.transform.position = new Vector3(x, y, 0);
    }

    public void GameExit()
    {
        Application.Quit();
    }

}
