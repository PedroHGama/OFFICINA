using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class comandosbase : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    public float movimentohorizontal;
    public float forca;
    // variável do sensor
    public bool isensor;
    public Transform posicaoSensor;
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        sensorChao();

        movimentohorizontal = Input.GetAxisRaw("Horizontal");

        rigidbody2.velocity = new Vector2(movimentohorizontal * 10, rigidbody2.velocity.y);

        if (Input.GetButtonDown("Jump") && isensor == true)
        {
            rigidbody2.AddForce(new Vector2(0, forca));
        }

    }

    public void sensorChao()
    {
        isensor = Physics2D.OverlapCircle(posicaoSensor.position, 0.2f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("icone coletavel"))
        {
            Destroy(collision.gameObject);
        }
    }
}
