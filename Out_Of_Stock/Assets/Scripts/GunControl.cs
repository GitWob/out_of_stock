using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public Camera cam;
    public GameObject gun;
    public float fireRate;
    public float angle;
    public Vector2 direction;
    private GunFiring gunFiring;
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
        // gets the position of the mouse
        mouseWorldPosition = cam.ScreenToWorldPoint(Input.mousePosition);

        // finds the angle the gun should be facing if it starts at the gun's position and looks at the mouse
        direction = (mouseWorldPosition - gun.transform.position).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        FaceMouse();

        // fires the gun
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

    /// <summary>
    /// pivots the gun to the angle variable
    /// </summary>
    void FaceMouse()
    {
        gun.transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
