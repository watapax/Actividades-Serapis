using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FechaActual : MonoBehaviour
{
    public SpriteRenderer dia, numero, mes;
    public Sprite[] dias, numeros, meses;

    public int _dia, _numero, _mes;

    private void Start()
    {
        System.DateTime fecha = System.DateTime.Now;
        _dia = (int) fecha.DayOfWeek;
        print((int)fecha.DayOfWeek + " " + fecha.DayOfWeek);
        _numero = fecha.Day;
        _mes = fecha.Month;

        dia.sprite = dias[_dia];
        numero.sprite = numeros[_numero-1];
        mes.sprite = meses[_mes-1];
    }
}
