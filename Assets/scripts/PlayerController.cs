using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Canvas playerinfo= null;
    [SerializeField]
    private Animator animator = null;
    [SerializeField]
    private GroundCheck groundCheck = null;
    private float moveSpeed = 5.0f;
    [SerializeField]
    private float jumpSpeed = 10.0f;
    [SerializeField]
    private Rigidbody2D rigidbody = null;
    private float desiredSpeed = 0.0f;
    private float direction = 1.0f;
    private bool isJumping = false;
    private bool isFalling = false;
    private Vector3 lastSafePosition = Vector3.zero;
    //Player input hookups
    private PlayerInputs playerInput = null;
    private InputAction moveAction = null;
    private InputAction jumpAction = null;
    private void Awake()
    {
        playerInput = new PlayerInputs();
        moveAction = playerInput.Player.Move;
        jumpAction = playerInput.Player.Jump;
        jumpAction.performed += OnJump;
        lastSafePosition = transform.position;
        animator.SetFloat("Direction", direction);
        animator.SetFloat("speed", 0.0f);
        playerinfo.worldCamera = Camera.main;

    }
    private void OnEnable()
    {
        moveAction.Enable();
        jumpAction.Enable();

    }
    private void OnDisable()
    {
        moveAction.Disable();
        jumpAction.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        desiredSpeed = moveAction.ReadValue<Vector2>().x * moveSpeed;
        if(groundCheck.IsGrounded())
        {
            lastSafePosition = transform.position;
            if(rigidbody.linearVelocityY < 0.1f)
            {
                isFalling = false;
            }
        }
        else if(rigidbody.linearVelocityY < 0.0f)
        {
            isFalling = true;
            isJumping = false;
        }
        if (desiredSpeed < 0.0f)
        {
            direction = -1.0f;
        }
        else if (desiredSpeed > 0.0f)
        {
            direction = 1.0f;
        }
        float currentSpeed = rigidbody.linearVelocityX;
        animator.SetFloat("Direction", direction);
        animator.SetFloat("Speed", Mathf.Abs(currentSpeed));
        animator.SetBool("IsJumping", isJumping);
        animator.SetBool("IsFalling", isFalling);

    }
    private void FixedUpdate()
    {
        rigidbody.linearVelocityX = desiredSpeed;
    }
    private void OnJump(InputAction.CallbackContext context)
    {
        if(groundCheck.IsGrounded() && rigidbody.linearVelocityY < 0.1f)
        {
            rigidbody.linearVelocityY = jumpSpeed;
            isJumping = true;
        }
    }
    public void RespawnPlayer()
    {
        Vector3 spawnPosition;
        if(!CheckPointManager.Instance.TryGetLastCheckpointPosition(out spawnPosition))
        {
            spawnPosition= lastSafePosition;
        }
        transform.position = lastSafePosition;
        rigidbody.linearVelocity = Vector2.zero;
    }
}