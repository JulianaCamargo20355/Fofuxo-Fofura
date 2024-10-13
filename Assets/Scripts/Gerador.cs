using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gerador : MonoBehaviour
{
    public GameObject buquePrefab;
    public GameObject bombaPrefab;
    public float taxaSpawn = 1f; // Intervalo 
    public float intervaloXSpawn = 8f;
    public float velocidadeQueda = 5f;

    void Start()
    {
        InvokeRepeating("GerarObjeto", 1f, taxaSpawn); 
    }

    void GerarObjeto()
    {
        float posicaoAleatoriaX = Random.Range(-intervaloXSpawn, intervaloXSpawn);
        Vector2 posicaoSpawn = new Vector2(posicaoAleatoriaX, transform.position.y);

        // 60% buquê 40% bomba
        GameObject objeto;
        if (Random.value < 0.6f)
        {
            objeto = Instantiate(buquePrefab, posicaoSpawn, Quaternion.identity);
            objeto.tag = "Buque";
        }
        else
        {
            objeto = Instantiate(bombaPrefab, posicaoSpawn, Quaternion.identity);
            objeto.tag = "Bomba";
        }

        objeto.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -velocidadeQueda);
    }
}
