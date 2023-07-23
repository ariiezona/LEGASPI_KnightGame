using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    public Animator anim;
    public int trapDmg;
    public bool playerOnTop;
    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        playerOnTop = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnTop = true;
            anim.SetBool("isActive", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerOnTop = false;
            anim.SetBool("isActive", false);
        }
    }

    public void DamagePlayer()
    {
        if (playerOnTop) 
        {
            player.health -= trapDmg;
        }

    }
}
