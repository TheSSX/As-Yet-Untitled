using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Responsible for changing the skin of the launcher stand
public class StandChanger : MonoBehaviour {

	private Transform launchersize;

    [SerializeField]
    private Sprite[] sprites;       //stores the range of possible launcher stand sprites in an array of sprites
    private SpriteRenderer standRenderer;

    // Use this for initialization
    void Start () {
        standRenderer = GetComponent<SpriteRenderer>();
		launchersize = GetComponent<Transform>();
		launchersize.localScale = new Vector3(2f, 2f, 2f);
	}
	
    //Receives the string of the launcher and changes the sprite, size and position of the launcher appropriately
	public void changeSprite(string x)
    {
        if (x == "basic")
        {
            standRenderer.sprite = sprites[0];  //basic cannon
        }
        else if (x == "gold")
        {
            standRenderer.sprite = sprites[1];      //gold cannon
			launchersize.localScale = new Vector3(1.5f, 1.5f, 1.5f);
			transform.position = new Vector2 (transform.position.x, transform.position.y + 1);
        }
        else if (x == "tank")
        {
            standRenderer.sprite = sprites[2];      //tank
            launchersize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }
        else if (x == "SAM turret")
        {
            standRenderer.sprite = sprites[3];      //SAM turret
            launchersize.localScale = new Vector3(1.2f, 1.2f, 1.2f);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }
        else if (x == "missile launcher")
        {
            standRenderer.sprite = sprites[4];      //missile launcher
            launchersize.localScale = new Vector3(2, 2, 2);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }

        else if (x == "diamond")
        {
            standRenderer.sprite = sprites[5];      //diamond cannon
            launchersize.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            transform.position = new Vector2(transform.position.x, transform.position.y + 1);
        }
    }
}
