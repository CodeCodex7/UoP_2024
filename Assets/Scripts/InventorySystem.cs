using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.InteropServices.WindowsRuntime;

public class InventorySystem : MonoService<InventorySystem>
{


    public GameItemData ItemDate;
    Dictionary<int ,ItemData> ItemsData = new Dictionary<int ,ItemData>();
    Dictionary<int,GameContainer> GameContainers = new Dictionary<int ,GameContainer>();
    Dictionary<string, int> NameLookUpContainers = new Dictionary<string,int>();

    private void Awake()
    {
        RegisterService();
        RegisterItems();
    }

    private void OnDestroy()
    {
        UnregisterService();
    }

    private void RegisterItems()
    {
        foreach (var item in ItemDate.ItemData)
        {
            ItemsData.Add(item.ID, item);
            NameLookUpContainers.Add(item.ItemName, item.ID);
        }
    }

    public ItemData GetItem(int ID)
    {
        return ItemsData[ID].Clone() as ItemData;
    }
    public GameContainer GetContainer(int ID)
    {
        return GameContainers[ID];
    }

    public void CreateTestInventory()
    {
        var GC = new GameContainer("Test", 0, 50);
        
        foreach(var item in GC.ContainerSlots)
        {
            item.ItemData = GetItem(0);
            item.SetStackSize(GetItem(0));
        }

        GameContainers.Add(0,GC);
    }


}

public class GameContainer
{

    int ContainerID;
    string ContainerName;
    public int SlotAmmount;
    public ItemSlot[] ContainerSlots; 

    public GameContainer(string Name,int ID,int Slots)
    {
        ContainerSlots= new ItemSlot[Slots];
        ContainerName = Name;
        ContainerID = ID;

        for (int i = 0; i < ContainerSlots.Length; i++)
        {
            ContainerSlots[i] = new ItemSlot();
        }
    }


}

public class ItemSlot
{
    public int StackSize;
    public ItemData ItemData;
    public List<ItemData> Items;

    public bool IsSlotEmpty()
    {
        if(Items.Count == 0) return true;
        return false;
    }
    
    void SetSlot(ItemData Item)
    {

    }
    public void SetStackSize(ItemData Item)
    {
        StackSize = Item.MaxStack;
        Items = new List<ItemData>();
        Items.Add(Item);
    }
}

