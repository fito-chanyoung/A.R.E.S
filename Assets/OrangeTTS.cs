using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using InfinityEngine.Localization;

public class OrangeTTS : MonoBehaviour, IVirtualButtonEventHandler
{

    //public GameObject vbBtnObj;
    private string lang;
    VirtualButtonBehaviour[] virtualButtonBehaviours;
    // Use this for initialization
    void Start()
    {
        //vbBtnObj = GameObject.Find("orangeButton");
        //vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < virtualButtonBehaviours.Length; ++i)
        {
            virtualButtonBehaviours[i].RegisterEventHandler(this);
        }
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("OnButtonPressed: " + vb.VirtualButtonName);
        Debug.Log("lang : " + PlayerPrefs.GetString("lang"));
        lang = PlayerPrefs.GetString("lang");
        if (lang != "kr")
        {
            Locale local = new Locale("English", "en", "US");
            SpeechEngine.SetLanguage(local);
            //AndroidJavaObject aobj= new AndroidJavaObject("James");
            //Voice voice = new Voice(aobj);
            //SpeechEngine.SetVoice(voice);
            SpeechEngine.Speak("orange");
        }
        else
        {
            Locale local = new Locale("Korean", "ko", "KR");
            SpeechEngine.SetLanguage(local);
            SpeechEngine.Speak("오렌지");
        }
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
    // Update is called once per frame
    void Update()
    {

    }
}
