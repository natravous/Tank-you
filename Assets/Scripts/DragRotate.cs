using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRotate : MonoBehaviour
{
    public GameObject object_to_rotate; // Object we want to rotate
    private Camera cam; // Main Camera
    private Collider2D col; // Object's collider 2D

    // Position
    // All positions should be in world points not screen
    private Vector3 to_rotate_ori_pos; // Original Position object want to rotate
    private Vector3 touch0_pos; // Touch position as comparison to others (0)

    // Angle
    private float angle_off; // Difference between 2 angle

    private float max_angle;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        col = GetComponent<Collider2D>();
        to_rotate_ori_pos = col.transform.position; // (0,0) position for rotation
        max_angle = GameManager.Instance.maximum_shoot_angle;
    }

    // Update is called once per frame
    void Update()
    {
        // If there are touch(es)
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch object
            Vector3 touch_pos = cam.ScreenToWorldPoint(touch.position); // convert touch pos to world point

            // User start to touch
            if ( touch.phase == TouchPhase.Began)
            {
                if (!(col == Physics2D.OverlapPoint(touch_pos))) { return; }
                touch0_pos = touch_pos;
            }

            // If user move the touch
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 delta_touch0 = touch0_pos - to_rotate_ori_pos; // Last touch pos from rotating obj
                Vector3 delta_toucht = touch_pos - to_rotate_ori_pos; // current touch pos from rotating obj

                // Calculate the angle's diference
                angle_off = (Mathf.Atan2(delta_touch0.y, delta_touch0.x) -
                    Mathf.Atan2(delta_toucht.y, delta_toucht.x)) * Mathf.Rad2Deg;
                angle_off = Mathf.Abs(angle_off); // Makes it always positive

                // Restirction to move on maximu (x) degrees
                //if (object_to_rotate.transform.rotation.z >= max_angle &&
                //    !IsPositive(touch_pos.x - touch0_pos.x)) { return; }
                //if (object_to_rotate.transform.rotation.z <= max_angle &&
                //    IsPositive(touch_pos.x - touch0_pos.x)) { return; }

                switch (touch_pos.x - touch0_pos.x >= 0)
                {
                    // touch from left to right
                    case true:
                        object_to_rotate.transform.Rotate(new Vector3(0, 0, -angle_off));
                        touch0_pos = touch_pos;
                        break;
                    // touch from rigt to left
                    case false:
                        object_to_rotate.transform.Rotate(new Vector3(0, 0, angle_off));
                        touch0_pos = touch_pos;
                        break;

                }

            }

        }
    }

    private bool IsPositive(float num)
    {
        return num >= 0;
    }
}
