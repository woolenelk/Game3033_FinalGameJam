using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinGameTrigger : MonoBehaviour
{
    [SerializeField]
    bool specialWin;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 1;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            if (specialWin)
                SceneManager.LoadScene("SpecialGameOver");
            else
                SceneManager.LoadScene("GameOver");
        }
    }
}
