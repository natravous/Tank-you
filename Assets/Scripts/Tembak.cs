using UnityEngine;

public class Tembak : MonoBehaviour
{
    private float shoot_speed;
    [SerializeField]
    private GameObject bullet_prefab;

    private void Start()
    {
        shoot_speed = GameManager.Instance.shoot_speed;

        // Repeat Duar function after 2 seconds delay every 1/shoot_speed seconds
        InvokeRepeating("Duar", 2, 1/shoot_speed); 
    }

    private void Duar()
    {
        // Get the angle of shooting
        // From its parent's rotation
        Quaternion parent_rot = gameObject.transform.parent.transform.rotation;

        // Instantiate bullet on the top of the launcher
        Instantiate(bullet_prefab, gameObject.transform.position, parent_rot);
    }
}
