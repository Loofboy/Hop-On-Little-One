using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MUIController : MonoBehaviour
{
    public TextMeshProUGUI LText;
    public TextMeshProUGUI SText;
    public TextMeshProUGUI TText;
    public GameObject LossUI;
    public GameObject SceneM;
    int points;
    int time;
    float timenow;

    // Start is called before the first frame update
    void Start()
    {
        points = GameObject.Find("Player").GetComponent<FreeMovement>().points;
        LText.text = "0/15";
        SText.text = "Score\n0000";
    }

    // Update is called once per frame
    public void Updatepoints()
    {
        points = GameObject.Find("Player").GetComponent<FreeMovement>().points;
        LText.text = points + "/15";
        SText.text = "Score\n" + points * 1000;
        if (points == 15) SceneM.GetComponent<SceneM>().EnterStage00();
    }

    private void Update()
    {
        timenow += Time.deltaTime;
        time = 60 - (int)(timenow);
        if (time > -1)
           TText.text = "Time\n" + time;
        else
        {
            LossUI.SetActive(true);
            LossUI.GetComponent<GameOverScript>().GameOverActive = 1;
            GameObject.Find("Player").GetComponent<PauseMenu>().disableInput = true;
        }
    }
}
