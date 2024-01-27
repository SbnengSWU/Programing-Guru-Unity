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
        // # ������Ʈ ��ȣ�� 100~ : NPC, 1000~ : �繰 �� ������Ʈ, 10000~ : ������


        //Object
        talkData.Add(1000, new string[] { "�����̴�." });
        talkData.Add(2000, new string[] { "������ ����ߴ� ������ �ִ� å���̴�." });
        talkData.Add(3000, new string[] { "���� ��� �Ͼ ħ���.", "�ҸӴϴ� ��� ��� �ɱ�?" });
        talkData.Add(4000, new string[] { "å���̴�. \n�ϳ� ���� �� å���� ���� �ִ�." });

        //NPC
        talkData.Add(100, new string[] { "�ȳ�?:0", "�� ���� ó�� �Ա���?:1","�� ��Ź��!:0" });

        //Item
        talkData.Add(10000, new string[] { "��Ʈ�� �ֿ���." });


        //Quest Talk
        talkData.Add(10 + 100, new string[] { "�� �ϰ� �־�?:0", "�� ���� �ѷ�������!:0",
                                                "��, �� �ٽ� ����!:0","���� ��... �˰ھ�! ���� ��!:1" });

        talkData.Add(20 + 100, new string[] { "ù ��° �߾��� ã�Ҿ�?:0" , "���� �������� ã�ƺ�����.:0" });


        //Portrait
        portraitData.Add(100 + 0, portraitArr[0]);
        portraitData.Add(100 + 1, portraitArr[1]);

    }

    public string GetTalk(int id, int talkIndex)    //��ȭ ��ȯ
    {
        if (!talkData.ContainsKey(id))
        {
            Debug.Log(id - id % 10);
            if (!talkData.ContainsKey(id - id % 10))
            {
                //����Ʈ �� ó�� ��縶�� ���� ��
                //�⺻ ��縦 ������ �´�.
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //�ش� ����Ʈ ���� ���� ��簡 ���� ��
                //����Ʈ �� ó�� ��縦 ������ �´�.
                if (talkIndex == talkData[id - id % 10].Length)
                    return null;
                else
                    return talkData[id - id % 10][talkIndex];
            }
            
        }
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
