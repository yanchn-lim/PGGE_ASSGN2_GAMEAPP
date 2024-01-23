using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Start()
    {
        // Destroy the bullet after 10 seconds if it does not hit any object.
        StartCoroutine(Coroutine_Destroy(10.0f));
    }

    IEnumerator Coroutine_Destroy(float duration)
    {
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }

    
    private void OnCollisionEnter(Collision collision)
    {
        //when the bullet collides with an object
        //it calls the object's IDamageable interface
        //and calls the TakeDamage() method which debug out "Box: I am hit by a bullet!"
        IDamageable obj = collision.gameObject.GetComponent<IDamageable>();
        if (obj != null)
        {
            obj.TakeDamage();
        }

        //then it destroys this bullet
        StartCoroutine(Coroutine_Destroy(0.1f));
    }
}
