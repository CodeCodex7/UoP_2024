using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using System.Linq;
using System.Text.RegularExpressions;

[CustomEditor(typeof(GlobalEventData))]
public class GlobalEventlistEditor : Editor
{
    GlobalEventData data;
    ///public List<Type> Typelist; 


    public void OnEnable()
    {
        data = (GlobalEventData)target;
    }

    public override void OnInspectorGUI()
    {
        data = (GlobalEventData)target;
        //data.loadData();
        Header(); 
        AddData(data);
        ClearData(data);
        SaveAssets(data);
        DisplayData(data);
        
        //GetAllTypes();
    }

    void Header()
    {
        var HeaderStyle = new GUIStyle();
        HeaderStyle.fontSize = 16;
        HeaderStyle.alignment = TextAnchor.MiddleCenter;
        HeaderStyle.normal.textColor = Color.white;
        HeaderStyle.fontStyle = FontStyle.Bold;

        GUILayout.Label("List of Events", HeaderStyle);
    }
    public void DisplayData(GlobalEventData data)
    {

        if (data.m_EventData != null)
        {
            for (int i = 0; i < data.m_EventData.Length; i++)
            {
                DisplayElement(i, data.m_EventData[i]);
            }
        }

    }
    public void DisplayElement(int i,EventData Data)
    {
        GUILayout.BeginHorizontal() ;

        #region Name
        var TextStyle = GUI.skin.textArea;
        TextStyle.fixedHeight = 20;
        TextStyle.fixedWidth = 300;
        TextStyle.normal.textColor = Color.white;
        
        var text = GUILayout.TextField(Data.Name,50,TextStyle);
        Data.Name = text;

        GUILayout.Space(10);
        #endregion
         
        #region ID
        var IntStyle = GUI.skin.textField;
        IntStyle.fixedHeight = 20;
        IntStyle.fixedWidth = 40;
        TextStyle.normal.textColor = Color.white;

        var ID = EditorGUILayout.IntField("", Data.ID,IntStyle);
        Data.ID = ID;

        GUILayout.Space(10);
        #endregion

        #region Type
        /* Needs a better plan to implements, revisit idea to spec type at a later date
      

        var Content = new GUIContent(Data.Type.ToString());
        GenericMenu menu = new GenericMenu();

        foreach (var valueType in Typelist)
        {
            menu.AddItem(new GUIContent(valueType.ToString()), false, dostuff, valueType);
        }


        void dostuff(object parameter)
        {
            Content.text = parameter as string;
            Data.Type = parameter as Type;
            Debug.Log(parameter);
        }


        if (EditorGUILayout.DropdownButton(Content, FocusType.Keyboard))
        {
            menu.ShowAsContext();
        };
        
        
        */
        #endregion

        GUILayout.EndHorizontal();

        GUILayout.Space(10);

    }
    public void ClearData(GlobalEventData Data)
    {
        if (GUILayout.Button("Clear All Data in List"))
        {
           // Data.m_EventData.Clear()
            EditorUtility.SetDirty(Data);
            //Data.SaveAsset();
            AssetDatabase.SaveAssets();
        }
    }

    public void CreateData(GlobalEventData Data)
    {
        if (GUILayout.Button("Clear All Data"))
        {
            if (Data.m_EventData != null)
            {

            }
            else
            {
                Data.m_EventData = new EventData[10];
            }
        }
    }

    public void AddData(GlobalEventData data)
    {
        if (GUILayout.Button("Add Event"))
        {
            AddSingleElement(data);
        }
    }


    public void SaveAssets(GlobalEventData data)
    {
        if (GUILayout.Button("Save Data"))
        {
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
            //data.SetDirty();
           
        }
    }
    public void AddSingleElement(GlobalEventData Data)
    {

        if (Data.m_EventData == null)
        {
           // Data = new List<MessageData>();
           Data.m_EventData = new EventData[10];
        }

        var d = Data.m_EventData.ToList();

        int C1 = d.Count;
        int c2 = C1 + 1;
        for (int i = C1; i < c2; i++)
        {
            //Data.Events.Add(new MessageData(i,Time.frameCount.ToString()));
           d.Add(new EventData(i, "OnEventNamed"));
        }

        data.m_EventData = d.ToArray();
        //data.SaveAsset();
        EditorUtility.SetDirty(Data);
        AssetDatabase.SaveAssets();
    }

    //public List<Type> GetAllTypes()
    //{


    //    string Pattern = "(UnityEngine|System|Assembly-CSharp)";

    //    var ValueType = from T in System.AppDomain.CurrentDomain.GetAssemblies()
    //                    from T1 in T.GetTypes()
    //                    where Regex.Match(T1.FullName, Pattern).Success
    //                    select T1;


    //    foreach (var item in ValueType)
    //    {
    //        //Debug.Log(item);
    //    }


    //    //foreach (var item in ValueType)
    //    //{
    //    //        Debug.Log(item);      
    //    //}

       


    //    return ValueType.ToList();
    //}

}
