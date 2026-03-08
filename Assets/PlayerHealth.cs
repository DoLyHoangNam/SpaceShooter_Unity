using UnityEngine;
using UnityEngine.UI;
using System; // BẮT BUỘC: Thêm dòng này để dùng được Action

public class PlayerHealth : MonoBehaviour 
{
    public int health = 5;
    public Slider healthSlider; 
    public GameObject explosionPrefab;

    // THÊM DÒNG NÀY (Theo trang 4 của Demo 6):
    // Đây là "sự kiện" để thông báo cho BattleFlow biết khi bạn chết
    public Action onDead; 

    void Start() {
        if (healthSlider != null) {
            healthSlider.maxValue = health;
            healthSlider.value = health;
        }
    }

    public void TakeDamage(int damage) {
        health -= damage;
        
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

        // THÊM DÒNG NÀY (Theo trang 4 của Demo 6):
        // Phát tín hiệu "Tôi đã chết rồi!"
        onDead?.Invoke();

        Destroy(gameObject);
        Debug.Log("GAME OVER!");
    }
}