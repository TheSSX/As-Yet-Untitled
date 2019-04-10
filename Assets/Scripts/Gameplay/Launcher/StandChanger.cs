using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandChanger : MonoBehaviour {

	public Transform launchersize;

    [SerializeField]
    private Sprite[] sprites;
    private SpriteRenderer standRenderer;

    // Use this for initialization
    void Start () {
        standRenderer = GetComponent<SpriteRenderer>();
		launchersize = GetComponent<Transform>();
		launchersize.localScale = new Vector3(2f, 2f, 2f);
	}
	
	public void changeSprite(string x)
    {
        if (x == "basic")
        {
            standRenderer.sprite = sprites[0];
        }
        else if (x == "gold")
        {
            standRenderer.sprite = sprites[1];
			launchersize.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			transform.position = new Vector2 (transform.position.x, transform.position.y + 1);
        }
    }
}
