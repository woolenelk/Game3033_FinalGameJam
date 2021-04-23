using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MassTransfer : MonoBehaviour
{
    [SerializeField]
    List<GameObject> ListOfMassObj = new List<GameObject>();
    [SerializeField]
    MassMangementScript myMass;
    [SerializeField]
    AudioSource GiveMass;
    [SerializeField]
    AudioSource TakeMass;

    bool Take = false, Give = false;

    private void Awake()
    {
        myMass = GetComponent<MassMangementScript>();
    }
    public void OnTakeMass(InputValue value)
    {
        Take = value.isPressed;
    }
    public void OnGiveMass(InputValue value)
    {
        Give = value.isPressed;
    }

    private void FixedUpdate()
    {
        if (Give && !Take)
        {
            foreach (var item in ListOfMassObj)
            {
                item.GetComponent<MassMangementScript>().Enlarge(myMass.Shrink());
                TakeMass.volume = 0;
                GiveMass.volume = 0.64f;

            }
        }
        else if (Take && !Give)
        {
            foreach (var item in ListOfMassObj)
            {
                myMass.Enlarge(item.GetComponent<MassMangementScript>().Shrink());
                TakeMass.volume = 0.64f;
                GiveMass.volume = 0;

            }
        }
        else
        {
            TakeMass.volume = 0;
            GiveMass.volume = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MassInteractable"))
        {
            ListOfMassObj.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MassInteractable"))
        {
            if (ListOfMassObj.Contains(other.gameObject))
            {
                ListOfMassObj.Remove(other.gameObject);
            }
        }
    }

}
