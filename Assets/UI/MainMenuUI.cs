using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public GameObject mainCanvas;
    public GameObject panel1;
    public GameObject panel2;
    public GameObject tutorial1;
    public GameObject tutorial2;
    public GameObject continueText;

    private bool clickToStart = false;

    private void Start()
    {
        panel2.SetActive(true);
        mainCanvas.GetComponent<CanvasGroup>().alpha = 1;
        tutorial1.GetComponent<CanvasGroup>().alpha = 0;
        tutorial2.GetComponent<CanvasGroup>().alpha = 0;
        continueText.GetComponent<CanvasGroup>().alpha = 0;
        panel2.SetActive(false);
        panel1.SetActive(true);
    }

    public void playButton()
    {
        clickToStart = true;
        StartCoroutine(secondScreen());
    }

    public void blogButton()
    {
        Application.OpenURL("https://muirhead.design/category/university/des311/");
    }

    public void inspirationButton()
    {
        Application.OpenURL("https://www.youtube.com/watch?v=6zOarcL1BSc");
    }

    public void quitButton()
    {
        Application.Quit();
    }

    IEnumerator secondScreen()
    {
        CanvasGroup menuGroup = panel1.GetComponent<CanvasGroup>();
        CanvasGroup tut1 = tutorial1.GetComponent<CanvasGroup>();
        CanvasGroup tut2 = tutorial2.GetComponent<CanvasGroup>();
        CanvasGroup contText = continueText.GetComponent<CanvasGroup>();

        //fade out menu
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            menuGroup.alpha = i;
            yield return null;
        }

        //remove menu options
        panel1.SetActive(false);
        panel2.SetActive(true);

        //bring in tutorial elements

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            tut1.alpha = i;
            yield return null;
        }

        yield return new WaitForSeconds(1);

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            tut2.alpha = i;
            yield return null;
        }

        yield return new WaitForSeconds(1);

        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            contText.alpha = i;
            yield return null;
        }
    }

    IEnumerator totalFadeOut()
    {
        CanvasGroup mainGroup = mainCanvas.GetComponent<CanvasGroup>();

        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            mainGroup.alpha = i;
            yield return null;
        }

        SceneManager.LoadScene(1);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && clickToStart == true)
        {
            StartCoroutine(totalFadeOut());
        }
    }
}
