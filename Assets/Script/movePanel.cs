using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePanel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	void Update()
    {
        Vector3 newPosition = new Vector3(0,0,0);
        newPosition.y += Mathf.Sin(Time.time) * Time.deltaTime*1000;
        transform.position += newPosition;

    }
}
