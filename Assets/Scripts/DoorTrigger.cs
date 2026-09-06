using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private string[] nextScenes = {"DropletScene", "Stage 1", "Stage 2", "Stage 3",};
    [SerializeField] Animator anim;

    private void Awake()
    {
        Debug.Log("awake");
        GameObject player = GameObject.FindWithTag("Player");

        // playerAnimator = player.GetComponent<Animator>();
        anim = player.GetComponentInChildren<Animator>();
        Debug.Log("received anim");
        // anim = FindFirstObjectByType<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other) {
    // Notice this uses 'Collider' directly instead of 'Collision'
        if (other.CompareTag("Player"))
        {
            int index = 0;
            if (gameObject.name == "DoorBacktoStage") {
                index = StageManager.Instance.stage;
            } else if (gameObject.tag == "nextStage") {
                index = StageManager.Instance.stage + 1;
                ColorManager.Instance.isMatched = false;
                ColorManager.Instance.colorIndex++;
                int colorIndex = Mathf.Min(2, ColorManager.Instance.colorIndex);
                ColorManager.Instance.targetNpcColor = ColorManager.Instance.colors[colorIndex];
                StageManager.Instance.stage++;
            }

Debug.Log("current index" + index);
            anim.SetInteger("Stage", index);
            StageManager.Instance.LoadScene(nextScenes[index]);
        }
    }
    
}
