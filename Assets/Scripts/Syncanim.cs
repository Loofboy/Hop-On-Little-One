using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syncanim : MonoBehaviour
{
    public Animator animator;
    public AnimatorStateInfo animatorStateInfo;
    public int currentState;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        currentState = animatorStateInfo.fullPathHash;
    }

    // Update is called once per frame
    void Update()
    {
        animator.Play(currentState, -1, (Composer.instance.loopPositionInAnalog));
        animator.speed = 0;
    }
}
