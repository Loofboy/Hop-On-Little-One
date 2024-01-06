using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exitplatform : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    public float timer;
    int x = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(leavemaptrig());
    }

    // Update is called once per frame
    IEnumerator leavemaptrig()
    {
        yield return new WaitForSeconds(timer);
        x = 1;
    }

    void FixedUpdate()
    {
        if(x == 1) transform.position += (velocity * Time.deltaTime);
    }
}
