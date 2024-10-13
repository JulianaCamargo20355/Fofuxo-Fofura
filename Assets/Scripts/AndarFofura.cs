using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndarFofura : MonoBehaviour
{
    public float velocidade = 2f;

    void Update()
    {
        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }
}
