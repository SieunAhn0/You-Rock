using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private string DropletScene;

    private void OnTriggerEnter2D(Collider2D other) {
    // Notice this uses 'Collider' directly instead of 'Collision'
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.LoadScene(DropletScene);
        }
    }
    
}
