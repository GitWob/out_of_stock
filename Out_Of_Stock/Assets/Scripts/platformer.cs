using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformer : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Sprite groundSprite;
    public Sprite flyingSprite;
    //public SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (IsGrounded())
        //{
        //    spriteRenderer.sprite = groundSprite;
        //}
        //else
        //{
        //    spriteRenderer.sprite = flyingSprite;
        //}
        Move();
    }

    void Move()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float moveBy = x * speed;
        if (Mathf.Abs(rb.velocity.x) < 4)
        {
            rb.velocity += new Vector2(moveBy, 0);
        }
    }

    bool IsGrounded()
    {
        float rayDistance = GetComponent<BoxCollider2D>().bounds.extents.y + 0.1f;
        RaycastHit2D rayHit = Physics2D.Raycast(GetComponent<BoxCollider2D>().bounds.center, Vector2.down, rayDistance);
        if (rayHit.collider == null)
        {
            return false;
        }
        return true;
    }
}
