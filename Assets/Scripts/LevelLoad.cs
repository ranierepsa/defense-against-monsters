using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] int delayAfterSplashScreen = 3;
    int currentLevel;

    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (currentLevel == 0)
            StartCoroutine(LoadStartScreenWithDelay(delayAfterSplashScreen));
    }

    IEnumerator LoadStartScreenWithDelay(int delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        SceneManager.LoadScene(currentLevel + 1);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }
}
