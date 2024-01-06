using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckFinalCode : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject SlowMoTimer;
    string[] numss = new string[4];

    void Start()
    {
    }

    // Update is called once per frame
    public void RunCheck()
    {
        numss = SlowMoTimer.GetComponent<SlowMotionTimer>().nums;
        if (numss[0] == "8" && numss[1] == "9" && numss[2] == "1" && numss[3] == "2" && SlowMoTimer.GetComponent<SlowMotionTimer>().complete == 1 && SlowMoTimer.GetComponent<SlowMotionTimer>().vict == 0)
        {
            this.gameObject.GetComponent<SceneM>().EnterStage00();
            SlowMoTimer.GetComponent<SlowMotionTimer>().vict = 1;
        }
    }
}
