using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
    public static SoundManager Instance { get; private set; }
    public AudioSource efxSource;					//Drag a reference to the audio source which will play the sound effects.
//    public AudioSource musicSource;					//Drag a reference to the audio source which will play the music.
    public float lowPitchRange = .95f;				//The lowest a sound effect will be randomly pitched.
    public float highPitchRange = 1.05f;			//The highest a sound effect will be randomly pitched.

    private void Awake()
    {
        //Singleton stuff
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        DontDestroyOnLoad(gameObject);
    }

    public void PlaySingle(AudioClip clip)
    {
        efxSource.clip = clip;
        var randomPitch = Random.Range(lowPitchRange, highPitchRange);
        efxSource.pitch = randomPitch;
        efxSource.Play();
    }
}
