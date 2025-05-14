using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelMenu : MonoBehaviour
{
    public Button[] buttons;

    private void Awake()
    {
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        // Kiểm tra nếu mảng buttons rỗng hoặc null
        if (buttons == null || buttons.Length == 0)
        {
            Debug.LogError("Mảng buttons chưa được gán hoặc rỗng trong LevelMenu!");
            return;
        }

        // Đặt tất cả button thành không tương tác
        for (int i = 0; i < buttons.Length; i++)
        {
            if (buttons[i] != null) // Kiểm tra button có tồn tại
            {
                buttons[i].interactable = false;
            }
        }

        // Mở khóa các button tương ứng với unlockedLevel
        for (int i = 0; i < Mathf.Min(unlockedLevel, buttons.Length); i++)
        {
            if (buttons[i] != null) // Kiểm tra button có tồn tại
            {
                buttons[i].interactable = true;
            }
        }
    }

    public void OpenLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}