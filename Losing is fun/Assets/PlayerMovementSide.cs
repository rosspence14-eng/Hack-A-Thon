using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;

    [Header("Sprite Facing")]
    [SerializeField] private Sprite leftSprite;
    [SerializeField] private Sprite rightSprite;
    [SerializeField] private Sprite awaySprite;

    [Header("Photo System")]
    [SerializeField] private PhotoManager photoManager;

    private PlayerControls controls;
    private Vector2 moveInput;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        controls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        controls.Player.Enable();

        controls.Player.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        controls.Player.Move.canceled += ctx => moveInput = Vector2.zero;

        controls.Player.Interaction.performed += ctx => photoManager.TakePhoto();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }

    private void FixedUpdate()
    {
        Vector2 movement = new Vector2(moveInput.x, 0f);
        rb.linearVelocity = movement * moveSpeed;

        UpdateFacingDirection(movement.x);
    }

    private void UpdateFacingDirection(float horizontal)
    {
        if (horizontal > 0.01f)
            spriteRenderer.sprite = rightSprite;
        else if (horizontal < -0.01f)
            spriteRenderer.sprite = leftSprite;
        else
            spriteRenderer.sprite = awaySprite;
    }
}