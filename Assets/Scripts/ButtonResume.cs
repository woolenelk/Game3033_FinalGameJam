using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonResume : MonoBehaviour
{
    [SerializeField]
    Canvas parentCanvas;

    public void OnResumePressed()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        parentCanvas.gameObject.SetActive(false);

    }
}
