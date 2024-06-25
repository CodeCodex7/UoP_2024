using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraVolumeSwitch : MonoBehaviour
{

    public string TargetCam;
    public string LastCamera ="";

    public bool IsTargetPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        LastCamera = Services.Resolve<CameraController>().ActiveVirtualCamera.gameObject.GetComponent<VirtualCameraRegister>().CameraName;
        Services.Resolve<CameraController>().ChangeCamera(TargetCam);
    }

    private void OnTriggerExit(Collider other)
    {
        Services.Resolve<CameraController>().ChangeCamera(LastCamera);  
    }


}
