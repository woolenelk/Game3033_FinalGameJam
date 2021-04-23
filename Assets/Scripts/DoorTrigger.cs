using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField]
    List<PuzzleTrigger> puzzleTriggers = new List<PuzzleTrigger>();
    [SerializeField]
    bool pass = false;
    [SerializeField]
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var item in puzzleTriggers)
        {
            if (!item.triggered)
            {
                pass = false;
                if (animator.GetInteger("DoorState") == 1)
                    animator.SetInteger("DoorState", 2);
                return;
            }
        }
        pass = true;
        animator.SetInteger("DoorState", 1);
    }
}
