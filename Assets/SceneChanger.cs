using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

	// Use this for initialization
	void Start () {

	}
   public void loadar()
    {
        SceneManager.LoadScene("CARDS");
    }
    public void loadmain()
    {
        SceneManager.LoadScene("mainScene");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
