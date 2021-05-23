using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShotScreenShake : MonoBehaviour
{
    // Instance gets called by other scripts to get to the CamShake method
    public static ShotScreenShake Instance { get; private set; }

    // Will be the virtual camera to apply screenshake to
    private CinemachineVirtualCamera virtualCam;
    private float shakeTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                // The above being true means the screen shake should stop
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
                    virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
        }
    }

    private void Awake()
    {
        virtualCam = GetComponent<CinemachineVirtualCamera>();
        Instance = this;    
    }

    // CamShake is what'll actually change the cam to shake
    public void CamShake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            virtualCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
        shakeTimer = time;
    }

}
