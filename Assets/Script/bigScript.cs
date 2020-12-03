using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bigScript : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    { 
            other.SendMessage("send_type");             //부딪힌 명사카드에 send_type 실행
            GameObject.Find("Manager").SendMessage("SetAbj", "big");//매니저에 setAbj함수를 태그로 인자로 실행
        Debug.Log("Collider enter");
    }
    void OnTriggerExit()
    {
        GameObject.Find("Manager").SendMessage("destroy");  //충돌이 끝날때 매니저에게 destroy 실행 요청
    }
	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
