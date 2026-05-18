using System.Collections.Generic;
using UnityEngine;

public class ControladorPosta : MonoBehaviour
{
    // Las listas y conexiones
    [SerializeField] List<Transform> objetivos;
    [SerializeField] List<Corredor> corredores;
    [SerializeField] int cantidadVueltas;
    [SerializeField] ControladorUI ui;

    int[] siguientesPostas;

    int turnoActual = 0;
    int vueltasDadas = 0;

    public void InPosition()
    {
        corredores[0].transform.position = objetivos[0].position;
        corredores[1].transform.position = objetivos[1].position;
        corredores[2].transform.position = objetivos[2].position;
        corredores[3].transform.position = objetivos[3].position;
    }



    public void StartRace()
    {
        turnoActual = 0;
        vueltasDadas = 0;

        siguientesPostas = new int[corredores.Count];

        for (int i = 0; i < corredores.Count; i++)
        {
            siguientesPostas[i] = (i + 1) % objetivos.Count;
        }

        next_racer();
    }

    void next_racer()
    {
        Corredor corredorDeTurno = corredores[turnoActual];

        int indiceDelObjetivo = siguientesPostas[turnoActual];

        Transform postaDestino = objetivos[indiceDelObjetivo];

        corredorDeTurno.DarLaOrden(postaDestino);

        siguientesPostas[turnoActual]++;

        if (siguientesPostas[turnoActual] >= objetivos.Count)
        {
            siguientesPostas[turnoActual] = 0;
        }
    }

    public void racer_just_arrived()
    {
        turnoActual++;
        if (turnoActual >= corredores.Count)
        {
            turnoActual = 0;
            vueltasDadas++;
            Debug.Log("Vueltas dadas: " + vueltasDadas);

            if (vueltasDadas >= cantidadVueltas)
            {
                return;
            }
        }
        next_racer();
    }

    // Le cambié el "nuevoValor" por "valor" para que coincida con lo de los paréntesis
    public void new_speed(float valor)
    {
        corredores[0].new_speed(valor);
        corredores[1].new_speed(valor);
        corredores[2].new_speed(valor);
        corredores[3].new_speed(valor);
    }
}