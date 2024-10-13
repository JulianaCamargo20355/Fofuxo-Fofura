using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Fofuxo : MonoBehaviour
{
    public float velocidadeMovimento = 10f;
    public int cont = 0;
    public float duracaoJogo = 30f;
    private float tempoRestante;
    private SpriteRenderer spriteRenderer;
    private bool olhandoDireita = true;
    public TextMeshProUGUI txtCont; 
    public TextMeshProUGUI txtTempo; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        tempoRestante = duracaoJogo;
        txtCont.text = "= " + cont.ToString(); // Inicializa o contador na tela
        txtTempo.text = "Tempo: " + Mathf.CeilToInt(tempoRestante).ToString() + "s"; // Inicializa o timer
    }

    void Update()
    {
        float entradaHorizontal = Input.GetAxisRaw("Horizontal");
        Vector2 velocidade = new Vector2(entradaHorizontal * velocidadeMovimento, 0);
        transform.Translate(velocidade * Time.deltaTime);

        // Flip
        if (entradaHorizontal > 0 && !olhandoDireita)
        {
            Flip();
        }
        else if (entradaHorizontal < 0 && olhandoDireita)
        {
            Flip();
        }

        // Att
        tempoRestante -= Time.deltaTime;
        txtTempo.text = "Tempo: " + Mathf.CeilToInt(tempoRestante).ToString() + "s"; 

        if (tempoRestante <= 0)
        {
            FimDeJogo();
        }
    }

    void OnTriggerEnter2D(Collider2D colisao)
    {
        if (colisao.tag == "Buque")
        {
            cont++;
            txtCont.text = "= " + cont.ToString();
            Destroy(colisao.gameObject);
        }
        else if (colisao.tag == "Bomba")
        {
            cont--;
            txtCont.text = "= " + cont.ToString();
            Destroy(colisao.gameObject);
        }
    }

    void FimDeJogo()
    {
        if (cont < 10)
        {
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            SceneManager.LoadScene("Win");
        }
    }

    void Flip()
    {
        olhandoDireita = !olhandoDireita;
        Vector3 escala = transform.localScale;
        escala.x *= -1;
        transform.localScale = escala;
    }
}
