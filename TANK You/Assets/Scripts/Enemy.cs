using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        
    }

    // If being shooted
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Collide with Player's weapon
        if (other.gameObject.CompareTag("Player Weapon"))
        {

            // Explode Animation
            // <The code>

            // Destroy Object
            Destroy(this.gameObject);
        }
    }
}
