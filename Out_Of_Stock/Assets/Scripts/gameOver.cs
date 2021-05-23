using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOver : MonoBehaviour
{
    public GameObject player;
    private BoxCollider2D playerCollider;
    private BoxCollider2D soupCollider;

    // Start is called before the first frame update
    void Start()
    {
        playerCollider = player.GetComponent<BoxCollider2D>();
        soupCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Collision())
        {
            SceneManager.LoadScene("gameOver");
        }
    }

    bool Collision()
    {
        if (soupCollider.bounds.Intersects(playerCollider.bounds))
        {
            return true;
        }
        return false;
    }
}
