using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class OpenSceneScript : MonoBehaviour
{
    [SerializeField]
    string levelName;
    
    public void OpenLevel()
    {
        SceneManager.LoadScene(levelName);
    }

    public void Quite()
    {
        Application.Quit();
    }
}
