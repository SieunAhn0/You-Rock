using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 6f;

    private Rigidbody2D rb;
    private float moveInputX;

    public Animator anim;
    private SpriteRenderer spriteRenderer;

    public bool clearTrigger = false;   //for guard

    AudioManager audioManager;
    [SerializeField] private float stepInterval = 0.4f; // Time in seconds between footsteps
    private float stepTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        // anim.SetInteger("Stage", StageManager.Instance.stage);

        switch (StageManager.Instance.stage) {
            case 1 :
                anim.Play("playerAnim0");
                break;
            case 2 :
                anim.Play("playerAnim1");
                break;
            case 3 :
                anim.Play("playerAnim2");
                break;
        }
    }

    // New Input System 콜백 (Player Input 컴포넌트의 Send Messages로 연결)
    public void OnMove(InputValue value)
    {
        // 입력받은 Vector2 값 중 X축(좌우 -1 ~ 1) 값만 가져옴
        moveInputX = value.Get<Vector2>().x;
    }

    private void FixedUpdate()
    {
        // Y축 속도는 기존 중력/점프 상태를 유지하고, X축 속도만 변경
        rb.linearVelocity = new Vector2(moveInputX * moveSpeed, rb.linearVelocity.y);
        if(moveInputX > 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(moveInputX<0)
        {
            spriteRenderer.flipX = true;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

        if (ColorManager.Instance != null && ColorManager.Instance.hasSavedPlayerColor)
        {
            spriteRenderer.color = ColorManager.Instance.playerCurrentColor;
        }
    }

    private void OnDestroy()
    {
        if (ColorManager.Instance != null && spriteRenderer != null)
        {
            ColorManager.Instance.SavePlayerColor((Color32) spriteRenderer.color);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.linearVelocityX);
        anim.SetFloat("playerSpeed", Mathf.Abs(rb.linearVelocityX));
        // Handle continuous footstep sound playback
        HandleFootsteps();

    }

    // collision detection with guard
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Guard"))
        {
            if (ColorManager.Instance.isMatched == true) //stage unlocked
            {
                audioManager.PlaySFX(audioManager.win);
                collision.collider.isTrigger = true;//make the guard collider isTrigger on
            }
            else
            {
                Debug.Log("stage not unlocked"+spriteRenderer.color+"\n"
                    +ColorManager.Instance.targetNpcColor
                    );
                audioManager.PlaySFX(audioManager.lose);
            }

        }
    }

    // Manages walking sfx for player
    private void HandleFootsteps()
    {
        // Play footsteps only when moving horizontally
        if (Mathf.Abs(moveInputX) > 0.1f)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0f)
            {
                if (audioManager != null)
                {
                    audioManager.PlaySFX(0.8f, audioManager.walk);
                }
                stepTimer = stepInterval; // Reset timer
            }
        }
        else
        {
            // Reset timer so the sound plays immediately upon moving again
            stepTimer = 0f; 
        }
    }
}
