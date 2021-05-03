using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip rotateSound, wrongSound;
    static AudioSource audioSrc;

    void Start()
    {
        rotateSound = Resources.Load<AudioClip>("RotateSound");
        wrongSound = Resources.Load<AudioClip>("WrongSound");

        audioSrc = GetComponent<AudioSource>();
    }

   public static void PlaySound(string clip)
   {
       switch(clip)
       {
        case "rotate":
            audioSrc.PlayOneShot(rotateSound);
            break;
        case "wrong":
            audioSrc.PlayOneShot(wrongSound);
            break;
	   }
   }
}
