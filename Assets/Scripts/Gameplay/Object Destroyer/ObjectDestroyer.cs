using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Object destroyer exists as a tall collider on the left of the camera. When objects pass the player, they are no longer relevant and are deleted
public class ObjectDestroyer : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);
    }
}
