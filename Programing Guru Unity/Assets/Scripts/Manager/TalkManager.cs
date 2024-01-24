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
        //Object
        talkData.Add(101, new string[] { "�����̴�." });
        talkData.Add(102, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });
        talkData.Add(103, new string[] { "���� ��� �Ͼ ħ���.", "�ҸӴϴ� ��� ��� �ɱ�?" });
        talkData.Add(104, new string[] { "å���̴�. \n�ϳ� ���� �� å���� ���� �ִ�." });

        //NPC
        talkData.Add(1001, new string[] { "�ȳ�?", "�� ���� ó�� �Ա���?" });

        //Item
        talkData.Add(10001, new string[] { "��Ʈ�� �ֿ���." });

    }

    public string GetTalk(int id, int talkIndex)    //��ȭ ��ȯ
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

}
