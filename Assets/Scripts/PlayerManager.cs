using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    private SpriteRenderer playerSpriteRenderer;
    public float spawnX;
    public float spawnY;

    public float lerpFactor;
    void Awake()
    {
        transform.position = new Vector3(spawnX, spawnY, 0f);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpriteRenderer = this.GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D collider) {

        SpriteRenderer targetSprite = collider.GetComponent<SpriteRenderer>();


        if (collider.gameObject.tag == "droplet") {

            if(targetSprite!=null)
            {
                //playerSpriteRenderer.color = targetSprite.color;//change into doplet color

                SpriteRenderer target = collider.GetComponent<SpriteRenderer>();

                if(target !=null && playerSpriteRenderer != null)
                {
                    playerSpriteRenderer.color = Color.Lerp(playerSpriteRenderer.color, target.color, lerpFactor);
                }


            }
            Destroy(collider.gameObject);//doplet delete
        }

    }
    
}
