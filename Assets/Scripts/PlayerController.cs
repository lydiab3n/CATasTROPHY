using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public GameObject player;

    private SpriteRenderer spriteRenderer;
    public Vector2 lastPosition;

    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;

    // VOICE CONTROL
    [HideInInspector] public Vector2 voiceMovement = Vector2.zero;

    // DIRECTION OF PLAYER
    [HideInInspector] public Vector2 facingDirection = Vector2.down;

    void Start()
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>();

        // default facing down sprite
        if (downSprite != null)
            spriteRenderer.sprite = downSprite;
        facingDirection = Vector2.down;
    }

    void Update()
    {
        // switching between voice & keyboard
        float horizontal;
        float vertical;

        if (voiceMovement != Vector2.zero)
        {
            horizontal = voiceMovement.x;
            vertical = voiceMovement.y;
        }
        else
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");
        }

        Vector3 movement = new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
        transform.position += movement;
        lastPosition = this.transform.position;

        updateSpriteDirection(horizontal, vertical);
        // voiceMovement = Vector2.zero; //reset

        if (horizontal != 0 || vertical != 0)
        {
            facingDirection = new Vector2(horizontal, vertical).normalized;
        }
    }

    void updateSpriteDirection(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                if (horizontal > 0)
                {
                    if (rightSprite != null)
                        spriteRenderer.sprite = rightSprite;
                }
                else
                {
                    if (leftSprite != null)
                        spriteRenderer.sprite = leftSprite;
                }
            }
            else
            {
                if (vertical > 0)
                {
                    if (upSprite != null)
                        spriteRenderer.sprite = upSprite;
                }
                else
                {
                    if (downSprite != null)
                        spriteRenderer.sprite = downSprite;
                }
            }
        }
    }

    public void respawnAtCheckpoint()
    {
        transform.position = lastPosition;
        //maybe reset animations etc
    }
}
