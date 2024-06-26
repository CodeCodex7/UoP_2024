using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "GameItemData", menuName = "GameData/ItemData")]
public class GameItemData : ScriptableObject
{
    [SerializeField]
    public ItemData[] ItemData; 
}

[Serializable]
public class ItemData : ICloneable
{
    public int ID;
    public string ItemName;
    public Sprite ItemPicture;
    public int MaxStack;

    public ItemData(int iD, string itemName, int maxStack)
    {
        ID = iD;
        ItemName = itemName;
        MaxStack = maxStack;
    }

    public object Clone()
    {
        var Data = new ItemData(ID, ItemName, MaxStack);
        Data.ItemPicture = ItemPicture;

        return Data;
    }
}