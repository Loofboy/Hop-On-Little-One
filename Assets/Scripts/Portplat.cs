using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portplat : MonoBehaviour
{
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collider)  
    {
        collider.gameObject.transform.position = target.transform.position;
    }
}
