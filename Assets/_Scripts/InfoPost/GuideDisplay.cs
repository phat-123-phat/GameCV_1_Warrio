using UnityEngine;
using TMPro;
using System.Collections;

public class GuideDisplay : MonoBehaviour
{
    [SerializeField] private GameObject guidePanel;
    [SerializeField] private TextMeshProUGUI guideText; 
    [SerializeField] private string guideContent; 
    [SerializeField] private Animator guideAnimator;
    [SerializeField] private float hideDelay = 1f; 
    [SerializeField] private int maxShowCount = 3;
    [SerializeField] private bool count;

    private int currentShowCount = 0;
    private Coroutine hideCoroutine;

    private void Start()
    {
        // Ẩn hộp thoại khi bắt đầu
        if (guidePanel != null)
            guidePanel.SetActive(false);
    }

    public void ShowGuide()
    {
        // Kiểm tra nếu đã đạt giới hạn số lần hiển thị
        if (currentShowCount >= maxShowCount && count)
        {
            return;
        }

        if (guidePanel != null && guideText != null)
        {
            

            // Dừng coroutine ẩn nếu đang chạy
            if (hideCoroutine != null)
                StopCoroutine(hideCoroutine);

            guideText.text = guideContent; // Gán nội dung
            guidePanel.SetActive(true); // Hiển thị panel

            // Kích hoạt animation hiển thị (nếu có Animator)
            if (guideAnimator != null)
                guideAnimator.SetTrigger("Show");
        }
    }

    public void HideGuide()
    {
        
        if (guidePanel != null)
            hideCoroutine = StartCoroutine(DelayedHide());

        // Tăng số lần hiển thị
        currentShowCount++;
    }

    private IEnumerator DelayedHide()
    {
        // Kích hoạt animation ẩn (nếu có Animator)
        if (guideAnimator != null)
            guideAnimator.SetTrigger("Hide");

        // Chờ thời gian delay
        yield return new WaitForSeconds(hideDelay);

        // Ẩn panel sau khi chờ
        if (guidePanel != null)
            guidePanel.SetActive(false);
    }
}