using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{
    private float half_screen = Screen.width / 2.0f;
    private Vector2 current_position;
    private Vector2 last_position;

    private void Awake()
    {
        
    }
    private void Update()
    {
        // Touch Inputs
        if (Input.touchCount == 1)
        {
            Touch inputs = Input.GetTouch(0);
            if (inputs.phase == TouchPhase.Moved)
            {
                Debug.Log(inputs.position);
            }

            //if (inputs.phase == TouchPhase.Began)
            //{
            //    last_position = inputs.position;
            //}

            //if (inputs.phase == TouchPhase.Ended)
            //{
            //    current_position = inputs.position;

            //}

            //if (inputs.phase == TouchPhase.Moved)
            //{
            //    Debug.Log(inputs.position);
            //    Vector2 current_position = inputs.position;

            //    float z = (current_position.x - last_position.x)/half_screen * 90;

            //    // Move the Tank's weapon
            //    gameObject.transform.GetChild(0).Rotate( 0f, 0f, z, Space.Self);
            //}
        }
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
