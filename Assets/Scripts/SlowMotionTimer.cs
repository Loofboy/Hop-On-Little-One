using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class SlowMotionTimer : MonoBehaviour
{
    public GameObject SMUI;
    public GameObject Slider;
    public GameObject N1;
    public GameObject N2;
    public GameObject N3;
    public GameObject N4;
    public GameObject Player;

    SceneM scM;
    public AudioSource src;
    public AudioClip victory;

    TextMeshProUGUI Num1;
    TextMeshProUGUI Num2;
    TextMeshProUGUI Num3;
    TextMeshProUGUI Num4;

    public string[] nums = new string[4];
    public string[] reqnums;
    int arrayPointer = 0;
    public float durationTime;
    private float startingTime;
    public int complete = 0;
    public int othercomplete = 0;
    public int vict = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "StageRandom")
        {
            for (int i = 0; i < 4; i++)
                reqnums[i] = GameObject.Find("RandNumyGen").GetComponent<RandNumGen>().gennednums[i];
        }

        for (int i = 0; i < 4; i++) nums[i] = null;
        Num1 = N1.GetComponent<TextMeshProUGUI>();
        Num2 = N2.GetComponent<TextMeshProUGUI>();
        Num3 = N3.GetComponent<TextMeshProUGUI>();
        Num4 = N4.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            if(Input.GetKeyDown("" + i) && nums[3] == null && Player.GetComponent<PauseMenu>().disableInput == false)
            {
                string x = i.ToString();
                nums[arrayPointer] = x;
                arrayPointer++;
            }
        }
        if(Num1.text == "" && nums[0] != null)
        {
            Num1.text = nums[0];
            N1.SetActive(true);
        }
        if (Num2.text == "" && nums[1] != null)
        {
            Num2.text = nums[1];
            N2.SetActive(true);
        }
        if (Num3.text == "" && nums[2] != null)
        {
            Num3.text = nums[2];
            N3.SetActive(true);
        }
        if (Num4.text == "" && nums[3] != null)
        {
            Num4.text = nums[3];
            N4.SetActive(true);
            complete = 1;
        }
        durationTime = Slider.GetComponent<Slider>().maxValue;
        startingTime += Time.deltaTime;
        durationTime = durationTime - startingTime;
        Slider.GetComponent<Slider>().value = durationTime;

        if (nums[0] == reqnums[0] && nums[1] == reqnums[1] && nums[2] == reqnums[2] && nums[3] == reqnums[3] && vict == 0 && complete == 1)
        {
            // src.PlayOneShot(victory, .5f);
            vict = 1;
            if (SceneManager.GetActiveScene().name == "Stage04" && GameObject.Find("MusicPlayer").GetComponent<Composer>().songposb < 168)
            {
                scM = GameObject.Find("SceneManager 2").GetComponent<SceneM>();
                Slider.GetComponent<Slider>().value = 0;
                scM.EnterStage00();
            }
            else
            {
                scM = GameObject.Find("SceneManager 1").GetComponent<SceneM>();
                Slider.GetComponent<Slider>().value = 0;
                scM.EnterStage00();
            }
        }
        else if (nums[0] == "8" && nums[1] == "9" && nums[2] == "1" && nums[3] == "2" && SceneManager.GetActiveScene().name == "Stage00" && vict == 0 && complete == 1) {
            GameObject.Find("FinalCodeChecker").GetComponent<CheckFinalCode>().RunCheck();
            Slider.GetComponent<Slider>().value = 0;
        }
        else if (vict == 0 && complete == 1)
        {
            Slider.GetComponent<Slider>().value = 0;
        }

        if (Slider.GetComponent<Slider>().value <= 0)
        {
            startingTime = 0;
            N1.SetActive(false);
            SMUI.SetActive(false);
            arrayPointer = 0;
            // nums = null;
            for (int i = 0; i < 4; i++) nums[i] = null;
            N1.SetActive(false);
            N2.SetActive(false);
            N3.SetActive(false);
            N4.SetActive(false);
            Num1.text = "";
            Num2.text = "";
            Num3.text = "";
            Num4.text = "";
            complete = 0;
        }
        else SMUI.SetActive(true);
    }
}
