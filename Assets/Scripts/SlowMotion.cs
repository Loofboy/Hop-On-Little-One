using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMotion : MonoBehaviour
{
    public float SlowMotionTime;
    public float timeFrame;
    public GameObject Slider;
    public GameObject SlowMoTimer;
    public GameObject GameOverUI;

    private float NormalTime;
    private float NormalFixedTime;
    // Start is called before the first frame update
    void Start()
    {
        NormalTime = Time.timeScale;
        NormalFixedTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Time.timeScale != SlowMotionTime && SlowMoTimer.GetComponent<SlowMotionTimer>().vict == 0 && this.gameObject.GetComponent<PauseMenu>().disableInput == false)
        {
            StartSlowMo();
        }
        if (Slider.GetComponent<Slider>().value <= 0)
        {
            StopSlowMo();
        }
    }
  

    private void StartSlowMo()
    {
        Time.timeScale = SlowMotionTime;
        Time.fixedDeltaTime = NormalFixedTime * SlowMotionTime;
        SlowMoTimer.SetActive(true);
    }

    public void StopSlowMo()
    {
        Time.timeScale = NormalTime;
        Time.fixedDeltaTime = NormalFixedTime;
        SlowMoTimer.SetActive(false);
        Slider.GetComponent<Slider>().value = Slider.GetComponent<Slider>().maxValue;
    }
}
