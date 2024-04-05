using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particlesystem;
    
    bool _hasDied;

   void OnCollisiionEnter2D(Collision2D collision)
   {

        if (ShouldDieFromCollision(collision))
        {
            StartCoroutine(Die());
        }
        
    }

bool ShouldDieFromCollision(Collision2D collision)
   {
        if (_hasDied)
            return false;

        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
        return true;

        if (collision.contacts[0].normal.y < -0.5)
        return true;

        return false;
   }
   IEnumerator Die()
   {
    _hasDied = true;
    GetComponent<SpriteRenderer>().sprite = _deadSprite;
    _particlesystem.Play();
    yield return new WaitForSeconds(1);
    
     gameObject.SetActive(false);
   }

}
