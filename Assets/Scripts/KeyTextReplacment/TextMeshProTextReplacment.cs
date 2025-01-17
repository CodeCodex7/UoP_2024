using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using System.Text;
using System.Text.RegularExpressions;
using System;
using UnityEngine.Analytics;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextMeshProTextReplacment : MonoBehaviour
{

    TextMeshProUGUI m_Text;
    // Start is called before the first frame update
    void Start()
    {
        m_Text = GetComponent<TextMeshProUGUI>();
        TextReplacment();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RePollText()
    {
        TextReplacment();
    }
    void TextReplacment()
    {
        try
        {
            string CapturePattern = "\\[(.*?)\\]";
            var Key = Regex.Match(m_Text.text, CapturePattern).Value;

            Key = Key.Trim(new Char[] { '[', ']' });
            Key = Key.ToUpper();
            var TextReplacement = Services.Resolve<TextReplacment>().GetText(Key);
            m_Text.text = Regex.Replace(m_Text.text, CapturePattern, TextReplacement);
        }
        catch(Exception e)
        {
            //Surpress for now
            //Debug.LogException(e);
        }

    }

    // Only in here so subtiles can destoy themselfs after beening displayed
    void DeleteSelf()
    {
        Destroy(this.gameObject);
    }

}
