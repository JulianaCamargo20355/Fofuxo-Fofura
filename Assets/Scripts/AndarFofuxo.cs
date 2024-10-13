using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 

public class AndarFofuxo : MonoBehaviour
{
    public float velocidade = 2f;
    public GameObject prefParticulas;
    public AudioSource beijo; 

    void Update()
    {
        transform.Translate(Vector2.right * velocidade * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D outro)
    {
        if (outro.gameObject.CompareTag("Fofura"))
        {
            Instantiate(prefParticulas, transform.position, Quaternion.identity);
            beijo.Play();
            StartCoroutine(MudarCenaDepoisDe10Segundos());
        }
    }

    IEnumerator MudarCenaDepoisDe10Segundos()
    {
        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("Win2"); 
    }
}
