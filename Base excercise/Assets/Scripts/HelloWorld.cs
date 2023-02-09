using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloWorld : MonoBehaviour
{
    public float speed = 4f;
    [SerializeField] private float  timer = 0;
    public Transform myTransform;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        myTransform.position = myTransform.position + new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
