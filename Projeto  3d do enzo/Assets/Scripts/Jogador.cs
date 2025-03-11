using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public Rigidbody player;
    public float velocity = 5f;


    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
      

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-1, 0, 0) * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(1, 0, 0) * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0, 0, 1) * velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0, 0, -1) * velocity * Time.deltaTime;
        }

       
    }
}
