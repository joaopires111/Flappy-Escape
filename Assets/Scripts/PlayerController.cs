using UnityEngine;
using System.Collections;
// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    // Create public variables for player speed, and for the Text UI game objects
    public float speed;
    public GameObject pianoPanel;
    public GameObject clicah;
    public GameObject Nota335;

    private float movementX;
    private float movementZ;

    private Rigidbody rb;
    private int acertadas;
    private bool entrouarea;

    ArrayList Resultado = new ArrayList();

    // At the start of the game..
    void Start()
    {
        acertadas = 0;
        Resultado.Add(3);
        Resultado.Add(3);
        Resultado.Add(5);

        entrouarea = false;
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        // Mete painel do piano a falso quando começa
        pianoPanel.SetActive(false);
        clicah.SetActive(false);
        Nota335.SetActive(false);
    }

    void OnGUI()
    {
        if (Input.GetKeyDown("e") && entrouarea == true)
        {
            pianoPanel.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        // Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
        Vector3 movement = new Vector3(movementX, 0.0f, movementZ);

        //exemplo do professor
        //rb.AddForce(movement * speed);

        //velocidade sem acelaração (estilo rpg)
        rb.velocity = movement * speed;

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("piano"))
        {
            //Abre painel do piano
            clicah.SetActive(true);
            entrouarea = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Fecha painel do piano
        if (other.gameObject.CompareTag("piano"))
        {
            pianoPanel.SetActive(false);
            clicah.SetActive(false);
        }
    }

    void OnMove(InputValue value)
    {
        Vector2 v = value.Get<Vector2>();

        movementX = v.x;
        movementZ = v.y;

        //roda o jogador esquerda e direita (scale negativa dá flip)
        if (movementX > 0.0f)
        {
            transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        }
        else if (movementX < 0.0f)
        {
            transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
        }

    }

    public void clicatecla(int numerotecla)
    {
        if (acertadas != 3)
        {
            if (numerotecla == (int)Resultado[acertadas])
            {
                acertadas++;
                Debug.Log(acertadas);
                if (acertadas == 3)
                {
                    Nota335.SetActive(true);
                }
            }
            else
            {
                acertadas = 0;
            }
        }

    }

}
