using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCount : MonoBehaviour
{
    public GunControl playerGunControl;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(40, 40, 100, 20), "Bullets left: " + playerGunControl.bulletCount);
    }
}
