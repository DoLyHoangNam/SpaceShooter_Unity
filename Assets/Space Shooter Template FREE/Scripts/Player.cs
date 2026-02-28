using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject destructionFX;

    // LỖI 1: Thiếu dòng này. Phải khai báo biến để Unity biết chỗ mà kéo cái Panel vào.
    public GameObject gameOverPanel; 

    public static Player instance; 

    private void Awake()
    {
        if (instance == null) 
            instance = this;
    }

    public void GetDamage(int damage)   
    {
        Destruction();
    }    

    void Destruction()
    {
        Instantiate(destructionFX, transform.position, Quaternion.identity); 
        
        // Kiểm tra xem script PlayerMoving có tồn tại không để tắt điều khiển
        if (PlayerMoving.instance != null) {
            PlayerMoving.instance.DisableControl();
        }

        // Hiện bảng Game Over
        if (gameOverPanel != null) {
            gameOverPanel.SetActive(true);
        }

        Destroy(gameObject);
    }
}