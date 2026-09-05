using UnityEngine;

public class Mover : MonoBehaviour
{
    [Header("Settings")]
    public float movementSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.down * movementSpeed * Time.deltaTime;
    }
}
