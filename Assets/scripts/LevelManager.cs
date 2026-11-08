using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour
{
    
   public void ReloadScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(index);
    }
    public void NextScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        int numScenes = SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene((index + 1) % numScenes);
    }
    public void PreviousScene()
    {
        int index = SceneManager.GetActiveScene().buildIndex;
        int numScenes = SceneManager.sceneCountInBuildSettings;
        --index;
        if (index < 0)
        {
            index = numScenes - 1;
        }
        SceneManager.LoadScene(index);
    }

}
