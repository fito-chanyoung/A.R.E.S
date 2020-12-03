using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Vuforia;

public class animaScript : MonoBehaviour {

    private bool isPlaying = false;
    private float time = 0f;

    public UnityEngine.UI.Image fadeimage;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(2880,1440, true);
        Screen.autorotateToPortrait = true;
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

        startFadeIn();
        PlayerPrefs.SetInt("vibration", -2);
        
    }
    void startFadeIn()
    {
        if (isPlaying)
            return;
        Debug.Log("trying to fadein");
        StartCoroutine("RunFadeIn");
    }
    void startStay()
    {
        if (isPlaying)
            return;
        Debug.Log("trying to stay");
        StartCoroutine("Stay");
    }
    void startFadeout()
    {
        if (isPlaying)
            return;
        Debug.Log("trying to fadeout");
        StartCoroutine("RunFadeOut");
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator RunFadeOut()
    {
        Debug.Log("fade out");
        isPlaying = true;

        Color color = fadeimage.color;
        time = 0f;
        color.a = UnityEngine.Mathf.Lerp(0f, 1f, time);

        while(color.a < 1f)
        {
            time += Time.deltaTime / 2f;

            color.a = UnityEngine.Mathf.Lerp(0f, 1f, time);
            fadeimage.color = color;
            yield return null;
        }
        isPlaying = false;
        SceneManager.LoadScene("mainScene");
    }
    IEnumerator Stay()
    {
        Debug.Log("stay");
        isPlaying = true;

        time = 0f;

        while (time < 1f)
        {
            time += Time.deltaTime / 2f;

            yield return null;
        }
        isPlaying = false;
        startFadeout();
    }
    IEnumerator RunFadeIn()
    {
        Debug.Log("fade in");
        isPlaying = true;

        Color color = fadeimage.color;
        time = 0f;
        color.a = UnityEngine.Mathf.Lerp(1f, 0f, time);

        while (color.a > 0.1f)
        {
            time += Time.deltaTime / 2f;

            color.a = Mathf.Lerp(1f, 0f, time);
            fadeimage.color = color;
            yield return null;
        }
        isPlaying = false;
        startStay();
    }
}
