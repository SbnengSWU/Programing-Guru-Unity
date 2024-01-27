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
        // # 오브젝트 번호는 100~ : NPC, 1000~ : 사물 등 오브젝트, 10000~ : 아이템


        //Object
        talkData.Add(1000, new string[] { "옷장이다." });
        talkData.Add(2000, new string[] { "누군가 사용했던 흔적이 있는 책상이다." });
        talkData.Add(3000, new string[] { "내가 방금 일어난 침대다.", "할머니는 어디에 계신 걸까?" });
        talkData.Add(4000, new string[] { "책장이다. \n꽤나 오래 전 책들이 꽂혀 있다." });

        //NPC
        talkData.Add(100, new string[] { "안녕?:0", "이 곳에 처음 왔구나?:1","잘 부탁해!:0" });

        //Item
        talkData.Add(10000, new string[] { "하트를 주웠다." });


        //Quest Talk
        talkData.Add(10 + 100, new string[] { "뭐 하고 있어?:0", "얼른 집을 둘러봐야지!:0",
                                                "자, 얼른 다시 가봐!:0","어휴 참... 알겠어! 가요 가!:1" });

        talkData.Add(20 + 100, new string[] { "첫 번째 추억은 찾았어?:0" , "이제 나머지도 찾아보러가.:0" });


        //Portrait
        portraitData.Add(100 + 0, portraitArr[0]);
        portraitData.Add(100 + 1, portraitArr[1]);

    }

    public string GetTalk(int id, int talkIndex)    //대화 반환
    {
        if (!talkData.ContainsKey(id))
        {
            Debug.Log(id - id % 10);
            if (!talkData.ContainsKey(id - id % 10))
            {
                //퀘스트 맨 처음 대사마저 없을 때
                //기본 대사를 가지고 온다.
                if (talkIndex == talkData[id - id % 100].Length)
                    return null;
                else
                    return talkData[id - id % 100][talkIndex];
            }
            else
            {
                //해당 퀘스트 진행 순서 대사가 없을 때
                //퀘스트 맨 처음 대사를 가지고 온다.
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
