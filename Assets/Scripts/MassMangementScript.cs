using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MassMangementScript : MonoBehaviour
{
    [SerializeField]
    Rigidbody rigidbody;
    [SerializeField]
    float density;
    //[SerializeField]
    //Transform transform;
    //Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.mass = GetVolume(transform.localScale) * density;
        //transform = GetComponent<Transform>();
        //scale = GetComponent<Transform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float Shrink()
    {
        if (rigidbody.mass <= 1.0f)
            return 0;
        float startingVolume = GetVolume(transform.localScale);
        transform.localScale = transform.localScale * 0.90f;
        float endingVolume = GetVolume(transform.localScale);
        float MassLoss = (startingVolume - endingVolume) * density;
        rigidbody.mass -= MassLoss;
        return MassLoss;
    }

    public void Enlarge(float _mass)
    {
        rigidbody.mass += _mass;
        float startingVolume = GetVolume(transform.localScale);
        float volumeToAdd = _mass / density;
        float endingVolume = Mathf.Abs(volumeToAdd + startingVolume);
        float scaleUp = endingVolume / startingVolume;
        transform.localScale = transform.localScale * Mathf.Pow(scaleUp, 1.0f/3.0f);
    }

    private float GetVolume(Vector3 dimensions)
    {
        return (dimensions.x * dimensions.y * dimensions.z);
    }
}
