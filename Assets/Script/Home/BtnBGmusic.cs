using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class BtnBGmusic : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    Image bgimg, onoff;
    Transform beforeposx, afterposx;
    Text text;
    bool onButton = true;
    AudioSource bgmusic;

    void Awake()
    {
        bgimg = transform.FindChild("BGmusic_bgimg").GetComponent<Image>();
        onoff = transform.FindChild("BGmusic_onoff").GetComponent<Image>();
        beforeposx = transform.FindChild("Beforeposx");
        afterposx = transform.FindChild("Afterposx");
        text = transform.FindChild("BGmusic_onoff").FindChild("Text").GetComponent<Text>();
        bgmusic = GameObject.Find("SoundInspector").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MyonClick()
    {
        if (!onButton)
        {
            onoff.transform.DOMove(beforeposx.position, (float)0.2);
            text.text = "ON";
            EnableAlarm(true);
            onButton = true;
        }
        else
        {
            onoff.transform.DOMove(afterposx.position, (float)0.2);
            text.text = "OFF";
            EnableAlarm(false);
            onButton = false;
            print("음악켜기");
        }
    }
    private void EnableAlarm(bool ison)
    {
        if (!ison)
        {

            print("알람 끄기");
            bgmusic.volume = 0;

        }
        else
        {
            print("알람 실행");
            bgmusic.volume = 1;
        }
    }
}
