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

    AudioManager audioManager;
    [SerializeField] private float stepInterval = 0.4f; // Time in seconds between footsteps
    private float stepTimer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
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
        if(moveInputX>0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(moveInputX<0)
        {
            transform.localScale= new Vector3(-1, 1, 1);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("playerSpeed", Mathf.Abs(rb.linearVelocityX));
        // Handle continuous footstep sound playback
        HandleFootsteps();
    }


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
