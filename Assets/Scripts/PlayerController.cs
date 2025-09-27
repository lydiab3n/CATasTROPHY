using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    public GameObject player;
    
    private SpriteRenderer spriteRenderer;
    
    public Sprite upSprite;
    public Sprite downSprite;
    public Sprite leftSprite;
    public Sprite rightSprite;
    
    private Vector2 lastMovementDirection = Vector2.down;

    void Start()
    {
        spriteRenderer = player.GetComponent<SpriteRenderer>();
        
        // default facing down sprite
        if (downSprite != null)
            spriteRenderer.sprite = downSprite;
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        Vector3 movement = new Vector3(horizontal, vertical, 0) * moveSpeed * Time.deltaTime;
        transform.position += movement;
        
        updateSpriteDirection(horizontal, vertical);
    }
    
    void updateSpriteDirection(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
            lastMovementDirection = new Vector2(horizontal, vertical);
            
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
}