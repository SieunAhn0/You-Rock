using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private string[] nextScenes = {"DropletScene", "Stage 1", "Stage 2", "Stage 3",};

    private void OnTriggerEnter2D(Collider2D other) {
    // Notice this uses 'Collider' directly instead of 'Collision'
        if (other.CompareTag("Player"))
        {
            int index = 0;
            if (gameObject.name == "DoorBacktoStage") {
                index = StageManager.Instance.stage;
            } else if (gameObject.tag == "nextStage") {
                index = StageManager.Instance.stage + 1;
                StageManager.Instance.stage++;
            }

            StageManager.Instance.LoadScene(nextScenes[index]);
        }
    }
    
}
