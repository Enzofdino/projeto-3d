using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mudaranimação : MonoBehaviour
{
  static public Mudaranimação instance;
    private void Awake()
    {
        instance = this;
    }
    public Transform pos;
    public AudioClip pulosom;
    public AudioClip andar;
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
        else if (Input.GetKey(KeyCode.X))
        {
            controlador.SetTrigger("Dance");
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
        else if (Input.GetKey(KeyCode.W))
        {
            controlador.SetTrigger("Andar para frente");
            Jogador.instance.velocity = 2f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            controlador.SetTrigger("Andar para frente");
            Jogador.instance.velocity = 2f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            controlador.SetTrigger("Back");
            Jogador.instance.velocity = 2f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            controlador.SetTrigger("Andar para frente");
            Jogador.instance.velocity = 2f;
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            controlador.SetTrigger("Pular"); 
            StartCoroutine(PularComDelay()); 
        }

    
        if (Input.GetKey(KeyCode.None)) 
        {
            controlador.SetTrigger("Posição");
        }
        IEnumerator PularComDelay()
        {
            yield return new WaitForSeconds(0.5f); 
            transform.position += new Vector3(0, 50, 0) * Jogador.instance.velocity * Time.deltaTime;
            gameObject.GetComponent<AudioSource>().clip = pulosom;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            gameObject.GetComponent<AudioSource>().clip = andar;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            gameObject.GetComponent<AudioSource>().clip = andar;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            gameObject.GetComponent<AudioSource>().clip = andar;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameObject.GetComponent<AudioSource>().clip = andar;
            gameObject.GetComponent<AudioSource>().Play();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            controlador.SetTrigger("Correr");
            Jogador.instance.velocity = 5f;
        }
       



    }
}
