using UnityEngine;

public class Pendulum : MonoBehaviour
{
    [SerializeField] private float swingAngle = 45f; // Góc dao động tối đa (độ)
    [SerializeField] private float swingSpeed = 2f; // Tốc độ dao động
    [SerializeField] private Transform pivot; // Điểm neo (Pivot)
    [SerializeField] private float length = 2f; // Độ dài dây (khoảng cách từ pivot đến con lắc)

    private float startAngle;

    void Start()
    {
        // Lưu góc ban đầu (thường là 0 hoặc tùy thuộc vào thiết lập ban đầu)
        startAngle = 0f; // Giả sử con lắc bắt đầu thẳng đứng

        // Đặt vị trí ban đầu của con lắc dựa trên pivot và độ dài dây
        UpdatePendulumPosition(0f);
    }

    void Update()
    {
        // Tính góc dao động dựa trên thời gian và hàm sin
        float angle = swingAngle * Mathf.Sin(Time.time * swingSpeed);

        // Cập nhật vị trí con lắc để đu đưa quanh pivot
        UpdatePendulumPosition(angle);
    }

    void UpdatePendulumPosition(float angle)
    {
        // Chuyển đổi góc từ độ sang radian
        float angleRad = (startAngle + angle) * Mathf.Deg2Rad;

        // Tính vị trí mới của con lắc dựa trên pivot, độ dài dây và góc
        Vector3 offset = new Vector3(
            Mathf.Sin(angleRad) * length, // X = length * sin(angle)
            -Mathf.Cos(angleRad) * length, // Y = -length * cos(angle)
            0f
        );

        // Cập nhật vị trí con lắc
        transform.position = pivot.position + offset;

        // Cập nhật góc xoay để con lắc "hướng" đúng (tùy chọn)
        transform.rotation = Quaternion.Euler(0, 0, startAngle + angle);
    }

   
}