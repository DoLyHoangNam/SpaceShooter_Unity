using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    #region FIELDS
    [Header("Movement Settings")]
    public float speed = 5f; // Thêm tốc độ di chuyển

    [Header("Enemy Stats")]
    public int health = 1;

    [Tooltip("Enemy's projectile prefab")]
    public GameObject Projectile;

    [Tooltip("VFX prefab generating after destruction")]
    public GameObject destructionVFX;
    public GameObject hitEffect;
    
    [HideInInspector] public int shotChance = 50; 
    [HideInInspector] public float shotTimeMin = 1f, shotTimeMax = 3f; 
    #endregion

    private void Start()
    {
        Invoke("ActivateShooting", Random.Range(shotTimeMin, shotTimeMax));
    }

    // --- ĐÂY LÀ PHẦN QUAN TRỌNG ĐỂ KẺ ĐỊCH BAY XUỐNG ---
    void Update()
    {
        // Di chuyển xuống dưới
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Tự hủy khi rơi quá thấp
        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }

    void ActivateShooting() 
    {
        if (Projectile != null && Random.value < (float)shotChance / 100)
        {                        
            Instantiate(Projectile, gameObject.transform.position, Quaternion.identity);             
        }
    }

    public void GetDamage(int damage) 
    {
        health -= damage;
        if (health <= 0)
            Destruction();
        else
            Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Khi đạn của người chơi bắn trúng kẻ địch
        if (collision.tag == "Laser") // Hãy đảm bảo bạn đã đặt Tag cho Laser là "Laser"
        {
            GetDamage(1);
            Destroy(collision.gameObject); // Phá hủy viên đạn khi trúng địch
        }

        // Khi kẻ địch đâm vào người chơi
        if (collision.tag == "Player")
        {
            // Tạm thời cho người chơi mất máu hoặc nổ luôn
            Destruction();
        }
    }

    void Destruction()                           
    {        
        if (destructionVFX != null) 
            Instantiate(destructionVFX, transform.position, Quaternion.identity); 
        Destroy(gameObject);
    }
}