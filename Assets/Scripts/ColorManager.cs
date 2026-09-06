using Unity.VisualScripting;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;

    public bool IsMatched = false;

    public Color32[] colors;
    public Color32 targetNpcColor;

    public Color32 playerCurrentColor = Color.white;
    public bool hasSavedPlayerColor = false;

    public void SavePlayerColor(Color32 col)
    {
        playerCurrentColor = col;
        hasSavedPlayerColor = true;
    }

    private void Awake()
    {
        targetNpcColor = colors[StageManager.Instance.stage - 1];
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

    public void SetTargetColor(Color32 npcColor)
    {
        targetNpcColor = npcColor;
        Debug.Log("Target NPC color getted");
    }
    [SerializeField]
    private SpriteRenderer currentStageNpcSprite;

    //색 오차 허용 범위
    [SerializeField]
    private byte tolerance = 30;

    private SpriteRenderer playerSprite;
    private bool isMatched = false;

    void Start()
    {
    }

    void Update()
    {
        // 이미 성공했거나, NPC가 인스펙터에 안 들었으면 실행 안 함
        if (isMatched) return;

        //find spawned player
        if(playerSprite==null)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if(player!=null)
            {
                playerSprite=player.GetComponentInChildren<SpriteRenderer>();
            }
            return; //플레이어 찾을 때 까지 대기
        }

        if(IsColorSimilar(playerSprite.color, targetNpcColor, tolerance))
        {
            isMatched = true;
            OnMatchSuccess();
        }
    }

    private bool IsColorSimilar(Color32 a, Color32 b, byte maxDiff)
    {
        return (Mathf.Abs(a.r - b.r) <= maxDiff) &&
               (Mathf.Abs(a.g - b.g) <= maxDiff) &&
               (Mathf.Abs(a.b - b.b) <= maxDiff);
    }

    private void OnMatchSuccess()
    {
        IsMatched = true;
        Debug.Log("color matched");

        Collider2D npcCollider = currentStageNpcSprite.GetComponent<Collider2D>();
        if(npcCollider!=null)
        {
            npcCollider.isTrigger = true;
        }



    }
}
