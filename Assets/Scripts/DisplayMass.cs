using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayMass : MonoBehaviour
{
    [SerializeField]
    List<TextMeshProUGUI> textMeshProUGUIs = new List<TextMeshProUGUI>();
    Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (var item in textMeshProUGUIs)
        {
            item.text = ((int)(rigidbody.mass)).ToString();
        }
    }
}
