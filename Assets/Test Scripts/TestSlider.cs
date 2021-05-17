using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestSlider : MonoBehaviour
{
    public GameObject spawner;
    public Slider slider;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void valueChange()
    {
        spawner.GetComponent<BoidSpawner>().maxBoids = Mathf.RoundToInt(slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
