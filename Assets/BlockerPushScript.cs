using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockerPushScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 force = other.gameObject.transform.position - transform.position + new Vector3(0, 2, 0);
            //Debug.Log(force.ToString());
            force = force.normalized;
            Debug.Log(force.ToString());
            force *= 20;
            other.gameObject.GetComponent<Rigidbody>().AddForce(force, ForceMode.Impulse);
        }
    }
}
