using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SliderBGmusic : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    AudioSource bgmusic;
    Slider slider;

    void Awake()
    {
        
        bgmusic = GameObject.Find("SoundInspector").GetComponent<AudioSource>();
        slider = GameObject.Find("BGSlider").GetComponent<Slider>();
        slider.value = PlayerPrefs.GetFloat("volume");
    }
	
	// Update is called once per frame
	void Update () {
        bgmusic.volume = slider.value;
        PlayerPrefs.SetFloat("volume", bgmusic.volume);

    }
}
