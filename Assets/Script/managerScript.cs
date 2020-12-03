using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class managerScript : MonoBehaviour
{

    private string noun;            //명사 카드 태그 저장용
    private string type1;           //명사카드 타입 저장용1
    private string type2;           //명사카드 타입 저장용2
    private string abj;             //형용사 카드 태그 저장용

    private bool flag_noun = false;  //명사 카드 확인용
    private bool flag_abj = false;
    private bool changed = false;   //크기 제어용

    private GameObject original;

    void SetAbj(string temp)        //형용사 명사 카드 충돌시 실행, 형용사 카드에서 요청
    {
        abj = temp;                 //형용사 저장
        flag_abj = true;            //플레그 세움
        Debug.Log("abj set");
    }
    void SetNoun(string[] temp)     //카드 충돌시 실행. 형용사카드에서 명사카드에 전송 요청
    {
        type1 = temp[0];            //타입 저장1
        type2 = temp[1];            //타입 저장2
        noun = temp[2];             //명사 카드 저장
        flag_noun = true;           //플래그 작성
        Debug.Log("noun set");
    }
    void check()                    //테이블 실행 부분.
    {
        if (type1 == "countable" && type2 == "visible" && !changed)
        {     //만약 보이고, 셀수있는 명사라면
              /*if (abj == "big" && !changed)
              {
                  scale = GameObject.FindWithTag(noun).transform.localScale;
                  GameObject.FindWithTag(noun).transform.localScale += new Vector3(5, 5, 5);
                  changed = true;
              }*/
            int vib = PlayerPrefs.GetInt("vibration");
            if (vib == 1)
                Handheld.Vibrate();
            original = GameObject.Find(noun);
            switch (abj)
            {                                   //만약 보이고, 셀수있는 명사라면
                case "big":                     //여기로 와서 형용사에 따라서 실행됨. 
                            changed = true;
                            //Debug.Log(temp);
                            original.transform.localScale *= 2;
                    break;
                case "small":
                            changed = true;
                            original.transform.localScale /= 2;
                        break;
                   
                case "three":
                        changed = true;

                        Debug.Log("1");
                        GameObject newObject1 = Instantiate(original, original.transform.parent);   //클론 오브젝트 생성
                        GameObject newObject2 = Instantiate(original, original.transform.parent);  //및 위치 상속
                        newObject1.name = "clone1";
                        newObject2.name = "clone2";

                        newObject1.transform.localPosition = original.transform.localPosition;
                        newObject2.transform.localPosition = original.transform.localPosition;
                        newObject1.transform.localPosition += new Vector3(-0.2f, 0.0f, 0.1f);//겹친 상태 해소
                        newObject2.transform.localPosition += new Vector3(0.2f, 0, 0.1f);
                        original.transform.localPosition += new Vector3(0, 0, -0.2f);
                    
                    break;
                case "red":

                            changed = true;
                            original.GetComponent<Renderer>().material.color += new Color(0.5f, 0, 0, 0);
                    break;
                default:
                    return;
            }
        }
        else if (type1 == "countable" && type2 == "nonvisible") { }  //셀수 있지만 보이지 않는 돈같은 명사
        else if (type1 == "noncountable" && type2 == "visible") { }    //셀수도 없고 보이지도 않는 감정같은 명사.
        else { }
    }
    void destroy()                                  //형용사의 OnTriggerEnter가 실행되면 요청됨.
    {
        switch (abj)
        {
            case "big":                          //형용사 카드에 따라 실행되는것이 달라짐. 
                    original.transform.localScale /= 2;

                break;
            case "small":

                    original.transform.localScale *= 2 ;

                break;
            case "three":

                    Debug.Log("2");
                    original.transform.localPosition += new Vector3(0, 0, 0.2f);
                    Object.Destroy(GameObject.Find("clone1"));
                    Object.Destroy(GameObject.Find("clone2"));

                    break;
            case "red":

                    original.GetComponent<Renderer>().material.color -= new Color(0.5f, 0, 0, 0);
                    changed = false;

                    break;
            default:
                changed = flag_abj = flag_noun = false;
                return;
        }
         //모든 플래그 내림.
    }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (flag_noun && flag_abj)
            {
                check();
            }
        }
    
}
  