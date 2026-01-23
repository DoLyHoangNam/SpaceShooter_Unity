using UnityEngine;
using System.Collections;

public class BlinkingEffect : MonoBehaviour
{
    // Khoảng thời gian giữa mỗi lần bật/tắt (giây)
    public float blinkInterval = 0.2f;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Lấy thành phần Sprite Renderer từ đối tượng
        spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Bắt đầu vòng lặp nhấp nháy
        if (spriteRenderer != null)
        {
            StartCoroutine(BlinkRoutine());
        }
    }

    IEnumerator BlinkRoutine()
    {
        while (true)
        {
            // Đảo ngược trạng thái hiển thị của Sprite
            spriteRenderer.enabled = !spriteRenderer.enabled;
            
            // Đợi một khoảng thời gian rồi lặp lại
            yield return new WaitForSeconds(blinkInterval);
        }
    }
}