using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOrangeScript : MonoBehaviour {

    string type1 = "countable"; //명사 타입
    string type2 = "visible";

    // Use this for initialization
    void Start()
    {
        
    }
    public void send_type()
    {
        string temp = "orange";
        string[] type = { type1, type2, temp }; //명사 타입과 태그 저장
        GameObject.FindWithTag("manager").SendMessage("SetNoun", type);//명사 타입과 태그가 저장된 배열을 인자로 매니저에서 SetNoun 실행 요청
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}