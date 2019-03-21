using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hazard : MonoBehaviour {

    [SerializeField]
    protected PolygonCollider2D collider;
    [SerializeField]
    protected AudioSource audiosource;
    [SerializeField]
    protected Animator animation;

    // Use this for initialization
    void Start () {
        audiosource.loop = false;
	}

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            audiosource.Play();
            animation.SetBool("hit", true);
        }
    }
}
