using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab; // Ô để kéo kẻ địch vào

    void Start()
    {
        // Cứ mỗi 2 giây sinh ra 1 kẻ địch
        InvokeRepeating("SpawnEnemy", 2f, 2f);
    }

    void SpawnEnemy()
    {
        // Vị trí ngẫu nhiên theo chiều ngang
        float randomX = Random.Range(-8f, 8f);
        Instantiate(enemyPrefab, new Vector3(randomX, 7f, 0), Quaternion.identity);
    }
}