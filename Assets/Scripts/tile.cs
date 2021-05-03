using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tile : MonoBehaviour
{
    private void OnMouseUp()
    {
     SoundManager.PlaySound("wrong");
	}
}
