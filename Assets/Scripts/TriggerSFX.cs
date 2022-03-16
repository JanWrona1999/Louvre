using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSFX : MonoBehaviour
{
   public AudioSource _audio;

   void OnTriggerEnter(Collider collider)
   {
       _audio.Play();
   }
   void OnTriggerExit(Collider collider)
   {
       _audio.Pause();
   }
}
