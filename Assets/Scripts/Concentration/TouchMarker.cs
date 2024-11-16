using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMarker : MonoBehaviour
{
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    public void PlayAnimation()
    {
        animator.SetTrigger("Play");
        
    }
}
