using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{

    [SerializeField]
    int maxSceneIndex = 3;

    public Animator animator;

    private int levelToLoad;

    public void Died()
    {
        FadeToLevel(1);
    }

    public void Restart()
    {
        levelToLoad = 0;
        animator.SetTrigger("FadeOut");
    }
    public void FadeToLevel (int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    public void FadetoLevelRandom() {
        
        levelToLoad = Random.Range(1, maxSceneIndex);
        Debug.Log(string.Format("Changing level: {0}",levelToLoad));
        animator.SetTrigger("FadeOut");
    }

    
}
