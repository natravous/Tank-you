using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankWeapon : MonoBehaviour
{

    private void Update()
    {
        transform.Translate(0, GameManager.Instance.shoot_velocity, 0);
    }
    // Trigger with world borders
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        // If exeeds the world borders, then destroy
        if (trigger.gameObject.CompareTag("World Border"))
        {
            Destroy(this.gameObject);
        }

        if (trigger.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("POIN");
            Destroy(this.gameObject);
            Destroy(trigger.gameObject);
        }
    }
}
