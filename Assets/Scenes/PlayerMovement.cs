using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 30f;
    public GameObject laserPrefab; 

    void Update()
    {
        // 1. DI CHUYỂN
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(h, v, 0);
        transform.position += direction.normalized * moveSpeed * Time.deltaTime;

        // 2. GIỚI HẠN BIÊN
        float xPos = Mathf.Clamp(transform.position.x, -8.5f, 8.5f);
        float yPos = Mathf.Clamp(transform.position.y, -4.5f, 4.5f);
        transform.position = new Vector3(xPos, yPos, 0);

        // 3. BẮN ĐẠN
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        }
    }
}