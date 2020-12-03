using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class cardmanagerZ : MonoBehaviour
{

    private int num_of_called;                      //위치

    //public TextMesh textmesh;
    public BoxCollider2D col_left;
    public BoxCollider2D col_right;

    private bool left;                              //업데이트 될때마다 상태
    private bool right;

    private bool before_left;                       //이전의 상태값
    private bool before_right;

    private string target_text;                     //카드에 담긴 알파벳

    void check_update(string[] array)               //void OnTriggerEnter()
    {
        /*Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].SendMessage("update_text", target_text);
        } 이거는 무시
        GameObject.FindWithTag("GameController").GetComponent<manager>().inc_count();
        GameObject.FindWithTag("GameController").GetComponent<manager>().translate(textmesh.text);
        */

        int num = int.Parse(array[1]);

        if (left)                                   //만약 왼쪽에서 충돌이 있다면
            if (!before_left)                       //이거 없으면 매 프레임마다 실행됨
            {
                update_text_all(array[0], num, array[2]);   //함수 실행
                before_left = true;                 //중복 실행 방지를 위한 플래그
            }
        else if (right)                             //만약 오른쪽에서 충돌이 있다면(프레임마다)
            if (!before_right)                      //전에는 충돌이 없었다면
            {
                    before_right = true;            //충돌이 있었음을 표시
                update_text_all(array[0], num, array[2]);   //함수 실행
            }
        if (!left)                                  //왼쪽에서 충돌이 없음
            if (before_left)                        //이전에는 충돌한 상태
            {
                before_left = false;                //충돌이 없었음으로 표시
                GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);//같은 태그의 오브젝트들을 찾음
                int i = 0;

                while (true)
                {
                    if (i == objs.Length)           //같은 태그의 오브젝트들의 수와 같다면
                        break;                      //와일문에서 나감
                    else
                    {
                        objs[i].SendMessage("delete",num_of_called - 1);//아니면 자신의 왼쪽 위치정보를 전달
                        i++;
                    }
                }
            }     
        else if(!before_right)                      //오른쪽에서 충돌이 없음
            if (before_right)                       //오른쪽은 이전에 충돌한 상태였다면
            {
                before_right = false;               //충돌기록 삭제
                GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);//자식과같은 태그를 가진 오브젝트들 탐색
                int i = 0;

                while (true)
                {
                    if (i == objs.Length)           //탐색된 오브젝트의수와 같다면
                        break;                      //와일문 벗어남
                    else
                    {
                            objs[i].SendMessage("delete", num_of_called + 1);//그동안은 자신의 오른쪽 위치정보를 전달
                            i++;
                    }
                }
            }
        if(!left && !right)                         //양쪽에 충돌이 없다
            if(!before_right && !before_left)         //양쪽에 충돌기록도 없어졌다면
            {
                gameObject.tag = target_text;       //초기화
                num_of_called = 0;
            }
    }

    /*void OnTriggerExit()
    {
        /*
        textmesh.text = target_text;
        gameObject.tag = textmesh.text;
        textmesh.gameObject.SetActive(false);
        GameObject.FindWithTag("GameController").GetComponent<manager>().dec_count();

        GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
        int i = 0;
        while (true)
        {
            if (i == objs.Length)
                break;
            else
            {
                string num_of_call = num_of_called.ToString();
                string[] array = { target_text, num_of_call };
                objs[i].delete(num_of_call);
            }
        }
        gameObject.tag = target_text;
       // textmesh.gameObject.SetActive(false);
    }*/
   public void setflag(string name, bool boolean)           //플래그 정리
    {
        if (name == "left")                                 //왼쪽에서 충돌 관련 이벤트가 발생
            left = boolean;                                 //플래그를 이벤트에 맞게 설정
        else
            right = boolean;                                //오른쪽도 동일
    }

    public int get_called_num()                             //위치정보를 반환
    {
        return num_of_called;                       
    }
    public string get_text()                                //현재 태그에 담고있는 알파벳들을 반환
    {
        return gameObject.tag;
    }
    public void delete(int num)                             //위치정보를 기반으로 카드 삭제
    {
        string temp_tag = gameObject.tag;                   //임시 정보
        string result;                                      //결과값저장
        int inum = num;                                     //임시 저장
        if (inum > num_of_called)                           //없어지는 데이터의 위치정보가 자신보다 크다(오른쪽이다)
        {
            temp_tag.Substring(0, inum - 1);                //앞에서부터 삭제되는 카드직전까지 스트링을 태그에 저장
        }
        else if (inum < num_of_called)                      //없어지는 데이터의 위치정보가 자신보다 작다(왼쪽이다)
        {
            temp_tag.Substring(inum + 1);                   //삭제되는 카드 오른쪽에서부터 끝까지의 알파벳들을 태그에 저장
            num_of_called -= inum;                          //위치정보 갱신
        }
        gameObject.tag = temp_tag;                          //태그에 저장
    }

    public void update_text_all(string str1, int num, string str2)  //모든 카드 업데이트
    {
        string temp = gameObject.tag;                       //태그정보 임시 저장
        GameObject[] objs = GameObject.FindGameObjectsWithTag(temp);//자신과 같은 모든 태그들을 찾음
        int i = 0;                                          
        string num_to_string = num.ToString();              //스트링으로 인트형 형변환

        string[] array = {str1,num_to_string,str2};         //sendmessage는 인자는 오로지 하나만 가능
        while (true)
        {
            if (i == objs.Length)                           //찾은 오브젝트와 같은 수라면
                break;                                      //와일을 빠져나옴
            else
            {
                objs[i].SendMessage("update_tag",array);    //같은 태그의 오브젝트들에게 update_tag함수 실행 요청
                i++;                                        //인자는array안에 들어있음
            }
        }

        if (str2 == "R")                                    //태그 업데이트
        {
            gameObject.tag = gameObject.tag + str1;         //오른쪽에서 새로운 카드가 부딪친경우
        }
        if (str2 == "L")                                    //왼쪽인경우
        {
            gameObject.tag = str1 + gameObject.tag;
            num_of_called += num;
        }
        /*textmesh.text =textmesh.text+text;
        gameObject.tag = textmesh.text;
        num_of_called++;*/

    }

    public void update_tag(string[] array)                  //태그 업데이트 함수
    {
        if (array[2] == "R")                                //오른쪽끝에서 뭔가 들어왔다면
        {
            gameObject.tag = gameObject.tag + array[0];      
        }
        else                                                //왼쪽에서 카드가 들어왔다면
        {
            gameObject.tag = array[0] + gameObject.tag;     //왼쪽에 태그 업데이트
            int temp = int.Parse(array[1]);                 //위치정보 갱신
            num_of_called += temp;                          
        }
    }

    /*public void gm_update(int hcounter, string text)
    {
        /*if (hcounter == num_of_called)
        {
            textmesh.text = text;
            textmesh.gameObject.SetActive(true);
        }
    }*/

    // Use this for initialization
    void Start()
    {
        target_text = "z";                                  //초기값
        left = right = before_left = before_right = false;  


    }

    // Update is called once per frame

}
