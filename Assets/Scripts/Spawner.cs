using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject enemyPrefab;

    private void Start()
    {
        InvokeRepeating("Serang", 1, GameManager.Instance.spawnerCD);
    }

    private void Serang()
    {
        Vector3 pos = transform.position;
        Vector3 tankPos = GameManager.Instance.tankPosition.position;
        for (int i = 0; i < GameManager.Instance.initialEnemies; i++)
        {
            pos.x = Random.Range(-5.0f, 5.0f);
            pos.y = Random.Range(5.5f, 8.0f);
            float angle = Mathf.Atan2(pos.y - tankPos.y, pos.x - tankPos.x) * Mathf.Rad2Deg;

            Instantiate(enemyPrefab, pos, Quaternion.Euler(new Vector3(0, 0, angle + 90)));
        }
    }

}
