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

    
    void GenerateData() //대화 생성
    {

        // GenerateData() 사용법 :
        // 대화 추가 -> talkData.Add(오브젝트 번호, new string[] {" 넣어줄 대화 스크립트 "); 
        // # 오브젝트 번호는 101~ : 사물 등 오브젝트, 1001~ : NPC, 10001~ : 아이템


        //Object
        talkData.Add(101, new string[] { "옷장이다." });
        talkData.Add(102, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(103, new string[] { "내가 방금 일어난 침대다.", "할머니는 어디에 계신 걸까?" });
        talkData.Add(104, new string[] { "책장이다. \n꽤나 오래 전 책들이 꽂혀 있다." });

        //NPC
        talkData.Add(1001, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1","잘 부탁해!:0" });

        //Item
        talkData.Add(10001, new string[] { "하트를 주웠다." });

        //Portrait
        portraitData.Add(1001 + 0, portraitArr[0]);
        portraitData.Add(1001 + 1, portraitArr[1]);
        //portraitData.Add(1001 + 2, portraitArr[2]);
        //portraitData.Add(1001 + 3, portraitArr[3]);

    }

    public string GetTalk(int id, int talkIndex)    //대화 반환
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
