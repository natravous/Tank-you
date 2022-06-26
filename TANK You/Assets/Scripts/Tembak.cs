using System.Collections;
using UnityEngine;

public class Tembak : MonoBehaviour
{
    private float shoot_speed;
    [SerializeField]
    private GameObject bullet_prefab;

    private void Start()
    {
        shoot_speed = GameManager.Instance.shoot_speed;
        InvokeRepeating("Duar", 2, 1/shoot_speed);
    }

    private void Update()
    {
    }

    private void Duar()
    {
        Quaternion parent_rot = gameObject.transform.parent.transform.rotation;
        Instantiate(bullet_prefab, gameObject.transform.position, parent_rot);
    }
}
