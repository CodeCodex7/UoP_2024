using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEventTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Services.Resolve<GlobalMessanger>().Subscribe(0, () => { Debug.Log("Test"); });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Services.Resolve<GlobalMessanger>().BroadcastEvent(0, null);

            
            //Services.Resolve<CanvasController>().Opencanvas("A");

            var data = new MessageData(3, "Test", typeof(string));
            data.ObjData = new string("[CLICK]");
            Services.Resolve<GlobalMessanger>().BroadcastEvent("OnDisplayASubtitle", data);
        }


        if(Input.GetMouseButtonUp(0))
        {
            //Services.Resolve<CanvasController>().CloseCanvas("A");
        }
    }
}
