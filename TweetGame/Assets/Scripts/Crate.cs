using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : MonoBehaviour
{
   void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.relativeVelocity.magnitude > 5f)
        {
            GetComponent<AudioSource>().Play();
        }
        else
        {
            Debug.Log("too weak" + collision.relativeVelocity.magnitude);
        }
   }
}
