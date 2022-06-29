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
        for (int i = 0; i < GameManager.Instance.initialEnemies; i++)
        {
            pos.x = Random.Range(-5.0f, 5.0f);
            pos.y = Random.Range(5.5f, 8.0f);
            Instantiate(enemyPrefab, pos, Quaternion.identity);
        }
    }

}
