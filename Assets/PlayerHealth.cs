using UnityEngine;
using UnityEngine.UI; // QUAN TRỌNG: Phải có dòng này để dùng được Slider

public class PlayerHealth : MonoBehaviour 
{
    public int health = 5;
    public Slider healthSlider; // Ô để kéo thanh Slider vào
    public GameObject explosionPrefab;

    void Start() {
        // Lúc bắt đầu game, đặt thanh máu đầy
        if (healthSlider != null) {
            healthSlider.maxValue = health;
            healthSlider.value = health;
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        
        // Cập nhật thanh máu trên màn hình
        if (healthSlider != null) {
            healthSlider.value = health;
        }

        Debug.Log("Máu Player còn: " + health);

        if (health <= 0) {
            Die();
        }
    }

    void Die() {
        if (explosionPrefab != null) {
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);
        Debug.Log("GAME OVER!");
    }
}