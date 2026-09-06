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

    public float masterSoundVolume = 1;
    
    private void Awake() {
        musicSource.clip = tracks[0];
        musicSource.volume = masterSoundVolume * 0.7f;
        musicSource.loop = true;
        musicSource.Play();
    }

    public void PlaySFX(float vol, AudioClip clip) {
        SFXSource.volume = masterSoundVolume * vol;
        SFXSource.PlayOneShot(clip);
    }
}

// AudioManager audioManager;
// audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
// audioManager.PlaySFX(audioManager.);
