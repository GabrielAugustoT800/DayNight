using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DayNightCycle : MonoBehaviour
{
    [SerializeField]private Transform luzDirecional;
    [SerializeField][Tooltip ("Dura��o do dia em segundos")]private int duracaoDoDia; //texto de dica para explicar a vari�vel no Inspector
    [SerializeField]private TextMeshProUGUI horarioText; //para mostrar o hor�rio atual na interface de usu�rio

    private float segundos;
    private float multiplicador; // 1 dia tem 86400 segundos, a l�gica � usar os segundos como contador
    
    // Start is called before the first frame update
    void Start()
    {
        multiplicador = 86400 / duracaoDoDia;
    }

    // Update is called once per frame
    void Update()
    {
        segundos += Time.deltaTime * multiplicador;

        if(segundos >= 86400)
        {
            segundos = 0; // se passou um dia inteiro, volta a vari�vel para 0 para recome�ar o ciclo 
        }

        ProcessarCeu();
        CalcularHorario();
    }

    private void ProcessarCeu() //funcionamento do dia no Unity: 00h00 = -90� 06h00 = 0� 12h00 = 90� 18h00 = 180� 23h59 = 270�
    {
        float rotacaoX = Mathf.Lerp(-90, 270, segundos / 86400);  //interpola entre 2 valores
                                     //valor de interpola��o entre 0 e 1. 0 retorna -90 e 1 retorna 270
        luzDirecional.rotation = Quaternion.Euler(rotacaoX, 0, 0); //outros valores n�o importam por isso deixo em 0
    
    }

    private void CalcularHorario()
    {
        horarioText.text = TimeSpan.FromSeconds(segundos).ToString(@"hh\:mm"); //hh = hora mm = minuto. Dessa forma o hor�rio retorna em hora e minuto
    }                                                              



}
