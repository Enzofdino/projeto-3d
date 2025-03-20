using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    static public Jogador instance;

    private void Awake()
    {
        instance = this;
    }
    public Rigidbody player;
    public float velocity = 1f;
    public float rotationSpeed = 100f;
    public AudioClip moedasom;
    public GameObject particulaPrefab; 
    public GameObject moedaPrefab;
    public GameObject moedaAtual;
    public Vector3 spawnAreaMin = new Vector3(-8, 4, 14); 
    public Vector3 spawnAreaMax = new Vector3(8, 4, 14);   

    private void Start()
    {
        player = GetComponent<Rigidbody>();
        if (moedaPrefab == null)
        {
            Debug.LogError("🚨 ERRO: Moeda Prefab não atribuída no Inspector!");
            return;
        }

        SpawnMoeda();
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        float rotationChange = 0;

        bool moveLeft = Input.GetKey(KeyCode.A);
        bool moveRight = Input.GetKey(KeyCode.D);
        bool moveForward = Input.GetKey(KeyCode.W);
        bool moveBackward = Input.GetKey(KeyCode.S);

        
        if (moveLeft)
        {
            rotationChange = -rotationSpeed * Time.deltaTime;
        }
        else if (moveRight)
        {
            rotationChange = rotationSpeed * Time.deltaTime;
        }
        else
        {
            rotationChange = 0;
        }

       
        if (moveForward)
        {
            moveDirection = transform.forward;
        }
        if (moveBackward)
        {
            moveDirection = -transform.forward;
        }

       
        if (moveDirection != Vector3.zero)
        {
            transform.position += moveDirection * velocity * Time.deltaTime;
        }

       
        if (rotationChange != 0)
        {
            transform.Rotate(0, rotationChange, 0);
        }
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Moeda"))
        {
            Vector3 moedaPosicao = other.transform.position;

            gameObject.GetComponent<AudioSource>().clip = moedasom;
            gameObject.GetComponent<AudioSource>().Play();


            Destroy(other.gameObject);

            if (particulaPrefab != null)
            {
                GameObject particula = Instantiate(particulaPrefab, moedaPosicao, Quaternion.identity);
                ParticleSystem ps = particula.GetComponent<ParticleSystem>();

                if (ps != null)
                {
                    ps.Play();
                }

                Destroy(particula, 2f);

                moedaAtual = null;
                StartCoroutine(RespawnMoeda());
            }

        }
    }


    private void SpawnMoeda()
    {
        if (moedaPrefab == null)
        {
            Debug.LogError("🚨 ERRO: moedaPrefab não foi atribuída no Inspector!");
            return;
        }
        if (moedaAtual != null) return;

        Vector3 spawnPos = new Vector3(
            Random.Range(spawnAreaMin.x, spawnAreaMax.x),
            spawnAreaMin.y,
            Random.Range(spawnAreaMin.z, spawnAreaMax.z)  
        );

        moedaAtual = Instantiate(moedaPrefab, spawnPos, Quaternion.identity);
        if (moedaAtual == null)
        {
            Debug.LogError("🚨 ERRO: A moeda não foi instanciada corretamente!");
        }
    }

    private IEnumerator RespawnMoeda()
    {
        yield return new WaitForSeconds(1f); 
        SpawnMoeda();
    }
}
