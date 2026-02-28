using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject laserPrefab; 
    public float moveSpeed = 10f;

    // BƯỚC 1: Khai báo biến để chứa AudioSource
    private AudioSource audioSource;

    void Start()
    {
        // Lấy thành phần AudioSource đã gắn trên tàu Player
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // 1. DI CHUYỂN THEO CHUỘT
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; 
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        // 2. CLICK CHUỘT TRÁI ĐỂ BẮN
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Tạo viên đạn tại vị trí của tàu
        Instantiate(laserPrefab, transform.position, Quaternion.identity);

        // BƯỚC 2: Phát âm thanh khi bắn
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}