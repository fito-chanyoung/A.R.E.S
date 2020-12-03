using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class planmanagerZL : MonoBehaviour {

    public cardmanagerZ manager;

    private string name = "planmarnagerZL";                         //이 플랜의 태그에 쓰임

    void OnTriggerEndter(Collider col)                              //카드 왼쪽에서 충돌이 있다면
    {
        manager.setflag("left", true);                              //카드매니저의 충돌판정

        col.SendMessage("ret_number", name);                //name에 쓰여진 태그로 다시 위치정보 전달
    }
    void ret_number(string str)
    {
        GameObject objs = GameObject.FindGameObjectWithTag(str);    //태그에 str에 담긴정보로 오브젝트를 탐색
        int i = manager.get_called_num();                           //카드 매니저에서 위치정보를 받아옴
        string temp1 = i.ToString();                                //int형 string 형변환
        string str1 = manager.get_text();
        string[] temp2 = {str1, temp1, "L" };                         //sendmessage는 인자로 1개밖에 전달못함.
        objs.SendMessage("setString", temp2);                       //찾은 오브젝트에 함수에 인자값을 전달
    }                                                               //오브젝트는 setString함수를 temp2 배열을 인자로 실행

    void setString(string[] array)                                  //카드매니저의 함수를 실행
    {                            
        manager.SendMessage("check_update",array);                                //카드매니저 함수 실행
    }

    public int get_call_of_num()                                    //카드매니저에서 위치정보 받아옴
    {
        cardmanagerZ man = manager.GetComponent<cardmanagerZ>();    //임시 man이라는 객체에 상위 카드매니저 할당. 실제값 변경가능
        return man.get_called_num();                                //위치정보 리턴
    }

    public string get_string()                                      //카드매니저에서 현재 태그 리턴
    {
        cardmanagerZ man = manager.GetComponent<cardmanagerZ>();    //임시 man이라는 객채에 카드매니저 그자체를 할당. 실제값 변경가능
        return man.get_text();                                      //태그에 저장된값 리턴
    }

    void OnTriggerExit()                                            //카드가 왼쪽에서 떨어질때
    {
        manager.setflag("left", false);                             //왼쪽에 충돌판정 플래그 내림
    }

	// Use this for initialization
	void Start () {
        name = "planmarnagerZL";
    }
}
