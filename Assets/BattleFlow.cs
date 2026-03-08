using UnityEngine;

public class BattleFlow : MonoBehaviour
{
    public GameObject gameOverUI; // Kéo bảng GameOverPanel vào đây
    public PlayerHealth playerHealth; // Kéo Player vào đây
    public GameObject bgMusic; // Kéo nguồn nhạc nền vào đây

    private void Start()
    {
        gameOverUI.SetActive(false); // Ẩn UI lúc đầu

        // Đăng ký nhận tin: Khi Player phát tín hiệu onDead, thì chạy hàm OnGameOver
        if (playerHealth != null) {
            playerHealth.onDead += OnGameOver;
        }
    }

    private void OnGameOver()
    {
        gameOverUI.SetActive(true); // Hiện bảng Game Over
        if (bgMusic != null) bgMusic.SetActive(false); // Tắt nhạc khi thua
    }
}