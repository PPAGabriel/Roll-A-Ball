# Roll a Ball

## 1. El Player se mueva de una manera diferente, prueba a cambiar parámetros del rigibody, la fórmula de la fuerza que se aplica, etc:

Para este apartado, se puede alterar la formula que usamos para que nuestro Player se mueva de manera distinta:

```csharp

	public float jumpForce = 5.0f; // Nueva variable para la fuerza del salto
	
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY); //crea el vector de movimiento
        rb.AddForce(movement * speed);; //aplica la fuerza al rigidbody aplicando la velocidad
        
        // Salto al presionar la barra espaciadora
        if (Input.GetKeyDown(KeyCode.Space))
        {
	        Jump();
        }
    }

    void Jump()
    {
	    // Comprueba si el objeto está en el suelo antes de saltar
	    if (Mathf.Abs(rb.velocity.y) < 0.01f)
	    {
		    // Aplica una fuerza hacia arriba para simular el salto
		    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
	    }
    }
```

De esta manera, independiente al movimiento que tenga el Player, al presionar la "barra espaciadora" el Player saltará.

> [!IMPORTANT]
>Cabe destacar que si manipulamos la masa de nuestro Player, la fuerza del salto deberá ser mayor para que el salto sea más alto.

Con una masa de 1:
![Screenshot_20240125_101459.png](Media%2FScreenshot_20240125_101459.png)

Con una masa de 0.2:
![Screenshot_20240125_101558.png](Media%2FScreenshot_20240125_101558.png)

## 2. La cámara haga un seguimiento diferente al Player, como sería en primera persona? Que otro seguimiento se te ocurre?

Para hacer un seguimiento en primera persona, arrastramos la cámara al Player, de manera que la cámara quede dentro del Player.

![Screenshot_20240125_103032.png](Media%2FScreenshot_20240125_103032.png)

De esta manera, la cámara se moverá junto al Player, dando la sensación de que es una cámara en primera persona. Es importante asegurarnos que la posición de la cámara sea la misma del Player:

![Screenshot_20240125_103756.png](Media%2FScreenshot_20240125_103756.png)

Y así se vería el juego:

![Screenshot_20240125_104003.png](Media%2FScreenshot_20240125_104003.png)

**Otro tipo de Seguimiento:**

Al movernos a la izquierda o derecha, que nuestra cámara también lo haga en el eje del plano.

```csharp
    public float rotationSpeed = 2.0f; // velocidad de rotación

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); // obtén la entrada horizontal del jugador

        // Aplica la rotación al offset en función de la entrada horizontal
        offset = Quaternion.Euler(0, horizontalInput * rotationSpeed, 0) * offset;

        // Actualiza la posición y la rotación de la cámara
        transform.position = player.transform.position + offset;
        transform.LookAt(player.transform.position);
    }
```
Con esto, al movernos a la izquierda o derecha, la cámara también lo hará:

![Screenshot_20240125_105741.png](Media%2FScreenshot_20240125_105741.png)

## 3. La cámara se mueve independientemente del Player, ¿como sería que la cámara se moviera alrededor de la mesa?

Para hacer independiente nuestra cámara, nos dirigimos al "Input Actions", y en el apartado de Player, borramos los atajos con ASWD (liberando así estas teclas, y sólo moverlo con las flechas de dirección).

![Screenshot_20240125_111552.png](Media%2FScreenshot_20240125_111552.png)

En nuestro script de cámara, realizamos las siguientes modificaciones:

```csharp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player; // referencia al jugador
    public float cameraSpeed = 5.0f; // velocidad de la cámara
    private Vector3 offset; // distancia entre la cámara y el jugador

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; // calcula la distancia entre la cámara y el jugador
    }

    // Update is called once per frame
    void Update()
    {
        MoveCameraWithInput();
    }

    void MoveCameraWithInput()
    {
		if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)){
			float horizontalInput = Input.GetAxis("Horizontal");
        	float verticalInput = Input.GetAxis("Vertical");

        	// Calcula el desplazamiento de la cámara en función de las entradas de teclado
        	Vector3 cameraMovement = new Vector3(horizontalInput, 0, verticalInput) * cameraSpeed * Time.deltaTime;

        	// Aplica el desplazamiento a la posición de la cámara
        	transform.Translate(cameraMovement, Space.World);
		}
    }
}
```

Como se puede observar en el código, Nos aseguramos que el usuario toque las teclas ASWD, a que si no, la cámara también cogera como entrada horizontal y vertical las flechas de dirección, alterando el movimiento de la cámara también al mover el Player.

***Vista previa de nuestra independencia de movimientos:***

![Screenshot_20240125_112806.png](Media%2FScreenshot_20240125_112806.png)

![Screenshot_20240125_112827.png](Media%2FScreenshot_20240125_112827.png)

---

>[!WARNING]
> Los Scripts de este repositorio no contienen las modificaciones comentadas en este documento, por lo que si se desea probar el proyecto con las modificaciones, se deberá realizar manualmente.

---

# No olvides clafisicar con un 10 este repositorio si te ha sido de ayuda! :smile: