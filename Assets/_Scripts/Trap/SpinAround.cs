using UnityEngine;

public class SpinAround : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 90f; // Tốc độ quay (độ/giây)
    [SerializeField] private Transform pivot; // Điểm neo (Pivot)
    [SerializeField] private float length = 2f; // Khoảng cách từ pivot đến trap
    [SerializeField] private bool clockwise = true; // Hướng quay: true = thuận chiều, false = ngược chiều

    private float currentAngle;

    void Start()
    {
        // Đặt góc ban đầu
        currentAngle = 0f;

        // Đặt vị trí ban đầu của trap
        UpdateTrapPosition();
    }

    void Update()
    {
        // Cập nhật góc quay dựa trên thời gian
        float angleDelta = rotationSpeed * Time.deltaTime * (clockwise ? -1f : 1f); // Đổi dấu để điều chỉnh hướng
        currentAngle += angleDelta;

        // Cập nhật vị trí và góc của trap
        UpdateTrapPosition();
    }

    void UpdateTrapPosition()
    {
        // Chuyển đổi góc từ độ sang radian
        float angleRad = currentAngle * Mathf.Deg2Rad;

        // Tính vị trí mới của trap dựa trên pivot, khoảng cách và góc
        Vector3 offset = new Vector3(
            Mathf.Sin(angleRad) * length, // X = length * sin(angle)
            -Mathf.Cos(angleRad) * length, // Y = -length * cos(angle)
            0f
        );

        // Cập nhật vị trí trap
        transform.position = pivot.position + offset;

        // Cập nhật góc xoay để trap "hướng" đúng (tùy chọn)
        transform.rotation = Quaternion.Euler(0, 0, currentAngle);
    }
}