using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MainGameCanvas : MonoBehaviour {

    MainGameCanvas mainGameCanvas;
    EditPage editPage;

    void Awake()
    {
        print(name);
        editPage = transform.FindChild("EditPage").GetComponent<EditPage>();
        editPage.SetInstance();
    }
}
