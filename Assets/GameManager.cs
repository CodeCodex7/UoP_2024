using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoService<GameManager>
{
    public GameObject PlayerObject;
    public Transform StartLocation;

    public GameObject ActivePlayer;



    private void Awake()
    {
        RegisterService();
    }

    private void OnDestroy()
    {
        UnregisterService();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPlayer()
    {
       ActivePlayer = Instantiate(PlayerObject, StartLocation.position, Quaternion.identity); 
       var message = new MessageData(4, "OnPlayerSpawn",typeof(GameObject));
       message.ObjData = ActivePlayer;
       Services.Resolve<GlobalMessanger>().BroadcastEvent(4, message);
       Services.Resolve<CameraController>().ChangeCamera("Player");
        Services.Resolve<CanvasController>().CloseCanvas("MainMenu");
        
    }

}
