using UnityEngine;

public class PlayerCollision_temp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "droplet") {
            Destroy(collider.gameObject);
        }
    }
}
