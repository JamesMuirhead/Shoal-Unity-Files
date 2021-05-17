using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParamUI : MonoBehaviour
{
    public static bool paramOpen = false;
    public GameObject screen;
    public GameObject boidSpawner;
    public GameObject predSpawner;

    public Slider maxBoidSlider;
    public InputField maxBoidInput;
    public Slider boidRespawnSlider;
    public InputField boidRespawnInput;
    public Slider maxPredSlider;
    public InputField maxPredInput;
    public Slider predRespawnSlider;
    public InputField predRespawnInput;

    private bool boidsMaxed = false;
    private bool boidRespawnMaxed = false;
    private bool predMaxed = false;
    private bool predRespawnMaxed = false;

    // Start is called before the first frame update
    void Start()
    {
        // Sets sliders to starting values
        maxBoidSlider.value = boidSpawner.GetComponent<BoidSpawner>().maxBoids;
        boidRespawnSlider.value = boidSpawner.GetComponent<BoidSpawner>().spawnCooldown;
        maxPredSlider.value = predSpawner.GetComponent<PredatorSpawner>().maxPredators;
        predRespawnSlider.value = predSpawner.GetComponent<PredatorSpawner>().spawnCooldown;

        // Displays starting value on input box
        maxBoidInput.text = maxBoidSlider.value.ToString();
        boidRespawnInput.text = boidRespawnSlider.value.ToString();
        maxPredInput.text = maxPredSlider.value.ToString();
        predRespawnInput.text = predRespawnSlider.value.ToString();

        screen.SetActive(false);
        paramOpen = false;
}

    public void maxBoidSliderChange()
    {
        if(boidsMaxed == true)
        {
            boidsMaxed = false;
        }

        else
        {
            boidSpawner.GetComponent<BoidSpawner>().maxBoids = Mathf.RoundToInt(maxBoidSlider.value);
            maxBoidInput.text = maxBoidSlider.value.ToString();
        }
    }

    public void maxBoidInputChange()
    {
        boidSpawner.GetComponent<BoidSpawner>().maxBoids = int.Parse(maxBoidInput.text);
        
        if(float.Parse(maxBoidInput.text) > maxBoidSlider.maxValue)
        {
            boidsMaxed = true;
            maxBoidSlider.value = maxBoidSlider.maxValue;
        }

        else
        {
            maxBoidSlider.value = float.Parse(maxBoidInput.text);
        }
    }

    public void boidRespawnSliderChange()
    {
        if (boidRespawnMaxed == true)
        {
            boidRespawnMaxed = false;
        }

        else
        {
            boidSpawner.GetComponent<BoidSpawner>().spawnCooldown = Mathf.RoundToInt(boidRespawnSlider.value);
            boidRespawnInput.text = boidRespawnSlider.value.ToString();
        }
    }

    public void boidRespawnInputChange()
    {
        boidSpawner.GetComponent<BoidSpawner>().spawnCooldown = int.Parse(boidRespawnInput.text);

        if (float.Parse(boidRespawnInput.text) > boidRespawnSlider.maxValue)
        {
            boidRespawnMaxed = true;
            boidRespawnSlider.value = boidRespawnSlider.maxValue;
        }

        else
        {
            boidRespawnSlider.value = float.Parse(boidRespawnInput.text);
        }
    }

    public void maxPredSliderChange()
    {
        if (predMaxed == true)
        {
            predMaxed = false;
        }

        else
        {
            predSpawner.GetComponent<PredatorSpawner>().maxPredators = Mathf.RoundToInt(maxPredSlider.value);
            maxPredInput.text = maxPredSlider.value.ToString();
        }
    }

    public void maxPredInputChange()
    {
        predSpawner.GetComponent<PredatorSpawner>().maxPredators = int.Parse(maxPredInput.text);

        if (float.Parse(maxPredInput.text) > maxPredSlider.maxValue)
        {
            predMaxed = true;
            maxPredSlider.value = maxPredSlider.maxValue;
        }

        else
        {
            maxPredSlider.value = float.Parse(maxPredInput.text);
        }
    }

    public void predRespawnSliderChange()
    {
        if (predRespawnMaxed == true)
        {
            predRespawnMaxed = false;
        }

        else
        {
            predSpawner.GetComponent<PredatorSpawner>().spawnCooldown = Mathf.RoundToInt(predRespawnSlider.value);
            predRespawnInput.text = predRespawnSlider.value.ToString();
        }
    }

    public void predRespawnInputChange()
    {
        predSpawner.GetComponent<PredatorSpawner>().spawnCooldown = int.Parse(maxPredInput.text);

        if (float.Parse(predRespawnInput.text) > predRespawnSlider.maxValue)
        {
            predRespawnMaxed = true;
            predRespawnSlider.value = predRespawnSlider.maxValue;
        }

        else
        {
            predRespawnSlider.value = float.Parse(predRespawnInput.text);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            screen.SetActive(!screen.activeInHierarchy);
            paramOpen = !paramOpen;
        }
    }
}
