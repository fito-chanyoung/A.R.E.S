using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardmanagerV : MonoBehaviour
{

    private int num_of_called;

    //public TextMesh textmesh;
    public BoxCollider2D col_left;
    public BoxCollider2D col_right;

    private bool left;          //check current status
    private bool right;

    private bool before_left;   //check befor status
    private bool before_right;

    private string target_text; //카드에 담긴 알파벳

    void check_update() //void OnTriggerEnter()
    {
        /*Collider[] hitColliders = Physics.OverlapSphere(transform.position, 100);
        for (int i = 0; i < hitColliders.Length; i++)
        {
            hitColliders[i].SendMessage("update_text", target_text);
        }
        GameObject.FindWithTag("GameController").GetComponent<manager>().inc_count();
        GameObject.FindWithTag("GameController").GetComponent<manager>().translate(textmesh.text);
        */
        if (left)
            if (!before_left)
            {
                planmanagerZL manager = col_left.GetComponent<planmanagerZL>();
                int tempnum = manager.get_call_of_num();
                string temp = manager.get_string();
                update_text_all(temp, tempnum + 1, "L");
            }
            else if (right)
                if (!before_right)
                {
                    planmanagerZR manger = col_right.GetComponent<planmanagerZR>();
                    string temp = manger.get_string();
                    update_text_all(temp, num_of_called, "R");
                }
        if (!left)
            if (before_left)
            {
                before_left = false;
                GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
                int i = 0;

                while (true)
                {
                    if (i == objs.Length)
                        break;
                    else
                    {
                        objs[i].SendMessage("delete", num_of_called - 1);
                    }
                }
            }
            else if (!before_right)
                if (before_right)
                {
                    before_right = false;
                    GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
                    int i = 0;

                    while (true)
                    {
                        if (i == objs.Length)
                            break;
                        else
                        {
                            objs[i].SendMessage("delete", num_of_called + 1);
                        }
                    }
                }
        if (!left && !right)
            if (before_right && before_left)
            {
                gameObject.tag = target_text;
                before_left = before_right = false;
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
    public void setflag(string name, bool boolean)
    {
        if (name == "left")
            left = boolean;
        else
            right = boolean;
    }

    public int get_called_num()
    {
        return num_of_called;
    }
    public string get_text()
    {
        return gameObject.tag;
    }
    public void delete(int num)
    {
        string temp_tag = gameObject.tag;
        string result;
        int inum = num;
        if (inum > num_of_called)
        {
            temp_tag.Substring(0, inum - 1);
        }
        else if (inum < num_of_called)
        {
            temp_tag.Substring(inum + 1);
            num_of_called -= inum;
        }
        gameObject.tag = temp_tag;
    }

    public void update_text_all(string str1, int num, string str2)
    {
        string temp = gameObject.tag;
        GameObject[] objs = GameObject.FindGameObjectsWithTag(temp);
        int i = 0;
        string num_to_string = num.ToString();

        string[] array = { str1, num_to_string, str2 };
        while (true)
        {
            if (i == objs.Length)
                break;
            else
            {
                objs[i].SendMessage("update_tag", array);
            }
        }

        if (str2 == "R")
        {
            gameObject.tag = gameObject.tag + str1;
        }
        if (str2 == "L")
        {
            gameObject.tag = str1 + gameObject.tag;
            num_of_called += num;
        }
        /*textmesh.text =textmesh.text+text;
        gameObject.tag = textmesh.text;
        num_of_called++;*/

    }

    public void update_tag(string[] array)
    {
        if (array[2] == "R")
        {
            gameObject.tag = gameObject.tag + array[0];
        }
        else
        {
            gameObject.tag = array[0] + gameObject.tag;
            int temp = int.Parse(array[1]);
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
        target_text = "v";
        left = right = before_left = before_right = false;
    }

    // Update is called once per frame
    void Update()
    {
        check_update();
    }
}
