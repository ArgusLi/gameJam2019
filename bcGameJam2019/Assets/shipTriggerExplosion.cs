using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shipTriggerExplosion : MonoBehaviour
{
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("isTriggered", true);
    }
}
