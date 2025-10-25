using UnityEngine;
using UnityEngine.InputSystem; // <-- New Input System namespace

public class PlayerDirection : MonoBehaviour
{
    public Sprite frontSprite;
    public Sprite backSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    private SpriteRenderer spriteRenderer;
    private PlayerControls controls;
    private Vector2 moveInput;

    void Awake()
    {
        controls = new PlayerControls();
    }

    void OnEnable()
{
    if (controls == null)
    {
        controls = new PlayerControls();
    }
    controls.Enable();
}


    void OnDisable()
{
    if (controls != null)
    {
        controls.Disable();
    }
}


    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();

        if (moveInput.x > 0)
            spriteRenderer.sprite = rightSprite;
        else if (moveInput.x < 0)
            spriteRenderer.sprite = leftSprite;
        else if (moveInput.y > 0)
            spriteRenderer.sprite = backSprite;
        else if (moveInput.y < 0)
            spriteRenderer.sprite = frontSprite;
    }
}
