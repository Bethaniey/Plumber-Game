using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectionCheck : MonoBehaviour
{
    public bool isConnected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "touch")
        {
            isConnected = true;  
		}
	}

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "touch")
        {
            isConnected = false;  
		}
	}
}