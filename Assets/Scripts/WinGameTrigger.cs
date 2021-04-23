using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinGameTrigger : MonoBehaviour
{
    [SerializeField]
    bool specialWin = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (specialWin)
                SceneManager.LoadScene("SpecialGameOver");
            SceneManager.LoadScene("GameOver");
        }
    }
}
