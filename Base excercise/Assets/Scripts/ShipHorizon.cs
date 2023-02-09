using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHorizon : MonoBehaviour
{
    public Transform simadoyra;
    public float speed = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + transform.forward * speed * Time.deltaTime;
        if (transform.position.x < simadoyra.position.x)
        {

        }
    }
}
