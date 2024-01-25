using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb; //variable para el rigidbody
	private int count; //contador
    private float movementX; //variables para el movimiento en X
    private float movementY; //variables para el movimiento en Y
    public float speed = 0; //velocidad del jugador
	public TextMeshProUGUI countText; //variable para el texto del contador
	public GameObject winTextObject; //variable para el texto de ganar
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>(); //obtiene el componente rigidbody
		count = 0; //Inicializa el contador
		SetCountText(); //El contador comienza en 0
		winTextObject.SetActive(false); //El texto de ganar no se muestra
    }
    
    // This function is called when the object becomes enabled and active.
    void OnMove (InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>(); //obtiene el vector de movimiento
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }
    
    // This function is called when the behaviour becomes disabled () or inactive.
    void SetCountText() 
    {
	    countText.text =  "Count: " + count.ToString();
	    
	    //Muestra el texto de ganar si todos los objetos han sido recogidos
	    if (count >= 12)
	    {
		    winTextObject.SetActive(true);
	    }
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY); //crea el vector de movimiento
        rb.AddForce(movement * speed);; //aplica la fuerza al rigidbody aplicando la velocidad
    }
	
	void OnTriggerEnter(Collider other) 
    {
 	// Comprueba si el objeto colisionado tiene la etiqueta "PickUp"
 	if (other.gameObject.CompareTag("PickUp")) 
        {
 			// Desaparece el objeto colisionado
            other.gameObject.SetActive(false);

			// Incrementa el contador
			count=count+1;
			
			//Actualiza el contador
			SetCountText();

        }
    }
}
