using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_behab : MonoBehaviour
{
    public int rutina;
    public float cronometro;
    public Animator anim;
    public Quaternion angulo;
    public float grado;

    public GameObject target;
    public bool atack;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        target = GameObject.Find("Player");

    }

    // Update is called once per frame
    void Update()
    {
        Comportamiento();
    }

    public void Comportamiento()
    {
        if (Vector3.Distance(transform.position, target.transform.position) >5)
            {
                anim.SetBool("run", false);
                cronometro += 1 * Time.deltaTime;
                if(cronometro >= 4)
                {
                    rutina = Random.Range(0,2);
                    cronometro = 0;
                }

                switch(rutina)
                {
                    case 0:
                        anim.SetBool("walk", false);
                        break;

                    case 1:
                        grado = Random.Range(0,360);
                        angulo = Quaternion.Euler(0,grado,0);
                        rutina++;
                        break;

                    case 2:
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, angulo, 0.5f);
                        transform.Translate(Vector3.forward * 1 * Time.deltaTime);
                        anim.SetBool("walk", true);
                        break;
                }
            }
        else
        {
            if(Vector3.Distance(transform.position, target.transform.position)>1 && !atack)
            {
                var posMirar = target.transform.position - transform.position;
                posMirar.y =0;
                var rotation = Quaternion.LookRotation(posMirar);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, 2);
                anim.SetBool("walk", false);

                anim.SetBool("run", true);
                transform.Translate(Vector3.forward *2 *Time.deltaTime);

                anim.SetBool("atack", false);
            }
         
            else
            {
                anim.SetBool("walk", false);
                anim.SetBool("run", false);

                anim.SetBool("atack", true);
                atack= true;
            }
        }
    }

    public void Final_Ani()
    {
        anim.SetBool("atack", false);
        atack = false;
    }
}
