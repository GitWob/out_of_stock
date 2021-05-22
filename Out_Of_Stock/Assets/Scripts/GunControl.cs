using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public Camera cam;
    public GameObject gun;
    private GunFiring gunFiring;
    private Vector2 direction;
    private Vector3 mouseWorldPosition;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        gunFiring = gun.GetComponent<GunFiring>();
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        direction = mouseWorldPosition - gun.transform.position;
        FaceMouse();
    }

    void FaceMouse()
    {
        gun.transform.right = direction;
    }
}
