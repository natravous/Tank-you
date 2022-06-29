using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    private GameObject enemy_prefab;

    private void Start()
    {
        InvokeRepeating("Serang", 1, GameManager.Instance.spawner_cd);
    }

    private void Serang()
    {
        Vector3 pos = transform.position;
        for (int i = 0; i < GameManager.Instance.initial_enemies; i++)
        {
            pos.x = Random.Range(-5.0f, 5.0f);
            pos.y = Random.Range(5.5f, 8.0f);
            Instantiate(enemy_prefab, pos, Quaternion.identity);
        }
    }

}
