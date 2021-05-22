using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform player;
    public float cameraDistance = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        int sHeight = Screen.height;
        GetComponent<UnityEngine.Camera>().orthographicSize = ((sHeight / 2) / cameraDistance);
    }

    private void FixedUpdate()
    {

        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
