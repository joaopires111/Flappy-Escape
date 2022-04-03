using UnityEngine;
// Include the namespace required to use Unity UI and Input System
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{

	// Create public variables for player speed, and for the Text UI game objects
	public float speed;
	public GameObject pianoPanel;

	private float movementX;
	private float movementY;

	private Rigidbody rb;
	private int count;

	// At the start of the game..
	void Start()
	{
		// Assign the Rigidbody component to our private rb variable
		rb = GetComponent<Rigidbody>();

		// Mete painel do piano a falso quando começa
		pianoPanel.SetActive(false);
	}

	void FixedUpdate()
	{
		// Create a Vector3 variable, and assign X and Z to feature the horizontal and vertical float variables above
		Vector3 movement = new Vector3(movementX, 0.0f, movementY);

		//exemplo do professor
		//rb.AddForce(movement * speed);

		//velocidade sem acelaração (estilo rpg)
		rb.velocity = movement * speed;

	}

	void OnTriggerEnter(Collider other)
	{
        //Abre painel do piano
        if (other.gameObject.CompareTag("piano"))
		{
            pianoPanel.SetActive(true);
		}
	}
    private void OnTriggerExit(Collider other)
    {
		//Fecha painel do piano
		if (other.gameObject.CompareTag("piano"))
		{
			pianoPanel.SetActive(false);
		}
	}

    void OnMove(InputValue value)
	{
		Vector2 v = value.Get<Vector2>();

		movementX = v.x;
		movementY = v.y;

		//roda o jogador esquerda e direita (scale negativa dá flip)
		if(movementX > 0.0f)
        {
			transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
		} 
		else if (movementX < 0.0f)
        {
			transform.localScale = new Vector3(-0.5f, 0.5f, 0.5f);
		}

	}

}
