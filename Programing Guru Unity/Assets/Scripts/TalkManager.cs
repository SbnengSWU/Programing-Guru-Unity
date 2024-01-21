using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    
    void GenerateData() //��ȭ ����
    {
        talkData.Add(1001, new string[] { "�ȳ�?", "�� ���� ó�� �Ա���?" });

        talkData.Add(101, new string[] { "����� �������ڴ�." });
        talkData.Add(102, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });

    }

    public string GetTalk(int id, int talkIndex)    //��ȭ ��ȯ
    {
        Debug.Log("GetTalk");
        return talkData[id][talkIndex];
    }

    public string DebugString()
    {
        return name;
    }
}
