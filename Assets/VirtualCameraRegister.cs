using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CinemachineVirtualCamera))] 
public class VirtualCameraRegister : MonoBehaviour
{
    public string CameraName;
    public int ID;

    public bool IsEnable = false;

    // Start is called before the first frame update
    void Start()
    {
        var cam = GetComponent<CinemachineVirtualCamera>();
        Services.Resolve<CameraController>().RegisterCamera(CameraName,cam);
        cam.enabled = IsEnable;

        if (IsEnable)
        {
            Services.Resolve<CameraController>().ActiveVirtualCamera = cam;
        }
    }
}
