using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFecha : MonoBehaviour
{

    public bool dia, numero, mes;

    private void Start()
    {
        print(System.DateTime.Now.DayOfWeek);
        print(System.DateTime.Now.Day);
        print(System.DateTime.Now.Month);

        if (dia)
        {
            if (System.DateTime.Now.DayOfWeek.ToString() == gameObject.name)
            {
                gameObject.GetComponent<EmparejarConTag>().tagPareja = "dia";
            }
        }
       else if(numero)
        {
            if(System.DateTime.Now.Day.ToString() == gameObject.name)
            {              
                gameObject.GetComponent<EmparejarConTag>().tagPareja = "numero";
            }
        }
        else if (mes)
        {
            if (System.DateTime.Now.Month.ToString() == gameObject.name)
            {
                gameObject.GetComponent<EmparejarConTag>().tagPareja = "mes";
            }
        }




    }
}
