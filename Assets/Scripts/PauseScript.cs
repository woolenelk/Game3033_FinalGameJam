using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseScript : MonoBehaviour
{
    [SerializeField]
    Canvas PauseCanvas;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        StartCoroutine(CursorLock());
    }

    IEnumerator CursorLock()
    {
        yield return new WaitForSeconds(0.5f);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void OnPause(InputValue value)
    {
        if (PauseCanvas.gameObject.activeInHierarchy)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PauseCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            PauseCanvas.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
