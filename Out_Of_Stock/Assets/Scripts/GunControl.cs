using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunControl : MonoBehaviour
{
    public Camera cam;
    public GameObject gun;
    public GunFiring gunFiring;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        gunFiring = gun.GetComponent<GunFiring>();
    }

    // Update is called once per frame
    void Update()
    {

        gun.transform.LookAt(cam.ScreenToWorldPoint(Input.mousePosition));
    }
}
