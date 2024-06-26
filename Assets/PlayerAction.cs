using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

public class PlayerAction : MonoBehaviour
{
    public GameObject Notfication;
    bool PlayerNearby;
    public UnityAction Actions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerNearby)
        {
            Notfication.SetActive(true);
        }
        else
        {
            Notfication.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.gameObject.tag == "Player")
        //{
            Notfication.SetActive(true) ;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.tag == "Player")
        //{
        Notfication.SetActive(false);
        //}
    }
    
}
