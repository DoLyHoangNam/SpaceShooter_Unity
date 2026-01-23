using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject laserPrefab; // Ô này bạn đã kéo đạn vào rồi, cứ giữ nguyên
    public float moveSpeed = 10f;

    void Update()
    {
        // 1. DI CHUYỂN THEO CHUỘT
        // Lấy vị trí chuột trong không gian màn hình và chuyển sang không gian thế giới (World Point)
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0; // Đảm bảo tàu không bị bay mất theo trục Z

        // Di chuyển tàu mượt mà tới vị trí chuột
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, moveSpeed * Time.deltaTime);

        // 2. CLICK CHUỘT TRÁI ĐỂ BẮN (0 là chuột trái, 1 là chuột phải)
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Tạo viên đạn tại vị trí của tàu
        Instantiate(laserPrefab, transform.position, Quaternion.identity);
    }
}