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

    
    void GenerateData() //대화 생성
    {
        //Object
        talkData.Add(101, new string[] { "옷장이다." });
        talkData.Add(102, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(103, new string[] { "내가 방금 일어난 침대다.", "할머니는 어디에 계신 걸까?" });
        talkData.Add(104, new string[] { "책장이다. \n꽤나 오래 전 책들이 꽂혀 있다." });

        //NPC
        talkData.Add(1001, new string[] { "안녕?", "이 곳에 처음 왔구나?" });

        //Item
        talkData.Add(10001, new string[] { "하트를 주웠다." });

    }

    public string GetTalk(int id, int talkIndex)    //대화 반환
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

}
