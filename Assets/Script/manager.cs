using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class manager : MonoBehaviour {


    private int num_of_word;
    private string[] arr;
    private int[] num;
    private int counter;
    private int hcounter;
    string Path = "Assets/Resources/";

    /*void manage_count(string name, int count)
        {
            int temp = find_num(name);
            if (temp != -1)
            {
                if (num[temp] < count)
                {
                    num[temp] = count;
                }
            }
            else
            {
                arr[num_of_word] = name;
                num[num_of_word] = count;
                num_of_word++;
            }
        string discript = find_dis(name,temp);
        string counter = calculate(count);
        string[] arr2 = { discript, counter};
        if (discript != "-1")
            GameObject.Find("ImageTarget").SendMessage("descript", arr2);
        }
    string calculate(int num)
    {
        if (num == 1)
        {
            return "0";
        }
        else
        {
            num=num / 2;
            string temp = num.ToString();
            return temp;
        }
    }
    int find_num(string name)
        {
            for(int i=0; i < num_of_word; i++)
            {
                if (arr[i] == name)
                    return i;
            }
            return -1;
    }
    string find_dis(string name, int count)
    {
        string F = name[0]+".txt";
        F.ToString();
        string temp_path = Path+F;
        StreamReader sr = new StreamReader(temp_path);
        string input;
        while (true)
        {
            input = sr.ReadLine();
            if (input == name)
            {
                input = sr.ReadLine();
                break;
            }
            else if (input == null)
                break;
            sr.Close();
        }
        if(input == null)
        {
            string result = "-1";
            return result;
        }
        else
            return input;
    }*/

    public void inc_count()
    {
        counter++;
        hcounter = counter / 2;
    }
    public void dec_count()
    {
        counter--;
        hcounter = counter / 2;
    }
    
	// Use this for initialization
	void Start () {
        num_of_word = 0;
        counter = 0;
        hcounter = 0;
}
	
    public void translate(string name)
    {
        string F = name[0] + ".txt";
        string temp_path = Path + F;
        StreamReader sr = new StreamReader(temp_path);
        string input;
        while (true)
        {
            input = sr.ReadLine();
            if (input == name)
            {
                input = sr.ReadLine();
                break;
            }
            else if (input == null)
                break;
            sr.Close();
        }
        if (input != null)
        {
            BroadcastMessage("gm_update", hcounter);
        }

    }
	// Update is called once per frame
	void Update () {
		
	}

     
    
}
