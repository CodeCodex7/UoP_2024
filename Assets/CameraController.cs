using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Cinemachine;

public class CameraController : MonoService<CameraController> 
{

    Dictionary<string,CinemachineVirtualCamera> CameraDict = new Dictionary<string, CinemachineVirtualCamera>();
    public List<CinemachineVirtualCamera> VirtualCameras = new List<CinemachineVirtualCamera>();

    public CinemachineVirtualCamera ActiveVirtualCamera;

    private void Awake()
    {
        RegisterService();
    }

    public void ChangeCamera(string Camera)
    {
        ActiveVirtualCamera.enabled = false;
        ActiveVirtualCamera = CameraDict[Camera];
        ActiveVirtualCamera.enabled = true;
    }

    public void RegisterCamera(string CameraName, CinemachineVirtualCamera VirtualCamera)
    {
        CameraDict.Add(CameraName, VirtualCamera);
    }
    
}
