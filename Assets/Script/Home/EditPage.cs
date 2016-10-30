using UnityEngine;
using System.Collections;
using DG.Tweening;

public class EditPage : MonoBehaviour {
    //public Transform cubeA;
    static public EditPage instance;
    public void SetInstance()
    {
        instance = this; //자아라는 것을 알게 됨
        gameObject.SetActive(false); // true : 게임을 열고 있음.
    }

    // Use this for initialization
    void OnEnable()
    {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
        transform.localScale = new Vector3(0.1f, 0.1f,0.1f);
        //transform.DOMove(new Vector3(-2, 2, 0), 1).SetRelative().SetLoops(-1, LoopType.Yoyo); //무한대, yoyo 타입/
        transform.DOScale(1, 0.2f).SetEase(Ease.OutCirc);
    }

    // Update is called once per frame
    void Update () {
	
	}

    public void Init()
    {
        gameObject.SetActive(true);
    }

    public void MessageClose()
    {
        gameObject.SetActive(false);
    }
}
