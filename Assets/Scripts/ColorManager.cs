using Unity.VisualScripting;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    // basic setting of instances and managers
    public static ColorManager Instance;
    AudioManager audioManager;

    // default settings
    [SerializeField]
    public float tolerance = 0.2f;
    public bool isMatched = false;
    public Color[] colors;
    public int colorIndex = 0;
    public Color targetNpcColor;

    // color and renders
    public Color playerCurrentColor = Color.white;
    private SpriteRenderer playerSprite;
    public bool hasSavedPlayerColor = false;
    // [SerializeField]
    // private SpriteRenderer currentStageNpcSprite;

    public void SavePlayerColor(Color col)
    {
        playerCurrentColor = col;
        hasSavedPlayerColor = true;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void SetTargetColor(Color npcColor)
    {
        targetNpcColor = npcColor;
        // Debug.Log("Target NPC color getted");
    }

    void Start()
    {
        targetNpcColor = colors[colorIndex];

        int currentStage = StageManager.Instance.stage;
        string npcName = "Guard" + currentStage.ToString();;
        // currentStageNpcSprite = GameObject.Find(npcName).GetComponent<SpriteRenderer>();

        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Update()
    {
        if (isMatched) return;

        GameObject player = GameObject.FindWithTag("Player");
        playerSprite=player.GetComponentInChildren<SpriteRenderer>();

        // Debug.Log((Color) playerSprite.color);
        if(IsColorSimilar((Color) playerSprite.color, targetNpcColor, tolerance))
        {
            isMatched = true;
            Debug.Log("color matched");
            // OnMatchSuccess();
        }
    }

    private bool IsColorSimilar(Color a, Color b, float maxDiff)
    {
        return (Mathf.Abs(a.r - b.r) <= maxDiff) &&
               (Mathf.Abs(a.g - b.g) <= maxDiff) &&
               (Mathf.Abs(a.b - b.b) <= maxDiff);
    }

    // private void OnMatchSuccess()
    // {
    //     Debug.Log("color matched");

    //     Collider2D npcCollider = currentStageNpcSprite.GetComponent<Collider2D>();
    //     Debug.Log("deleting" + currentStageNpcSprite);
    //     npcCollider.isTrigger = true;
    // }
}
