using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recogido : MonoBehaviour
{
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Verifica si la animación ha terminado.
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 &&
            animator.GetCurrentAnimatorStateInfo(0).IsName("Recogido"))
        {
            Destroy(gameObject);  
        }
    }
}
