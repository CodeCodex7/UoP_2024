using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMessanger : MonoService<GlobalMessanger>
{
    public GlobalEventData eventData;
    public delegate void EventCallback(MessageData Data);

    Dictionary<string, int> NametoID = new Dictionary<string, int>();
    Dictionary<int, string> IDtoName = new Dictionary<int, string>();

    Dictionary<int, List<Action>> EventActions = new Dictionary<int, List<Action>>();
    Dictionary<int, List<EventCallback>> DelegateEventActions = new Dictionary<int, List<EventCallback>>();

    // Start is called before the first frame update
    void Start()
    {
        RegisterService();
        Initialistion();
    }

    private void OnDestroy()
    {
        UnregisterService();
    }

    // Update is called once per frame
    void Update()
    {

        //EventActions = new Dictionary<int, List<Action>>();
        //DelegateEventActions = new Dictionary<int, List<EventCallback>>();
    }

    int NameToId(string Name)
    {
        return NametoID[Name];
    }

    string IdToName(int ID)
    {
        return IDtoName[ID];
    }

    /// <summary>
    /// Subsicbe to an event via ID
    /// </summary>
    /// <param name="ID"></param>
    /// <param name="action"></param>
    public void Subscribe(int ID, Action action)
    {
        EventActions[ID].Add(action);
    }

    /// <summary>
    /// Subscube to an event via ID
    /// </summary>
    /// <param name="ID">ID of the event to subscribe too</param>
    /// <param name="delagate">delagate to pass</param>
    public void Subscribe(int ID, EventCallback delagate)
    {
        DelegateEventActions[ID].Add(delagate);
    }

    /// <summary>
    /// Subscribe to an event
    /// </summary>
    /// <param name="EventName">Name of the Event to subscribe too</param>
    /// <param name="action">Lamba to pass</param>
    public void Subscribe(string EventName, Action action)
    {
        EventActions[NameToId(EventName)].Add(action);
    }
    
    /// <summary>
    /// Subscribe to an event
    /// </summary>
    /// <param name="EventName">Name of the Event to subscribe too</param>
    /// <param name="delagate">delagate to pass</param>
    public void Subscribe(string EventName, EventCallback delagate)
    {
        DelegateEventActions[NameToId(EventName)].Add(delagate);
    }

    public void BroadcastEvent(int ID,MessageData data)
    {
        if (DelegateEventActions.ContainsKey(ID))
        {
            foreach (var item in DelegateEventActions[ID])
            {
                item.Invoke(data);
            }
        }


        if (EventActions.ContainsKey(ID))
        {
            foreach (var item in EventActions[ID])
            {
                item.Invoke();
            }
        }

        Debug.Log(string.Format("Broadcasting Event {0} to {1} Action Listners, {2} Delagate Listner",IdToName(ID), EventActions[ID].Count, DelegateEventActions[ID].Count));
    }

    public void BroadcastEvent(string Name, MessageData data)
    {
        int ID = NameToId(Name);
        if (DelegateEventActions.ContainsKey(ID))
        {
            foreach (var item in DelegateEventActions[ID])
            {
                item.Invoke(data);
            }
        }

        if (EventActions.ContainsKey(ID))
        {

            foreach (var item in EventActions[ID])
            {
                item.Invoke();
            }
        }

        Debug.Log(string.Format("Broadcasting Event {0} to {1} Action Listners, {2} Delagate Listner", Name, EventActions[ID].Count ,DelegateEventActions[ID].Count));

    }

    void Initialistion()
    {
        foreach (var item in eventData.m_EventData)
        {
            NametoID.Add(item.Name, item.ID);
            IDtoName.Add(item.ID,item.Name);

            DelegateEventActions.Add(item.ID, new List<EventCallback>());
            EventActions.Add(item.ID, new List<Action>());
        }
    }

    void CreateEvents()
    {

    }

}

public class ScriptableMessageData
{ 
    public string EventName; //Human Readable
    public int EventID;

    ScriptableMessageData(string eventName, int eventID)
    {
        EventName = eventName;
        EventID = eventID;
    }
}

/// <summary>
/// Data Structure for GlobalEventData
/// </summary>
public class MessageData
{
    public string EventName; //Human Readable
    public int EventID;
    public object ObjData;
    public Type Type;

    public MessageData(int Id, string Name,Type type)
    {
        EventID = Id;
        EventName = Name;
        Type = type;
    }
}