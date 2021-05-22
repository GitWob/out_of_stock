using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public Camera cam;
    public GameObject gun;
    public float fireRate;
    private GunFiring gunFiring;
    private Vector2 direction;
    private Vector3 mouseWorldPosition;
    private float shotTimer;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        gunFiring = gun.GetComponent<GunFiring>();
        shotTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        direction = mouseWorldPosition - gun.transform.position;
        FaceMouse();
        if (Input.GetMouseButton(0))
        {
            if (shotTimer > fireRate)
            {
                gunFiring.Fire();
                shotTimer = 0;
            }
        }

        shotTimer += Time.deltaTime;
    }

    void FaceMouse()
    {
        gun.transform.right = direction;
    }
}
