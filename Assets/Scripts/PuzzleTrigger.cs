using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PuzzleTrigger : MonoBehaviour
{
    [SerializeField]
    List<Rigidbody> rigidbodies = new List<Rigidbody>();
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    int triggerCondition;
    public bool triggered => pass;
    [SerializeField]
    bool pass = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("MassInteractable"))
        {
            rigidbodies.Add(other.gameObject.GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (rigidbodies.Contains(other.gameObject.GetComponent<Rigidbody>()))
        {
            rigidbodies.Remove(other.gameObject.GetComponent<Rigidbody>());
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        text.text = triggerCondition.ToString();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float totalWeight = 0;
        foreach (var item in rigidbodies)
        {
            totalWeight += item.mass;
        }

        if (totalWeight >= triggerCondition)
        {
            pass = true;
            text.color = Color.green;
        }
        else
        {
            pass = false;
            text.color = Color.red;
        }
    }
}
