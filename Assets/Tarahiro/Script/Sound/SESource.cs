using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SESource : MonoBehaviour {

    AudioSource audioSource;
    public bool loop
    {
        get
        {
            return audioSource.loop;
        }

        set
        {
            audioSource.loop = value;
        }
    }

    public AudioClip clip
    {
        get
        {
            return audioSource.clip;
        }

        set
        {
            audioSource.clip = value;
        }
    }

    public void Play()
    {
        audioSource.Play();
    }

    // Use this for initialization
    void Awake () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
        if (!audioSource.isPlaying)
        {
            Destroy(gameObject);
        }
	}
}
