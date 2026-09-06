using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour {
    public static StageManager Instance;
    public int stage = 1;

    private void Awake() {
        Debug.Log("Current stage is: " + stage);
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName) {
        SceneManager.LoadScene(sceneName);

        if (AudioManager.Instance != null) {
            if (sceneName == "DropletScene") {
                AudioManager.Instance.UpdateDropletMusic();
            } else {
                AudioManager.Instance.UpdateStageMusic();
            }
        }
    }
}