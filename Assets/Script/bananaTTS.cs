using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using InfinityEngine.Localization;

public class bananaTTS : MonoBehaviour,IVirtualButtonEventHandler {

    //public GameObject vbBtnObj;
    private string lang;
    VirtualButtonBehaviour[]     virtualButtonBehaviours;
    // Use this for initialization
    void Start () {
        //vbBtnObj = GameObject.Find("BananaButton");
        //vbBtnObj.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
        virtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

        for (int i = 0; i < virtualButtonBehaviours.Length; ++i)
        {
            virtualButtonBehaviours[i].RegisterEventHandler(this);
        }
    }
	public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
        Debug.Log("btnObj toched");
        lang = PlayerPrefs.GetString("lang");
        if (lang != "kr")
        {
            Locale local = new Locale("English", "en", "US");
            SpeechEngine.SetLanguage(local);
            //AndroidJavaObject aobj= new AndroidJavaObject("James");
            //Voice voice = new Voice(aobj);
            //SpeechEngine.SetVoice(voice);
            SpeechEngine.Speak("banana");
        }
        else
        {
            Locale local = new Locale("Korean", "ko", "KR");
            SpeechEngine.SetLanguage(local);
            SpeechEngine.Speak("바나나");
        }
    }
    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {

    }
	// Update is called once per frame
	void Update () {
		
	}
}
