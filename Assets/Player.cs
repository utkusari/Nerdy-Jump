using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{

    public float movementSpeed = 10f;
    public float width = 4f;

    public GameObject levelGenerator;
    int value;

    Rigidbody2D rb;

    float movement = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        value = levelGenerator.GetComponent<LevelGenerator>().currentNumber;
    }

    // Update is called once per frame
    void Update()
    {
        movement = Input.GetAxis("Horizontal") * movementSpeed;

        if (transform.position.x <= -5.0f){
            transform.position = new Vector2(transform.position.x + 10f, transform.position.y);
        }
        if (transform.position.x >= 5.0f){
            transform.position = new Vector2(transform.position.x - 10f, transform.position.y);
        }

    }

    void FixedUpdate(){
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;

        levelGenerator.GetComponent<LevelGenerator>().currentNumber = value;
    }

    void OnCollisionEnter2D(Collision2D collision){

        if (collision.relativeVelocity.y >= 0f){
            if (collision.collider.GetComponent<Platform>().reset == true){
                if (collision.collider.GetComponent<Platform>().isBounced == false){
                    value = 0;
                    collision.collider.GetComponent<Platform>().isBounced = true;
                }   
            }
            if (collision.collider.GetComponent<Platform>().isBounced == false){
                value += collision.collider.GetComponent<Platform>().value;
                collision.collider.GetComponent<Platform>().isBounced = true;
            }
        }
    }
}
