using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoService<CanvasController> 
{

    Dictionary<string, CanvasData> CanvasDirectory = new Dictionary<string, CanvasData>();
    public List<string> ActiveCanvas = new List<string>();


    // Dictionary<string,int> CanvasNames = new Dictionary<string,int>();



    public void Awake()
    {
        RegisterService();
    }
    private void OnDestroy()
    {
        UnregisterService();
    }

    public void TransitionCanvas(string TargetName,string CurrentCanvas)
    {
        Opencanvas(TargetName);
        CloseCanvas(CurrentCanvas);
    }

    public void Opencanvas(string TargetName)
    {
        getCanvas(TargetName).Canvas.SetActive(true);
        ActiveCanvas.Add(TargetName);
    }

    public void CloseCanvas(string TargetName)
    {
        getCanvas(TargetName).Canvas.SetActive(false);
        ActiveCanvas.Remove(TargetName);
    }

    public bool CanvasCheck(string TargetName)
    {
        if(ActiveCanvas.Contains(TargetName) || CanvasDirectory.ContainsKey(TargetName))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private CanvasData getCanvas(string Name)
    {
        if(CanvasDirectory.ContainsKey(Name))
        {
            return CanvasDirectory[Name];
        }
        else
        {
            return null;
        }
    }

    public void RegisterCanvas(string Name,GameObject Canvas)
    {
        CanvasDirectory.Add(Name,new CanvasData(Name,CanvasDirectory.Count+1,Canvas));
        //CanvasNames.Add(name, CanvasDirectory.Count + 1);
    }

    public void UnregisterCanvas(string Name)
    {
        CloseCanvas(Name);
        CanvasDirectory.Remove(Name);
    }

    private class CanvasData
    {
        string Name;
        int ID;

        public GameObject Canvas;
        public CanvasData(string name,int id, GameObject canvas)
        {
            Name = name;
            ID = id;
            Canvas = canvas;
        }

    }

}
