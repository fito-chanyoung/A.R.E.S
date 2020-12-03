using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class configscript : MonoBehaviour {

    public GameObject panel;
    public GameObject panel1;

    public void onClick()
    {
        panel.SetActive(true);
        panel1.SetActive(true);
    }

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
