using UnityEngine;

public class ChestCollider : MonoBehaviour
{
    public GameObject potion;
    public GameObject chest;
    private float amarelo0;


    private void Update()
    {
        amarelo0 = Input.GetAxis("AMARELO0");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && amarelo0 > 0.0f)
        {
            Destroy(this.gameObject);
            Instantiate(potion, chest.transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && amarelo0 > 0.0f)
        {   
            Destroy(this.gameObject);
            Instantiate(potion, chest.transform.position, Quaternion.identity);
        }
    }
}


