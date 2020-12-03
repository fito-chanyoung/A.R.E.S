using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using InfinityEngine.Localization;

public class WolfTTS : MonoBehaviour,IVirtualButtonEventHandler {

    private GameObject vbBtnObj;
    private string lang;
	// Use this for initialization
	void Start () {
        vbBtnObj = GameObject.Find("WolfButton");
        vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
    public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        lang = PlayerPrefs.GetString("lang");
        if (lang != "kr")
        {
            Locale local = new Locale("English", "en", "US");
            SpeechEngine.SetLanguage(local);
            //AndroidJavaObject aobj= new AndroidJavaObject("James");
            //Voice voice = new Voice(aobj);
            //SpeechEngine.SetVoice(voice);
            SpeechEngine.Speak("wolf");
        }
        else
        {
            Locale local = new Locale("Korean", "ko", "KR");
            SpeechEngine.SetLanguage(local);
            SpeechEngine.Speak("늑대");
        }
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
	// Update is called once per frame
	void Update () {
		
	}
}
