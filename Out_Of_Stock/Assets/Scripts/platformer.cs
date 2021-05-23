using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformer : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed;
    public Sprite groundSprite;
    public Sprite flyingSprite;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
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
        Physics2D.Raycast(GetComponent<BoxCollider2D>().bounds.center, Vector2.down, rayDistance);
        return true;
    }
}
