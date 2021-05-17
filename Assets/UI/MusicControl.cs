using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicControl : MonoBehaviour
{
    public Slider slider;
    public InputField inputField;
    public GameObject musicPlayer;

    private bool volumeMaxed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        slider.value = musicPlayer.GetComponent<AudioSource>().volume * 100;
        inputField.text = slider.value.ToString();
    }

    public void volumeSlider()
    {
        if (volumeMaxed == true)
        {
            volumeMaxed = false;
        }

        else
        {
            musicPlayer.GetComponent<AudioSource>().volume = slider.value / 100;

            inputField.text = Mathf.Round(slider.value).ToString();
            //inputField.text = slider.value.ToString();
        }
    }

    public void volumeInput()
    {

        if (float.Parse(inputField.text) > slider.maxValue)
        {
            volumeMaxed = true;
            slider.value = slider.maxValue;
            musicPlayer.GetComponent<AudioSource>().volume = slider.maxValue / 100;
            inputField.text = slider.value.ToString();
        }

        else
        {
            slider.value = float.Parse(inputField.text);
            musicPlayer.GetComponent<AudioSource>().volume = slider.value / 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
