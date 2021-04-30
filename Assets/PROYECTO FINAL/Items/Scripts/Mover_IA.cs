using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_IA : MonoBehaviour
{
    public Transform goal; //goal = destino
    UnityEngine.AI.NavMeshAgent agent; //Componente Agent Nav Mesh
    Animator SWAT_Soldier_Controller; //El componente Animator
    public Transform MarcaDestino; //Objeto del escenario que marca visualmente el destino
    public Camera camara; //La cámara sobre la que se calcula la proyección del clic en el escenario 
    
    void Start()
    {   //Asignaciones para simplificar el código
        agent = GetComponent <UnityEngine.AI.NavMeshAgent>();
        SWAT_Soldier_Controller = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    { //Si se pulsa el botón izquierdo del ratón se reubica el destino en el escenario
        if (Input.GetMouseButtonDown(0))
        { // Se traza un rayo desde el punto pulsado en la pantalla hasta el escenario
            Ray ray = camara.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            { // Si el rayo choca con algo, actualiza el punto de intersección como destino
                agent.destination = MarcaDestino.position = hit.point;
                // Un clip de música se reproduce cada vez que se reubica el destino
                //MarcaDestino.GetComponent<AudioSource>().Play();                      
            }
        
        
        
        }
        // Activar animación de salto si el agente está en una zona de salto
        if (agent.isOnOffMeshLink) { SWAT_Soldier_Controller.SetTrigger("saltar"); }
        // Actualizar la animación de locomoción con los parámetros de avance y giro del agente
        SWAT_Soldier_Controller.SetFloat("horizontal", transform.InverseTransformDirection(agent.velocity).x);
        SWAT_Soldier_Controller.SetFloat("vertical", transform.InverseTransformDirection(agent.velocity).z);

    }
}
