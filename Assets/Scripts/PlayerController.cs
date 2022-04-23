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
    public GameObject desbloquear;
    public GameObject Nota335;


    // Porta masmorra
    public GameObject cadeadoMasmorra;
    public GameObject abrirPorta2TXT;
    public GameObject portamasmorra;

    public GameObject porta;
    public GameObject cadeadoObj;
    public GameObject chave1;
    private bool apanhouchave1;
    public GameObject chaveIncorreta;
    public GameObject apanharChaveTXT;

    public GameObject quadro1;
    public GameObject quadro2;

    private float movementX;
    private float movementZ;

    private int quadro;

    private Rigidbody rb;
    private int acertadas;

    private bool entrouarea;
    private bool entrouareacadeado;
    private bool entrouareachave;
    private bool entrouareaporta2;

    ArrayList Resultado = new ArrayList();

    // At the start of the game..
    void Start()
    {
        acertadas = 0;

        entrouarea = false;
        entrouareacadeado = false;
        entrouareachave = false;

        apanhouchave1 = false;

        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        // Mete painel do piano a falso quando começa
        pianoPanel.SetActive(false);
        clicah.SetActive(false);
        desbloquear.SetActive(false);
        chaveIncorreta.SetActive(false);
        Nota335.SetActive(false);
        cadeadoObj.SetActive(true);
        quadro1.SetActive(false);
        quadro2.SetActive(false);
        chave1.SetActive(true);
        apanharChaveTXT.SetActive(false);

        // Porta masmorra
        cadeadoMasmorra.SetActive(true);
        abrirPorta2TXT.SetActive(false);
        entrouareaporta2 = false;

        quadro = Random.Range(1, 3);
        switch (quadro)
        {
            case 1:
                Resultado.Add(3);
                Resultado.Add(3);
                Resultado.Add(5);
                quadro1.SetActive(true);
                quadro2.SetActive(false);
                break;
            case 2:
                Resultado.Add(1);
                Resultado.Add(2);
                Resultado.Add(3);
                quadro1.SetActive(false);
                quadro2.SetActive(true);
                break;
            default:
                quadro1.SetActive(true);
                quadro2.SetActive(false);
                break;
        }
    }

    void OnGUI()
    {
        if (Input.GetKeyDown("e") && entrouarea == true)
        {
            pianoPanel.SetActive(true);
        }
        if (Input.GetKeyDown("e") && entrouareacadeado == true)
        {
            if (apanhouchave1)
            {
                desbloquear.SetActive(false);
                entrouareacadeado = false;
                chaveIncorreta.SetActive(false);
                cadeadoObj.SetActive(false);
                porta.transform.Rotate(0f, 90f, 0f);
            } 
            if (apanhouchave1 == false)
            {
                desbloquear.SetActive(false);
                chaveIncorreta.SetActive(true);
            }
        }
        if (Input.GetKeyDown("e") && entrouareachave == true)
        {
            apanharChaveTXT.SetActive(false);
            chave1.SetActive(false);
            apanhouchave1 = true;
        }
        if (Input.GetKeyDown("e") && entrouareaporta2 == true)
        {
            abrirPorta2TXT.SetActive(false);
            entrouareaporta2 = false;
            cadeadoMasmorra.SetActive(false);
            portamasmorra.transform.Rotate(0f, 90f, 0f);
        }
    }

    void FixedUpdate()
    {
        // Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
        Vector3 movement = new Vector3(movementX, 0.0f, movementZ);

        //exemplo do professor
        //rb.AddForce(movement * speed);

        //velocidade sem acelaração (estilo rpg)

        //rb.position = new Vector3(3f, 20f, 3f);

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
        if (other.gameObject.CompareTag("cadeado"))
        {
            desbloquear.SetActive(true);
            entrouareacadeado = true;
        }
        if (other.gameObject.CompareTag("chave"))
        {
            apanharChaveTXT.SetActive(true);
            entrouareachave = true;
        }
        if (other.gameObject.CompareTag("cadeadomasmorra"))
        {
            abrirPorta2TXT.SetActive(true);
            entrouareaporta2 = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        //Fecha painel do piano
        if (other.gameObject.CompareTag("piano"))
        {
            pianoPanel.SetActive(false);
            clicah.SetActive(false);
            entrouarea = false;
        }
        if (other.gameObject.CompareTag("cadeado"))
        {
            desbloquear.SetActive(false);
            chaveIncorreta.SetActive(false);
            entrouareacadeado = false;
        }
        if (other.gameObject.CompareTag("chave"))
        {
            apanharChaveTXT.SetActive(false);
            entrouareachave = false;
        }
        if (other.gameObject.CompareTag("cadeadomasmorra"))
        {
            abrirPorta2TXT.SetActive(false);
            entrouareaporta2 = false;
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
