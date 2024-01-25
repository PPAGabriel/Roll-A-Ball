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

## La cámara haga un seguimiento diferente al Player, como sería en primera persona? Que otro seguimiento se te ocurre?

Para hacer un seguimiento en primera persona, arrastramos la cámara al Player, de manera que la cámara quede dentro del Player.

![Screenshot_20240125_103032.png](Media%2FScreenshot_20240125_103032.png)

De esta manera, la cámara se moverá junto al Player, dando la sensación de que es una cámara en primera persona. Es importante asegurarnos que la posición de la cámara sea la misma del Player:

![Screenshot_20240125_103756.png](Media%2FScreenshot_20240125_103756.png)

Y así se vería el juego:

![Screenshot_20240125_104003.png](Media%2FScreenshot_20240125_104003.png)

**Otro tipo de Seguimiento:**

Al movernos a la izquierda o derecha, que nuestra cámara también lo haga en el eje del plano.

```csharp
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
