using UnityEngine;

public class Tembak : MonoBehaviour
{
    private float shootSpeed;
    [SerializeField]
    private GameObject bulletPrefab;

    public Animator riffleAnimation;
    public Animator tankAnimation;

    private void Start()
    {
        shootSpeed = GameManager.Instance.shootSpeed;

        // Repeat Duar function after 2 seconds delay every 1/shoot_speed seconds
        InvokeRepeating("Duar", 2, 1/shootSpeed); 
    }

    private void Duar()
    {
        riffleAnimation.SetBool("isShoot", true);
        tankAnimation.SetBool("isShoot", true);

        // Get the angle of shooting
        // From its parent's rotation
        Quaternion parentRot = gameObject.transform.parent.transform.rotation;

        // Instantiate bullet on the top of the launcher
        Instantiate(bulletPrefab, gameObject.transform.position, parentRot);
    }
}
