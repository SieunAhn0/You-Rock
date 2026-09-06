using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Tracks")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("SFX")]
    public AudioClip[] tracks;
    public AudioClip walk;
    public AudioClip drop1;
    public AudioClip drop2;
    public AudioClip drop3;
    
     void Start() {
        musicSource.clip = tracks[0];
        musicSource.Play();
    }
}
