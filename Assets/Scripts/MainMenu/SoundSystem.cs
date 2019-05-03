using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSystem : MonoBehaviour {

    private bool soundeffects;
    private AudioSource music;

	// Use this for initialization
	void Start () {
        soundeffects = true;
        music = GetComponent<AudioSource>();
	}
	
	public bool getSoundEffects()
    {
        return soundeffects;
    }

    public void toggleSoundEffects()
    {
        soundeffects = !soundeffects;

        //Object searching code courtesy of user jonc113 in Unity Forums (modified). Link: https://answers.unity.com/questions/329395/how-to-get-all-gameobjects-in-scene.html
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (obj.activeInHierarchy && obj.GetComponent<AudioSource>() != null && obj.name != "SoundSystem")
            {
                obj.GetComponent<AudioSource>().mute = soundeffects;
            }
        }
    }

    public void toggleMusic()
    {
        music.mute = !music.mute;
    }
}
