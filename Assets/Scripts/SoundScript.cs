using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] sfxWalk;


    private AudioSource[] audioSources;
    void Start()
    {
        audioSources = GetComponents<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void playSFXWalk()
    {
        int seed = Random.Range(0, sfxWalk.Length);
        audioSources[0].PlayOneShot(sfxWalk[seed], 1);
    }
}
