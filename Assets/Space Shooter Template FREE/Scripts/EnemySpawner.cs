using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Kéo Prefab kẻ địch vào đây
    public float spawnRate = 2f;   // Thời gian giãn cách giữa mỗi lần sinh (giây)
    public float xRange = 8f;      // Độ rộng màn hình để kẻ địch xuất hiện ngẫu nhiên
    public float ySpawnPos = 6f;   // Độ cao phía trên màn hình

    private float nextSpawnTime;

    void Update()
    {
        // Kiểm tra xem đã đến lúc sinh con mới chưa
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            // Thiết lập thời điểm tiếp theo sẽ sinh
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        // Lấy vị trí X ngẫu nhiên để kẻ địch không ra cùng một chỗ
        float randomX = Random.Range(-xRange, xRange);
        Vector3 spawnPosition = new Vector3(randomX, ySpawnPos, 0);

        // Lệnh tạo kẻ địch
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}