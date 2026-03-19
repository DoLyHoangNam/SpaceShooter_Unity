using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // Waypoint class for marking positions in the flight path
}

public class FlyPath : MonoBehaviour
{
    // 1. Khai báo mảng - Phải nằm ở đầu class
    public Waypoint[] waypoints; 

    // 2. Vẽ đường nối trong Scene
    private void OnDrawGizmos()
    {
        if (waypoints == null || waypoints.Length < 2) return;
        
        Gizmos.color = Color.green;
        for (int i = 0; i < waypoints.Length - 1; i++)
        {
            if (waypoints[i] != null && waypoints[i + 1] != null)
                Gizmos.DrawLine(waypoints[i].transform.position, waypoints[i + 1].transform.position);
        }
    }

    // 3. Indexer - Lấy vị trí theo chỉ số [index]
    public Vector3 this[int index]
    {
        get 
        { 
            if (waypoints != null && index < waypoints.Length)
                return waypoints[index].transform.position; 
            return Vector3.zero;
        }
    }
}