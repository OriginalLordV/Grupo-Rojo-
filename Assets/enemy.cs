using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{   
    private bool alert_state;
    private bool alert_attack;
    public float rango_alerta;
    public float rango_attack;
    public LayerMask capa_de_jugador;

    public Transform jugador;
    public float velocidad;

    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {   
        alert_attack = Physics.CheckSphere(transform.position, rango_attack, capa_de_jugador);
        alert_state = Physics.CheckSphere(transform.position, rango_alerta, capa_de_jugador);
        if (alert_state == true){
            transform.LookAt(new Vector3 (jugador.position.x, transform.position.y, jugador.position.z));
            transform.position = Vector3.MoveTowards(transform.position, new Vector3 (jugador.position.x, transform.position.y, jugador.position.z), velocidad * Time.deltaTime);
            anim.SetBool("run", true);
            if (alert_attack == true)
            {
                anim.SetTrigger("golpe");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, rango_alerta);
        Gizmos.DrawWireSphere(transform.position, rango_attack);
    }
}
