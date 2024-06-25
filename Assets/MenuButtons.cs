using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void LoadLevel(string Name)
    {
        Services.Resolve<SceneController>().LoadScene(Name);
    }

    public void LoadLevel(int ID)
    {
        Services.Resolve<SceneController>().LoadScene(ID);
    }

    public void CloseCanvas(string Name)
    {
        Services.Resolve<CanvasController>().CloseCanvas(Name);
    }

    public void OpenCanvas(string Name)
    {
        Services.Resolve<CanvasController>().Opencanvas(Name);
    }

    public void CloseApllication()
    {
        Application.Quit();
    }

}
