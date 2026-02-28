using UnityEngine;
using UnityEngine.SceneManagement; // Bắt buộc phải có để chuyển cảnh

public class MenuHandler : MonoBehaviour
{
    public void RestartGame()
    {
        // Tải lại Scene có tên là "Battle" (Tên phải khớp với Scene bạn đang chơi)
        SceneManager.LoadScene("Battle");
    }
}   