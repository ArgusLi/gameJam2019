using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class shipTriggerExplosion : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }


   /* void OnTriggerEnter2D()
    {   
        animator.SetBool("isTriggered", true);
        yield return new WaitForSecondsRealtime(1);
        SceneManagement.LoadScene("End");
    }*/
}
