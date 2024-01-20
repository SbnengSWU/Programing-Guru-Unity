using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public GameObject menuFirst;
    public GameObject menuSecond;

    public void onBtnClickStart()
    {
        SceneManager.LoadScene("Start Scene");
    }

    //시작 버튼
    public void onBtnClickName()
    {
        SceneManager.LoadScene("Name Scene");
    }

    //종료 버튼
    public static void onBtnClickQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void onBtnClickPlay()
    {
        SceneManager.LoadScene("Play Scene");
    }

    // Start is called before the first frame update
    void Start()
    {
        SaveCheck();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameNewStart()
    {
        PlayerPrefs.DeleteAll();
    }

    public void SaveCheck()
    {
        if (PlayerPrefs.GetInt("SaveKey") != 1)
        {
            menuSecond.SetActive(false);
            menuFirst.SetActive(true);
        }
        else
        {
            menuFirst.SetActive(false);
            menuSecond.SetActive(true);
        }
    }
}
