using UnityEngine;
using System.Collections;
using DG.Tweening;

public class EditPage : MonoBehaviour {
    static public EditPage instance;
    public void SetInstance()
    {
        instance = this; //자아라는 것을 알게 됨
        gameObject.SetActive(false); // true : 게임을 열고 있음.
    }
    void OnEnable()
    {
        GameObject UI = transform.FindChild("UI").gameObject;
        //자식 중에서 찾기
        UI.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        UI.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutExpo);
        //0.3f -> 속도
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Init()
    {
        print("Init");
        gameObject.SetActive(true);
    }

    public void MessageClose()
    {
        gameObject.SetActive(false);
    }
}
