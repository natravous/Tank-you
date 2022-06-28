using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchControls : MonoBehaviour
{
    //public GameObject center;
    //private Vector3 start_center;

    //private void Start()
    //{
    //    start_center = center.transform.position;
    //}
    //// Update is called once per frame
    //void Update()
    //{
    //    if (Input.touchCount <= 0) { return; }

    //    Touch touch = Input.GetTouch(0);
    //    Vector2 touch_pos = Camera.main.ScreenToWorldPoint(touch.position);

    //    if (GetComponent<Collider2D>() != Physics2D.OverlapPoint(touch_pos)) { return; }
    //    // User touched the area
    //    Debug.Log("Touched!");
    //    center.transform.Rotate(Vector3.forward, CalculateAngle(touch_pos));
    //}

    //float CalculateAngle(Vector3 pos)
    //{
    //    Vector3 center = this.center.transform.position;
    //    float solution = Mathf.Atan2(center.y - start_center.y, center.x - start_center.x) * 
    //        180 / Mathf.PI;
    //    start_center = center;

    //    return solution;
    //}
    public GameObject to_rotate;
    private Camera cam;
    private Vector3 current_screen_pos;
    private Vector3 last_screen_pos;
    private Vector3 last_touch_pos;
    private float angle_offs;
    private Collider2D col;
    

    private void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            Vector3 touch_position = cam.ScreenToWorldPoint(touch.position);

            if (touch.phase == TouchPhase.Began)
            {
                if (!(col == Physics2D.OverlapPoint(touch_position))) { return; }

                last_screen_pos = cam.WorldToScreenPoint(to_rotate.transform.position);
                last_touch_pos = cam.WorldToScreenPoint(touch_position);
            }

            if (touch.phase == TouchPhase.Stationary)
            {
                return;
            }

            if (touch.phase == TouchPhase.Moved)
            {
                if (!(col == Physics2D.OverlapPoint(touch_position))) { return; }
                current_screen_pos = cam.WorldToScreenPoint(touch_position);
                angle_offs = (Mathf.Atan2(last_touch_pos.y, last_touch_pos.y) -
                    Mathf.Atan2(current_screen_pos.y, current_screen_pos.x)) * Mathf.Rad2Deg;
                Debug.Log(angle_offs + "Rad");
                Debug.Log(cam.WorldToScreenPoint(touch_position) - last_touch_pos);
                if (IsPositive(cam.WorldToScreenPoint(touch_position).x - 
                    last_touch_pos.x) == IsPositive(angle_offs))
                {
                    to_rotate.transform.Rotate(new Vector3(0, 0, -angle_offs));

                }
                else
                {
                    switch (cam.WorldToScreenPoint(touch_position).x - last_touch_pos.x > 0)
                    {
                        case true:
                            to_rotate.transform.Rotate(new Vector3(0, 0, -angle_offs));
                            break;
                        case false:
                            to_rotate.transform.Rotate(new Vector3(0, 0, angle_offs));
                            break;
                    }
                }
                
                last_touch_pos = cam.WorldToScreenPoint(touch_position);
            }

            if (touch.phase == TouchPhase.Ended)
            {
                if (!(col == Physics2D.OverlapPoint(touch_position))) { return; }
                last_screen_pos = cam.WorldToScreenPoint(to_rotate.transform.position);
            }

            //if (touch.phase == TouchPhase.Began)
            //{
            //    if (col == Physics2D.OverlapPoint(touch_position))
            //    {
            //        Debug.Log("Touched! Began");
            //        screen_post = cam.WorldToScreenPoint(transform.position);
            //        Vector3 vec3 = cam.WorldToScreenPoint(touch_position) - screen_post;
            //        angle_offs = (Mathf.Atan2(transform.right.y, transform.right.x) -
            //            Mathf.Atan2(vec3.y, vec3.x)) * Mathf.Rad2Deg;

            //    }
            //}

            //if (touch.phase == TouchPhase.Moved)
            //{
            //    if (col == Physics2D.OverlapPoint(touch_position))
            //    {
            //        Debug.Log("Touched! Moved");
            //        Vector3 vec3 = cam.WorldToScreenPoint(touch_position) - screen_post;
            //        float angle = Mathf.Atan2(vec3.y, vec3.x) * Mathf.Rad2Deg;
            //        to_rotate.transform.eulerAngles = new Vector3(0, 0, angle + angle_offs);
            //    }
            //}


        }
    }

    private bool IsPositive(float num)
    {
        return num > 0;
    }
}
