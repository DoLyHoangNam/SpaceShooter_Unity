using UnityEngine;
public class LabC3_Controller : MonoBehaviour {
    public float speed = 10f;
    public Transform enemyTarget; // Kéo 1 viên Thiên thạch vào đây
    public int health = 100;
public UnityEngine.Events.UnityEvent<string> onHealthChanged;
    void Awake() { Debug.Log("Lab 1: Awake - Khoi tao"); }
    void Start() { Debug.Log("Lab 1: Start - Bat dau"); }
    void Update() {
        // Lab 2: Di chuyển WASD (Normalize để tránh đi chéo nhanh)
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 move = new Vector3(h, 0, v).normalized;
        transform.position += move * speed * Time.deltaTime;
        // Lab 3 & 4: Turret xoay nhìn target
        if (enemyTarget != null) {
            Vector3 dir = enemyTarget.position - transform.position;
            // Slerp xoay muot
           transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward, dir), Time.deltaTime * 5f);
            // SignedAngle tinh goc
            float angle = Vector3.SignedAngle(transform.forward, dir, Vector3.up);
            Debug.Log("Lab 4: Goc quay hien tai: " + angle);
        }
    }
    void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * 3f);
    }
}