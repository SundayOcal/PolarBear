using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour {

    static public Home instance;
    public void SetInstance()
    {
        instance = this; //자아라는 것을 알게 됨
        gameObject.SetActive(true); // true : 게임을 열고 있음.
    }

    public void MessageOpenEditPage()
    {
        EditPage.instance.Init();
    }

	public void MessageGameStart()
	{
		SceneManager.LoadScene ("Main");
	}

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
