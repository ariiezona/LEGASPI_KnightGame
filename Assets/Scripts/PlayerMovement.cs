using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    //Speed
    public float moveSpeed;
    //RigidBody
    public Rigidbody2D rigidBody;
    //Input
    private Vector2 movementInput;
    //Animator
    public Animator anim;
    //Coin Counter
    public int coinsCounter;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Vertical", movementInput.y);
        anim.SetFloat("Horizontal", movementInput.x);
        anim.SetFloat("Speed", movementInput.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        //adds velocity to rigidbody
        rigidBody.velocity = movementInput * moveSpeed;
    }

    //inputs to vectors
    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coins"))
        {
            coinsCounter++;
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Speed"))
        {
            Transform col = collision.transform;
            col.transform.position = new Vector2(999, 999);
        }

        if (collision.CompareTag("Health"))
        {
            Destroy(collision.gameObject);
        }
    }
}
