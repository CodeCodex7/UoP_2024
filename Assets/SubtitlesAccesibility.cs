using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SubtitlesAccesibility : MonoBehaviour
{

    private GlobalMessanger GlobalMessanger;

    public GameObject TextObject;
    public RectTransform SpawnPoint;
    public Canvas TargetCanvas;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GlobalMessanger = Services.Resolve<GlobalMessanger>();
        GlobalMessanger.Subscribe("OnDisplayASubtitle", DisplayMessage);
    }

    void DisplayMessage(MessageData Data)
    {
        var G = Instantiate(TextObject, SpawnPoint.position, Quaternion.identity,TargetCanvas.gameObject.transform);
        G.GetComponent<TextMeshProUGUI>().text = Data.ObjData as string;
        G.GetComponent<TextMeshProTextReplacment>().RePollText();
    }


    // Update is called once per frame
    void Update()
    {
        
    }



}
