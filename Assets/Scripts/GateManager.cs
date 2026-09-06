using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class GateManager : MonoBehaviour
{

    [Header("플레이어 프리팹")]
    [SerializeField] private GameObject playerPrefab;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
        if(playerPrefab!=null)
        {
            Instantiate(playerPrefab);
        }
        else
        {
            Debug.LogError("Player Prefab didn't assaing");
        }
        
    }
    
}
