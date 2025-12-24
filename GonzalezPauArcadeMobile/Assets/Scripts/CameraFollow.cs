using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target a seguir")]
    public Transform target;
    [Header("Ajustes de cámara")]
    public Vector3 offset = new Vector3(0, 5, -8);
    public float smoothSpeed = 0.125f;
    void LateUpdate()
    {
        if (target == null) return; // Posición deseada detrás del jugador
        Vector3 desiredPosition = target.position + offset; // Movimiento suave hacia la posición deseada
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed); // Aplicar posición
        transform.position = smoothedPosition; // Mirar al jugador
        transform.LookAt(target); 
    }
}
