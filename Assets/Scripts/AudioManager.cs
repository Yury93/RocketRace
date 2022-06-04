using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource backAudioSource;
    [SerializeField] private List<AudioClip> menuSounds, lvlGameSounds;

    private void Start()
    {
        int rnd;
        if (menuSounds.Count > 0)
        {
            rnd = Random.Range(0, menuSounds.Count);
            backAudioSource.clip = menuSounds[rnd];
        }
        else
        {
            rnd = Random.Range(0, lvlGameSounds.Count);
            backAudioSource.clip = lvlGameSounds[rnd];
        }
        backAudioSource.Play();
    }
}
