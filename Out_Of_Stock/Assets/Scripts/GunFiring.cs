using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunFiring : MonoBehaviour
{
    public float recoilForce;
    GunControl gunControl;
    Transform parentTransform;
    Rigidbody2D parentRigidbody;
    Vector2 kickVector;

    // Start is called before the first frame update
    void Start()
    {
        parentTransform = gameObject.GetComponentInParent<Transform>();
        parentRigidbody = gameObject.GetComponentInParent<Rigidbody2D>();
        gunControl = gameObject.GetComponentInParent<GunControl>();
        kickVector = (transform.right * -1) * recoilForce;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fire()
    {
        Debug.Log("Blam!");

        parentRigidbody.AddForce(kickVector);
    }
}
