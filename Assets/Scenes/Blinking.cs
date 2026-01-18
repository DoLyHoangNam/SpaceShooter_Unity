using UnityEngine;

public class Blinking : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Lấy thành phần hình ảnh của đối tượng
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Đảo ngược trạng thái hiển thị: Đang hiện thì ẩn, đang ẩn thì hiện
        // Điều này tạo ra hiệu ứng nhấp nháy
        spriteRenderer.enabled = !spriteRenderer.enabled;
    }
}