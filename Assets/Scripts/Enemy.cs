using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float selfGacha;

    private void Start()
    {
        selfGacha = Random.Range(.3f, .5f) + (GameManager.Instance.multiplier * 0.0005f);

    }
    // Enemy movement
    private void Update()
    {
        transform.Translate(0, GameManager.Instance.enemySpd * selfGacha, 0);
        transform.Rotate(new Vector3(0, 0, 1));
    }

    // If being shooted
    private void OnTriggerEnter2D(Collider2D trigger)
    {
        // If exeeds the world borders, then destroy
        if (trigger.gameObject.CompareTag("World Border"))
        {
            Destroy(this.gameObject);
        }
    }

}
