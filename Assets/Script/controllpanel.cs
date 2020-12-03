using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllpanel : MonoBehaviour {

    public GameObject panel;
	// Use this for initialization
	void Start () {
		gameObject.SetActive(false);
        }
	public void onclick()
    {
        gameObject.SetActive(true);
    }

    public void setDisable()
    {
        gameObject.SetActive(false);
        panel.SetActive(false);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
