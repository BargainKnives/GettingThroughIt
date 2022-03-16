using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tracker : MonoBehaviour
{
    public GameObject target;
    public float smoothSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, target.transform.position, smoothSpeed);
        }
    }
}
