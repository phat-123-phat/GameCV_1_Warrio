using UnityEngine;
using UnityEngine.Tilemaps;

public class ScrollingTilemap : MonoBehaviour
{
    [SerializeField] private Transform[] tilemaps; // Mảng các tilemap
    [SerializeField] private float speed = 2f; // Tốc độ di chuyển
    [SerializeField] private float tilemapHeight = 10f; // Chiều cao của mỗi tilemap
    [SerializeField] private Camera mainCamera; // Camera chính

    private float cameraBottom; // Vị trí đáy của camera

    void Start()
    {
        // Lấy vị trí đáy của camera
        mainCamera = Camera.main;
        cameraBottom = mainCamera.transform.position.y - mainCamera.orthographicSize;
    }

    void Update()
    {
        // Di chuyển tất cả tilemap xuống dưới
        foreach (Transform tilemap in tilemaps)
        {
            tilemap.position += Vector3.down * speed * Time.deltaTime;

            // Kiểm tra nếu tilemap ra khỏi khung hình (dưới đáy camera)
            if (tilemap.position.y + tilemapHeight < cameraBottom)
            {
                // Di chuyển tilemap này lên vị trí cao nhất
                RepositionTilemap(tilemap);
            }
        }
    }

    void RepositionTilemap(Transform tilemap)
    {
        // Tìm tilemap cao nhất
        float highestY = tilemaps[0].position.y;
        foreach (Transform t in tilemaps)
        {
            if (t.position.y > highestY)
                highestY = t.position.y;
        }

        // Đặt tilemap này lên trên tilemap cao nhất
        tilemap.position = new Vector3(tilemap.position.x, highestY + tilemapHeight, tilemap.position.z);
    }
}