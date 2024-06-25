using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class CanvasRegister : MonoBehaviour
{

    CanvasController CC;
    public string Name;
    public bool IsActive = false; 

    private void Awake()
    {
        CC = Services.Resolve<CanvasController>();
       
    }
    // Start is called before the first frame update
    void Start()
    {
        if(Name == null)
        {
            Name = Time.timeSinceLevelLoad.ToString();
        }

        DoIExist();
        CC.RegisterCanvas(Name, this.gameObject);
        
        if(IsActive)
        {
            CC.Opencanvas(Name);
        }
        else
        {
            CC.CloseCanvas(Name);
        }
    }

    //Classic Singlton Check
    void DoIExist()
    {
        if (CC.CanvasCheck(Name))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        CC.UnregisterCanvas(Name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
