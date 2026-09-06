using Unity.VisualScripting;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance { get; private set; }

    public bool IsMatched { get; private set; } = false;

    public Color targetNpcColor = Color.white;

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
        Debug.Log("Target NPC color getted");
    }

    private SpriteRenderer currentStageNpcSprite;

    //색 오차 허용 범위
    [SerializeField]
    private float tolerance = 0.15f;

    private SpriteRenderer playerSprite;
    private bool isMatched = false;


    void Start()
    {
        
    }


    

    // Update is called once per frame
    void Update()
    {
        // 이미 성공했거나, NPC가 인스펙터에 안 들었으면 실행 안 함
        if (isMatched || currentStageNpcSprite == null) return;

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

    private bool IsColorSimilar(Color a, Color b, float maxDiff)
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
