using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class togglescript : MonoBehaviour {

    GameObject inGameToggle;

    private int vibration;
	// Use this for initialization
	public void OnChangedVal()
    {
        if (inGameToggle.GetComponent<Toggle>().isOn)
        {
            vibration = 1;
            PlayerPrefs.SetInt("vibration", 1);
            Debug.Log("changed, 1");
        }
        else
        {
            vibration = -1;
            PlayerPrefs.SetInt("vibration", -1);
            Debug.Log("changed, -1");
        }
    }

    void Start()
    {
        vibration = PlayerPrefs.GetInt("vibration", 0);
        Debug.Log("current : "+vibration);
        inGameToggle = GameObject.Find("Toggle");
        if (vibration == -2)
        {
            vibration = 1;
            PlayerPrefs.SetInt("vibration", 1);
        }
        else
        {
            if(vibration == 1)
            {
                inGameToggle.GetComponent<Toggle>().isOn = true;
                PlayerPrefs.SetInt("vibration", 1);
            }
            else
            {
                inGameToggle.GetComponent<Toggle>().isOn = false;
                PlayerPrefs.SetInt("vibration", -1);
            }
        }

    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
