using UnityEngine;

public class Enemy : MonoBehaviour {

    #region FIELDS
    [Header("Movement Settings")]
    public float speed = 5f; 

    [Header("Enemy Stats")]
    public int health = 3; // Nâng lên 3 máu theo Part 4
    
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

    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }
    }

    void ActivateShooting() 
    {
        if (Projectile != null && Random.value < (float)shotChance / 100)
        {                        
            Instantiate(Projectile, transform.position, Quaternion.identity);             
        }
    }

    // Hàm này giữ nguyên, dùng để nhận sát thương
    public void GetDamage(int damage) 
    {
        health -= damage;
        if (health <= 0)
            Destruction();
        else if (hitEffect != null)
            Instantiate(hitEffect, transform.position, Quaternion.identity, transform);
    }    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // 1. Nếu trúng đạn của Player
        if (collision.CompareTag("Laser")) 
        {
            GetDamage(1);
            Destroy(collision.gameObject); 
        }

        // 2. Nếu ĐÂM trúng Player (Đây là phần quan trọng của Part 4)
        if (collision.CompareTag("Player"))
        {
            // Tìm script máu của người chơi
            PlayerHealth player = collision.GetComponent<PlayerHealth>();
            if (player != null)
            {
                player.TakeDamage(1); // Gây sát thương cho người chơi
            }
            
            // Kẻ địch tông xong cũng nổ luôn
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