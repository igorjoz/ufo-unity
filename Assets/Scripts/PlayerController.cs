using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float speed;
    private int counter;

    public TMP_Text scoreText;
    public TMP_Text winText;

    private int totalPickups;


    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        counter = 0;

        totalPickups = GameObject.FindGameObjectsWithTag("Pickup").Length;

        winText.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pickup"))
        {
            counter++;
            Destroy(collision.gameObject);
            UpdateOnScreenScore();
        }
    }

    void UpdateOnScreenScore()
    {
        scoreText.text = "Score: " + counter.ToString() + "/" + totalPickups.ToString();

        if (counter >= totalPickups)
        {
            winText.gameObject.SetActive(true);
        }
    }
}
