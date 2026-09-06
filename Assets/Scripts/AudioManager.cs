using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

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
    
    private void Awake()
    {
        // Keep the first AudioManager alive and destroy duplicates in new scenes
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
        // Debug.Log("first audio update to music");
        UpdateMusic();
    }

    // Called automatically every time a new scene loads
    private void OnSceneLoaded()
    {
        // Debug.Log("update audio after scene load");
        UpdateMusic();
    }

    // update the music to match the current stage
    public void UpdateMusic() {
        int index = StageManager.Instance.stage - 1;
        // Debug.Log("Current Audio index is: " + index);

        AudioClip nextClip = tracks[index];

        // Only assign and play if the clip is different or not currently playing
        if (musicSource.clip != nextClip)
        {
            musicSource.clip = nextClip;
            musicSource.volume = masterSoundVolume * 0.7f;
            musicSource.loop = true;
            musicSource.Stop();
            musicSource.Play();
        } 
        else if (!musicSource.isPlaying)
        {
            musicSource.Play();
        }
    }

    public void PlaySFX(float vol, AudioClip clip) {
        SFXSource.volume = masterSoundVolume * vol;
        SFXSource.PlayOneShot(clip);
    }
}

// AudioManager audioManager;
// audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
// audioManager.PlaySFX(audioManager.);
