using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneController : MonoService<SceneController> 
{

    private void Awake()
    {
        RegisterService();
    }

    private void OnDestroy()
    {
        UnregisterService();
    }

    public void LoadScene(int Index)
    {
        SceneManager .LoadScene(Index, LoadSceneMode.Single);
    }
    
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName,LoadSceneMode.Single);
    }

}
