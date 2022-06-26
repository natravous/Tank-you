using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    private GameObject tankWeapon;
    private bool move_right = false;
    private bool move_left = false;

    //private Transform pos;

    private void Start()
    {
        Transform a = gameObject.transform.GetChild(0);
        tankWeapon = a.gameObject;
        
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
        if (tankWeapon.transform.rotation.z >= 0.3) { return; }
        tankWeapon.transform.Rotate(Vector3.forward, GameManager.Instance.sensitivity);
    }

    private void ToTheRight()
    {
        if (tankWeapon.transform.rotation.z <= -0.3) { return; }
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
        Debug.Log( tankWeapon.transform.rotation.z * 180 + "Derajat");
    }
    public void UnPressRight()
    {
        move_right = false;
        Debug.Log(tankWeapon.transform.rotation.z * 180 + "Derajat");
    }


    // When get hit
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            // Game Over
        }
    }

}
