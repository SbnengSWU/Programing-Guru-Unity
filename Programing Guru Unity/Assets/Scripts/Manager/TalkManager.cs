using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;

    public Sprite[] portraitArr;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    
    void GenerateData() //��ȭ ����
    {

        // GenerateData() ���� :
        // ��ȭ �߰� -> talkData.Add(������Ʈ ��ȣ, new string[] {" �־��� ��ȭ ��ũ��Ʈ "); 
        // # ������Ʈ ��ȣ�� 101~ : �繰 �� ������Ʈ, 1001~ : NPC, 10001~ : ������


        //Object
        talkData.Add(101, new string[] { "�����̴�." });
        talkData.Add(102, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });
        talkData.Add(103, new string[] { "���� ��� �Ͼ ħ���.", "�ҸӴϴ� ��� ��� �ɱ�?" });
        talkData.Add(104, new string[] { "å���̴�. \n�ϳ� ���� �� å���� ���� �ִ�." });

        //NPC
        talkData.Add(1001, new string[] { "�ȳ�?:0", "�� ���� ó�� �Ա���?:1","�� ��Ź��!:0" });

        //Item
        talkData.Add(10001, new string[] { "��Ʈ�� �ֿ���." });

        //Portrait
        portraitData.Add(1001 + 0, portraitArr[0]);
        portraitData.Add(1001 + 1, portraitArr[1]);
        //portraitData.Add(1001 + 2, portraitArr[2]);
        //portraitData.Add(1001 + 3, portraitArr[3]);

    }

    public string GetTalk(int id, int talkIndex)    //��ȭ ��ȯ
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }

}
