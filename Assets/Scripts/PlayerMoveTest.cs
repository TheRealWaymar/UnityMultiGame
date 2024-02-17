using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMoveTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)))
        {
            transform.position += transform.forward * Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.S)))
        {
            transform.position -= transform.forward * Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.D)))
        {
            transform.position += transform.right * Time.deltaTime;
        }
        if ((Input.GetKey(KeyCode.A)))
        {
            transform.position -= transform.right * Time.deltaTime;
        }
        
    }
}
