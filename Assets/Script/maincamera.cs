using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class maincamera : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Screen.SetResolution(1440,2560, true);
        Camera mainCamera = Camera.main;
        if (mainCamera)
        {
            if (mainCamera.GetComponent<VuforiaBehaviour>() != null)
            {
                mainCamera.GetComponent<VuforiaBehaviour>().enabled = false;
            }
            if (mainCamera.GetComponent<VideoBackgroundBehaviour>() != null)
            {
                mainCamera.GetComponent<VideoBackgroundBehaviour>().enabled = false;
            }
            if (mainCamera.GetComponent<DefaultInitializationErrorHandler>() != null)
            {
                mainCamera.GetComponent<DefaultInitializationErrorHandler>().enabled = false;
            }
        }
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
	}
}
