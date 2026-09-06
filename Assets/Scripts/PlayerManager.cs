using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    [SerializeField] private GameObject[] stagePlayerPrefabs;

    void Awake()
    {
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayerForStage(int stageIndex, Vector3 spawnPosition)
    {
        if(stageIndex<stagePlayerPrefabs.Length)
        {
            GameObject player = Instantiate(stagePlayerPrefabs[stageIndex], spawnPosition, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "droplet") {
            Destroy(collider.gameObject);
        }
    }
}
