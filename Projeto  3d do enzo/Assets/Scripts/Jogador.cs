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
    public float velocity = 5f;
    public float rotationSpeed = 100f;

    private void Start()
    {
        player = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 moveDirection = Vector3.zero;
        float rotationChange = 0;

        bool moveLeft = Input.GetKey(KeyCode.A);
        bool moveRight = Input.GetKey(KeyCode.D);
        bool moveForward = Input.GetKey(KeyCode.W);
        bool moveBackward = Input.GetKey(KeyCode.S);

        // 🛠 Ajuste importante: Agora a rotação só muda quando pressionamos A ou D
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
            rotationChange = 0; // 🚀 Garante que não há rotação quando nenhuma tecla está pressionada
        }

        // Define a direção do movimento
        if (moveForward)
        {
            moveDirection = transform.forward;
        }
        if (moveBackward)
        {
            moveDirection = -transform.forward;
        }

        // Move o personagem
        if (moveDirection != Vector3.zero)
        {
            transform.position += moveDirection * velocity * Time.deltaTime;
        }

        // Aplica a rotação apenas se necessário
        if (rotationChange != 0)
        {
            transform.Rotate(0, rotationChange, 0);
        }
       
    }
}
