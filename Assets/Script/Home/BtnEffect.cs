using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DG.Tweening;

public class BtnEffect : MonoBehaviour {

    Image bgimg, onoff;
    Transform beforeposx, afterposx;
    Text text;
    bool isClick = true;
    void Awake()
    {
        bgimg = transform.FindChild("Effect_bgimg").GetComponent<Image>();
        onoff = transform.FindChild("Effect_onoff").GetComponent<Image>();
        beforeposx = transform.FindChild("Beforeposx");
        afterposx = transform.FindChild("Afterposx");
        text = transform.FindChild("Effect_onoff").FindChild("Text").GetComponent<Text>();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void MyonClick()
    {
        if (isClick)
        {
            onoff.transform.DOMove(afterposx.position, (float)0.2);
            text.text = "OFF";
            isClick = false;
        }
        else
        {
            onoff.transform.DOMove(beforeposx.position, (float)0.2);
            text.text = "ON";
            isClick = true;
        }
    }
}
