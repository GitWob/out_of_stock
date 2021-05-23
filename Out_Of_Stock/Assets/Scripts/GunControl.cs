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
    public float recoilForce;
    private GunFiring gunFiring;
    private Vector3 mouseWorldPosition;
    private float shotTimer;
    private Vector2 kickVector;
    float lifeTime = 1.0f; 
    // bullet shooty stuff 
    public GameObject bullet;
    public float bulletSpeed;
    public Transform shootPoint;
    public float bulletCount;

    //shell release shtuff 
    public GameObject shell;
    public float shellSpeed;
    public Transform shellPoint;

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

        // firing angle calculations from vector between player and mouse
        direction = ((Vector2)mouseWorldPosition - (Vector2)gun.transform.position).normalized;
        angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //kickVector.x = Mathf.Cos(angle);
        //kickVector.y = Mathf.Sin(angle);
        kickVector = direction * -1 * recoilForce;


        FaceMouse();

        // fires the gun
        if (Input.GetMouseButton(0))
        {
            if (shotTimer > fireRate)
            {
                if (bulletCount > 0)
                {
                    Fire();
                    shellRelease();
                    shotTimer = 0;
                    bulletCount--;
                }
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
        if (direction.x < 0)
        {
            gun.GetComponent<SpriteRenderer>().flipY = true;
        }
        else
        {
            gun.GetComponent<SpriteRenderer>().flipY = false;
        }
    }

    void Fire()
    {
        Debug.Log("Blam!");
        //Debug.Log("X: " + kickVector.x);
        //Debug.Log("Y: " + kickVector.y);
        //Debug.DrawLine(transform.position, transform.position + (Vector3)kickVector);
        //Debug.DrawRay(transform.position, kickVector, Color.cyan, 1);
        GetComponent<Rigidbody2D>().AddForce(kickVector, ForceMode2D.Impulse);
        GameObject bulletins = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        bulletins.GetComponent<Rigidbody2D>().AddForce(bulletins.transform.right * bulletSpeed);
        Destroy(bulletins, lifeTime);
        //ShotScreenShake.Instance.CamShake(4.5f, 0.1f);
    }

    void shellRelease()
    {
        GameObject shellIns = Instantiate(shell, shellPoint.position, shellPoint.rotation);
        shellIns.GetComponent<Rigidbody2D>().AddForce(shellIns.transform.up * shellSpeed);
        Destroy(shellIns, lifeTime);
    }
}
