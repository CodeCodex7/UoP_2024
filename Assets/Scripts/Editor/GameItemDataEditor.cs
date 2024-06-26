using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(GameItemData))]
public class GameItemDataEditor : Editor
{
    GameItemData data;
    ///public List<Type> Typelist; 


    public void OnEnable()
    {
        data = (GameItemData)target;
    }

    public override void OnInspectorGUI()
    {
        data = (GameItemData)target;
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

        GUILayout.Label("List of Items", HeaderStyle);
    }
    public void DisplayData(GameItemData data)
    {

        if (data.ItemData != null)
        {
            for (int i = 0; i < data.ItemData.Length; i++)
            {
                if (data.ItemData[i] == null)
                {
                    data.ItemData[i] = new ItemData(0, "Item", 5);
                }
                DisplayElement(i, data.ItemData[i]);
            }
        }

    }
    public void DisplayElement(int i, ItemData Data)
    {
        GUILayout.BeginHorizontal();

        #region Picture
        //var PicStyle = GUI.skin.input
        //IntStyle.fixedHeight = 20;
        //IntStyle.fixedWidth = 40;
        //TextStyle.normal.textColor = Color.white;
        GUILayout.FlexibleSpace();
        var Pic = EditorGUILayout.ObjectField(Data.ItemPicture, typeof(Sprite), false, GUILayout.Height(EditorGUIUtility.singleLineHeight)) as Sprite;
        Data.ItemPicture = Pic;
        GUILayout.Space(10);
        GUILayout.FlexibleSpace();
        #endregion

        #region Name
        var TextStyle = GUI.skin.textArea;
        TextStyle.fixedHeight = 20;
        TextStyle.fixedWidth = 300;
        TextStyle.normal.textColor = Color.white;

        var text = GUILayout.TextField(Data.ItemName, 50, TextStyle);
        Data.ItemName = text;

        GUILayout.Space(10);
        #endregion

        #region ID
        var IntStyle = GUI.skin.textField;
        IntStyle.fixedHeight = 20;
        IntStyle.fixedWidth = 20;
        TextStyle.normal.textColor = Color.white;

        var ID = EditorGUILayout.IntField("", Data.ID, IntStyle);
        Data.ID = ID;

        //GUILayout.Space(10);
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
    public void ClearData(GameItemData Data)
    {
        if (GUILayout.Button("Clear All Data in List"))
        {
            // Data.m_EventData.Clear()
            EditorUtility.SetDirty(Data);
            //Data.SaveAsset();
            AssetDatabase.SaveAssets();
        }
    }
    public void AddData(GameItemData data)
    {
        if (GUILayout.Button("Add Event"))
        {
            AddSingleElement(data);
        }
    }
    public void SaveAssets(GameItemData data)
    {
        if (GUILayout.Button("Save Data"))
        {
            EditorUtility.SetDirty(data);
            AssetDatabase.SaveAssets();
            //data.SetDirty();

        }
    }
    public void AddSingleElement(GameItemData Data)
    {

        if (Data.ItemData == null)
        {
            Debug.Log("No ItemData");
            Data.ItemData = new ItemData[10];
        }

        var d = Data.ItemData.ToList();

        int C1 = d.Count;
        int c2 = C1 + 1;
        for (int i = C1; i < c2; i++)
        {
            //Data.Events.Add(new MessageData(i,Time.frameCount.ToString()));
            d.Add(new ItemData(i, "ITEM", 5));
        }

        data.ItemData = d.ToArray();
        EditorUtility.SetDirty(Data);
        AssetDatabase.SaveAssets();
    }

}
