using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Requiere un collider para detectar OnTriggerEnter
[RequireComponent(typeof(Collider))]
public class pruebaScript : MonoBehaviour
{
    public Animator animator;
    public string parametroBoolean;
    bool b = false;
    private void OnTriggerEnter(Collider other)
    {
        b = !b;
        animator.SetBool(parametroBoolean, b);
    }
}
