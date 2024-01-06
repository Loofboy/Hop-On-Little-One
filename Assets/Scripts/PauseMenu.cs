using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseUI;
    public GameObject OptionsUI;

    public Button Contbutton;

    float prevtimescale;
    public bool disableInput = false;

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && disableInput == false)
        {
            PauseUI.SetActive(true);
            OptionsUI.SetActive(true);
            prevtimescale = Time.timeScale;
            Time.timeScale = 0;
            disableInput = true;
            Contbutton.Select();
        }
    }

    public void UnPause()
    {
        PauseUI.SetActive(false);
        OptionsUI.SetActive(false);
        Time.timeScale = prevtimescale;
        disableInput = false;
    }

    public void EnterOptions()
    {
        PauseUI.GetComponent<CanvasGroup>().alpha = 0;
        PauseUI.GetComponent<CanvasGroup>().interactable = false;
        OptionsUI.GetComponent<CanvasGroup>().alpha = 1;
        OptionsUI.GetComponent<CanvasGroup>().interactable = true;
    }

    public void ExitOptions()
    {
        PauseUI.GetComponent<CanvasGroup>().alpha = 1;
        PauseUI.GetComponent<CanvasGroup>().interactable = true;
        OptionsUI.GetComponent<CanvasGroup>().alpha = 0;
        OptionsUI.GetComponent<CanvasGroup>().interactable = false;
    }
}
