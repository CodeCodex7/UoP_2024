using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "EventList", menuName = "Oliver's Toolbox/GlobalEventList")]
public class GlobalEventData : ScriptableObject
{

    //public  List<MessageData> m_Events = new List<MessageData>();

    [SerializeField]
    public EventData [] m_EventData;

    //public void AddData()
    //{
    //    m_EventData = m_Events.ToArray();
    //}

    //public void loadData()
    //{

    //}
    //public void SaveAsset()
    //{
    //    m_Events.
    //}


}


[Serializable]
public class EventData
{
    [SerializeField]
    public string Name;

    [SerializeField]
    public int ID;

    public EventData(int id,string name)
    {
        ID = id;
        Name = name;
    }

}