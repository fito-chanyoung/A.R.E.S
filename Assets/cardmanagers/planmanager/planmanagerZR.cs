using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/*
 * 자세한것은 planmanagerZL을 보면됨.
 * 클래스 이름, setflag 인자, sendmessage 인자값만 다름
 */

public class planmanagerZR : MonoBehaviour {

    public cardmanagerZ manager;

    private string name = "planmarnagerZL";                     //이름만다름

    void OnTriggerEndter(Collider col)                          //다른 카드가 오른쪽에서 충돌
    {
        manager.setflag("right", true);
        col.SendMessage("ret_number", name);
    }
    void ret_number(string str)
    {
        GameObject objs = GameObject.FindGameObjectWithTag(str);
        int i = manager.get_called_num();
        string temp1 = i.ToString();
        string str1 = manager.get_text();
        string[] temp2 = { str1, temp1, "L" };
        objs.SendMessage("setString", temp2);
    }

    void setString(string[] array)
    {
        int temp = int.Parse(array[1]);
        manager.update_text_all(array[0], temp, array[2]);
    }

    public int get_call_of_num()
    {
        cardmanagerZ man = manager.GetComponent<cardmanagerZ>();
        return man.get_called_num();
    }

    public string get_string()
    {
        cardmanagerZ man = manager.GetComponent<cardmanagerZ>();
        return man.get_text();
    }

    void OnTriggerExit()
    {
        manager.setflag("right", false);
    }

    // Use this for initialization
    void Start () {
        name = "planmanagerZR";
	}
}
