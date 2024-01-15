using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    //public Vector3 positionChange;
    public float positionMin = -5f;
    public float positionMax = 5f;

    // Start is called before the first frame update
    void Start()
    {
        positionMin = transform.position.x - 5;
        positionMax = transform.position.x + 5;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += positionChange;
        //transform.position = new Vector3 (positionMin, positionMax, positionMin);
        transform.position = new Vector3(Mathf.PingPong(Time.time * 2, positionMax - positionMin) + positionMin, transform.position.y, transform.position.z);
    }
}
