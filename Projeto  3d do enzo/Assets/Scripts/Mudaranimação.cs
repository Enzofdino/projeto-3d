using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mudaranimação : MonoBehaviour
{
    public Transform pos;
   
    public Animator controlador;

    void Start()
    {
        Debug.Log("Entrou no start");
        controlador = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Entrou no W");
            //mudar
            
            controlador.SetTrigger("Muda");

        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            controlador.SetTrigger("Desmuda");
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            controlador.SetTrigger("Block");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            controlador.SetTrigger("Chute");
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            controlador.SetTrigger("Posição");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            controlador.SetTrigger("Desmuda");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            controlador.SetTrigger("Desmuda");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            controlador.SetTrigger("Desmuda");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            controlador.SetTrigger("Desmuda");
        }



    }
}
