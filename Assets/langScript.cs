using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class langScript : MonoBehaviour {

   
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void switchLang()
    {
        string lang = PlayerPrefs.GetString("lang");
        if (lang == "kr")
            PlayerPrefs.SetString("lang", "US");
        else
            PlayerPrefs.SetString("lang", "kr");

        return;
    }
}
