using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningObject : MonoBehaviour {

    private Animator childAnimator;
    private AudioSource audiosource;

    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        childAnimator = GetComponentInChildren<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audiosource.Play();
            childAnimator.SetBool("hit", true);
        }
    }
}
