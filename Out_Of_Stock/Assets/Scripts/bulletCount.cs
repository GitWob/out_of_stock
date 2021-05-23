using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletCount : MonoBehaviour
{
    public GunControl playerGunControl;
    private GUIStyle red;


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
        red = new GUIStyle();
        red.normal.textColor = Color.red;
        GUI.contentColor = Color.red;
        GUI.Label(new Rect(40, 40, 100, 20), "Bullets left: " + playerGunControl.bulletCount,red);
    }
}
