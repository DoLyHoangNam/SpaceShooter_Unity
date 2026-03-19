using UnityEngine;

public class FlyPathAgent : MonoBehaviour
{
    public FlyPath flyPath;
    public float flySpeed = 5f;
    private int nextIndex = 1;

    void Start()
    {
        // Kiểm tra an toàn trước khi gán vị trí đầu tiên
        if (flyPath != null && flyPath.waypoints != null && flyPath.waypoints.Length > 0)
        {
            transform.position = flyPath[0];
        }
    }

    void Update()
    {
        // Nếu thiếu Path hoặc đi hết điểm thì dừng/hủy
        if (flyPath == null || flyPath.waypoints == null) return;

        if (nextIndex >= flyPath.waypoints.Length)
        {
            Destroy(gameObject);
            return;
        }

        // Di chuyển tới điểm tiếp theo
        Vector3 targetPos = flyPath[nextIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPos, flySpeed * Time.deltaTime);

        // Nếu đã đến sát điểm hiện tại, chuyển sang điểm kế tiếp
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {
            nextIndex++;
        }
    }
}