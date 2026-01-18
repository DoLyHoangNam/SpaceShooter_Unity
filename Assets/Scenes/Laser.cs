using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 12f; // Tốc độ bay của đạn

    void Update()
{
    // Giữ nguyên lệnh bay lên
    transform.Translate(Vector3.up * speed * Time.deltaTime);

    // Sửa số 8f thành 5.5f để đạn xóa ngay khi vừa khuất mắt
    if (transform.position.y > 4.5f)
    {
        Destroy(gameObject);
    }
}
    }
