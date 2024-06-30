using IndieMarc.TopDown;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class playerCtrl : MonoBehaviour
{
    public float speed;
    public float horizontal;
    public float jumpingPower;
    private bool isLookingRight;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;


    private GameObject weapon = default;

    public Camera cam;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        weapon = transform.Find("Weapon").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        horizontal = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            Debug.Log("Space");
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
           
        }
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void Dodge()
    {

    }


}