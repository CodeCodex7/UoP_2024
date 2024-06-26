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
    public bool PlayerFocus = false;
    public bool PlayerAimFocus = false;
    public bool PlayerFollowFocus = false;


    CinemachineVirtualCamera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        Services.Resolve<CameraController>().RegisterCamera(CameraName,cam);
        cam.enabled = IsEnable;

        if (IsEnable)
        {
            Services.Resolve<CameraController>().ActiveVirtualCamera = cam;
        }

        if(PlayerFocus)
        {
            Services.Resolve<GlobalMessanger>().Subscribe(4, TargetPlayer);
        }
    }

    void TargetPlayer(MessageData Data)
    {
        GameObject Obj = Data.ObjData as GameObject;
        var T = Obj.GetComponentInChildren<CharacterController>();

        if(PlayerFollowFocus)
            cam.Follow = T.gameObject.transform;

        if(PlayerAimFocus)
            cam.LookAt = T.gameObject.transform;
    }
}
