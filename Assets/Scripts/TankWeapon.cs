using UnityEngine;

public class TankWeapon : MonoBehaviour
{
    // This is Bullet properties
    private void Update()
    {
        // Move towards Y axis
        transform.Translate(0, GameManager.Instance.shoot_velocity, 0);
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        // If exeeds the world borders, then destroy
        if (trigger.gameObject.CompareTag("World Border"))
        {
            Destroy(this.gameObject);
        }

        if (trigger.gameObject.CompareTag("Enemy"))
        {
            Destroy(trigger.gameObject);
            Destroy(this.gameObject);
        }
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy"))
    //    {
    //        Destroy(collision.gameObject);
    //        Destroy(this.gameObject);
    //    }
    //}
}
