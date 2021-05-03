using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    private void OnMouseUp()
    {
        if(!FindObjectOfType<GameManager>().pause)
        {
            transform.Rotate(0,90,0);
            SoundManager.PlaySound("rotate");
            FindObjectOfType<GameManager>().pause = true;
		}
	}
}