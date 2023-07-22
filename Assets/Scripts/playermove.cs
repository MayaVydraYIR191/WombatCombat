using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    public static bool lose = false;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetPos;
    public float checkRadius;
    public LayerMask whatIsGround;

    public GameObject missionCompleted;
    public GameObject ZombieEatedYou;

    private Animator anim;
    public string score;
    private Inventory inventory;
    
    private void Start()
    {
        //ItemWorld.spawnItemWorld(new Vector3(20, 20), new Item { itemType = Item.ItemType.Grass, amount = 1 });
        //inventory = new Inventory();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        lose = false;
        ZombieBehavoir.count = 0;
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        //if (moveInput == 0)
        //{
          //  anim.SetBool("isRunning", false);
        //}
        //else
        //{
         //  anim.SetBool("isRunning", true);
        //}
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = Vector2.up * jumpForce;
        }
        if (PlayerPrefs.GetInt("HighScore") < ZombieBehavoir.count)
        {
            PlayerPrefs.SetInt("HighScore", ZombieBehavoir.count);
        }

        else if(PlayerPrefs.GetInt("HighScore") >= ZombieBehavoir.count){
            PlayerPrefs.SetInt("Score", ZombieBehavoir.count);
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "MissionEnd")
        {
            missionCompleted.SetActive(true);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            lose = true;
            gameObject.SetActive(false);
            ZombieEatedYou.SetActive(true);
        }

        ItemWorld itemWorld = other.GetComponent<ItemWorld>();

        if (itemWorld != null)
        {
            inventory.AddItem(itemWorld.GetItem());
        }
    }
}
