using UnityEngine;

public class Tank : MonoBehaviour
{
    private GameObject tankWeapon;
    private bool move_right = false;
    private bool move_left = false;
    private float limit;
    private bool activate_helper;
    [SerializeField]
    private GameObject helper;
    //private Transform pos;

    private void Start()
    {
        tankWeapon = gameObject.transform.GetChild(0).gameObject;
        limit = GameManager.Instance.maximum_shoot_angle;
        activate_helper = GameManager.Instance.activate_helper;

        helper.SetActive(activate_helper);
    }
    private void Update()
    {
        if (move_left)
        {
            ToTheLeft();
        }
        if (move_right)
        {
            ToTheRight();
        }

    }

    private void ToTheLeft()
    {
        if (tankWeapon.transform.rotation.z >= limit) { return; }
        tankWeapon.transform.Rotate(Vector3.forward, GameManager.Instance.sensitivity);
    }

    private void ToTheRight()
    {
        if (tankWeapon.transform.rotation.z <= -limit) { return; }
        tankWeapon.transform.Rotate(Vector3.forward, GameManager.Instance.sensitivity * (-1));
    }

    // Controller
    public void PressLeft()
    {
        move_left = true;
        //ToTheLeft();
    }
    public void PressRight() 
    {
        move_right = true;
        //ToTheRight();
    }
    public void UnPressLeft()
    {
        move_left = false;
    }
    public void UnPressRight()
    {
        move_right = false;
    }


    // When get hit
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Game Over
            GameManager.Instance.GameOver();
        }
    }

}
