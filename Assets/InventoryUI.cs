using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
public class InventoryUI : MonoService<InventoryUI>
{
    public GameObject Contents;
    
    public GameObject InventoryTile;

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
        Services.Resolve<InventorySystem>().CreateTestInventory();
        //OpenInventory(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenInventory(int ID)
    {

        Services.Resolve<CanvasController>().Opencanvas("Inventory");
        var GC = Services.Resolve<InventorySystem>().GetContainer(ID);
        DisplayContainer(GC);

        var Data = new MessageData(5, "OnInventory", typeof(InventoryMeesageData));
        int Id = 5;
        Data.ObjData = new InventoryMeesageData(1);
        Services.Resolve<GlobalMessanger>().BroadcastEvent("OnInventory", Data);
        
    }

    public class InventoryMeesageData
    {
        public int Open;

        public InventoryMeesageData(int mode)
            {
            Open = mode;
            }
    }
    
    public void CloseInventory()
    {
        Debug.Log("CloseTriggered");
        var Data = new MessageData(5, "OnInventory", typeof(InventoryMeesageData));
        Data.ObjData = new InventoryMeesageData(0);

        Services.Resolve<CanvasController>().CloseCanvas("Inventory");
        Services.Resolve<GlobalMessanger>().BroadcastEvent(6, Data);
    }

    public void DisplayContainer(GameContainer gameContainer)
    {
        foreach (var item in gameContainer.ContainerSlots)
        {
            var go = Instantiate(InventoryTile, Contents.transform);
            go.GetComponent<Image>().sprite = item.Items[0].ItemPicture;
            go.GetComponentInChildren<TextMeshProUGUI>().text = item.Items.Count.ToString();
        }
    }

}
