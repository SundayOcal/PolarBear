using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class BtnAlarm : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

    Image bgimg, onoff;
    Transform beforeposx, afterposx;
    Text text;
    bool onButton = true;

    void Awake()
    {
        bgimg = transform.FindChild("Alarm_bgimg").GetComponent<Image>();
        onoff = transform.FindChild("Alarm_onoff").GetComponent<Image>();
        beforeposx = transform.FindChild("Beforeposx");
        afterposx = transform.FindChild("Afterposx");
        text = transform.FindChild("Alarm_onoff").FindChild("Text").GetComponent<Text>();
    }
    // Update is called once per frame
    void Update () {
	
	}
    public void MyonClick()
    {
        if (!onButton)
        { //알람 켜기
            onoff.transform.DOMove(beforeposx.position, (float)0.2);
            text.text = "ON";
            EnableAlarm(true);
            onButton = false;
        }
        else
        { //알람 끄기
            onoff.transform.DOMove(afterposx.position, (float)0.2);
            text.text = "OFF";
            EnableAlarm(false);
            onButton = true;
        }
    }
    private void EnableAlarm(bool ison)
    {
        if(!ison)
        {
            print("알람 끄기");

        }
        else
        {
            print("알람 실행");
        }
    }
}
