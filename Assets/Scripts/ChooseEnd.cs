using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseEnd : MonoBehaviour
{
    public int EndNum;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(this.gameObject.GetComponent<SceneM>().check == 1)
        {
            PlayerPrefs.SetInt("ending", EndNum);
        }
    }
}
