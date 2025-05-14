using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    [SerializeField] private string nextSceneName;
    [SerializeField] Animator trasitionAnim;
 
    
    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel());
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LoadNextScene();
            UnlockNewLevel();
            AudioManager.instance.PlayerSFX("MissionCompleted");
        }
    }

    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel",1 )+ 1);
            PlayerPrefs.Save();
        }
    }

    IEnumerator LoadLevel()
    {
        
        trasitionAnim.SetTrigger("End");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextSceneName);
        trasitionAnim.SetTrigger("Start");
        
    }    
}
