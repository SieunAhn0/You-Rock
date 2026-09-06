using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    private SpriteRenderer playerSpriteRenderer;
    public float spawnX;


    void Awake()
    {
        // if(Instance==null)
        // {
        //     Instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }
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
                    playerSpriteRenderer.color = Color.Lerp(playerSpriteRenderer.color, target.color, 0.2f);
                }


            }
            Destroy(collider.gameObject);//doplet delete
        }

    }
    
}
