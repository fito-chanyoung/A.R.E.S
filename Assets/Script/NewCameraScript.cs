using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class NewCameraScript : MonoBehaviour {


    private Transform target;
    private Touch tempTouch;

    public Camera camera;
    //public TextMesh head;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(1440, 2560, true);
        //head.gameObject.SetActive(false);
        //target = head.transform;
    }
	
	// Update is called once per frame
	void Update () {
        /*RaycastHit hit = new RaycastHit();
        for (int i = 0; i < Input.touchCount; i++)
        {
            tempTouch = Input.GetTouch(i);
            if (tempTouch.phase.Equals(TouchPhase.Began))
            {
                // Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                if (Physics.Raycast(ray, out hit))
                {
                    //head.gameObject.SetActive(true);
                    Vector3 pos = camera.WorldToScreenPoint(target.position);

                    //head.transform.position = new Vector3(pos.x=1.0f, pos.y, head.transform.position.z);
                }
            }
        }*/
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
