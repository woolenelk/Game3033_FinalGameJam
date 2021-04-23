using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseScript : MonoBehaviour
{
    [SerializeField]
    Canvas PauseCanvas;

    public void OnPause(InputValue value)
    {
        if (PauseCanvas.gameObject.activeInHierarchy)
        {
            PauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            PauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
