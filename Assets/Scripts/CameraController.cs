using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player; //variable para el jugador
    private Vector3 offset; //distancia entre la camara y el jugador
    
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position; //calcula la distancia entre la camara y el jugador
    }

    // LateUpdate is called once per frame after all Update functions have been completed.
    void LateUpdate()
    {
        transform.position = player.transform.position + offset; //actualiza la posicion de la camara
    }
}
