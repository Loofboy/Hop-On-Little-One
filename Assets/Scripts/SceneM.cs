using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{
    public string SceneName;
    public Animator transition;
    public float transitionTime = 1.1f;
    public int check = 0;


    public void EnterStage00()
    {
        //SceneName = "Stage00";
        StartCoroutine(LoadStage(SceneName));
    }

    public void QuitGame()
    {
        StartCoroutine(Quitg());

    }

    public void EnterMenu()
    {
        SceneName = "MainMenu";
        StartCoroutine(LoadStage(SceneName));
    }

    IEnumerator LoadStage(string Scenee)
    {
        check = 1;

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(Scenee);
    }

    IEnumerator Quitg()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        Application.Quit();
    }
}
