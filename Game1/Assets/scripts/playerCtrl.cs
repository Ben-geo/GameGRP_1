using IndieMarc.TopDown;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class playerCtrl : MonoBehaviour
{
    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    private bool isLookingRight;


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
        speedX = Input.GetAxisRaw("Horizontal");
        speedY = Input.GetAxisRaw("Vertical");
        rb.velocity = (new Vector2 (speedX, speedY).normalized)*movSpeed;
        
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Dodge();
        }
    }
    private void FixedUpdate()
    {
        
        Vector2 lookDir = mousePos- rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x)*Mathf.Rad2Deg;
        rb.rotation = angle;
        if (angle < 90 && angle > -90) {
            if (!isLookingRight)
            {
                GetComponent<SpriteRenderer>().flipY = false;
                GetComponent<SpriteRenderer>().flipX = false;

                isLookingRight = true;
            }
        }
        else
        {
            if (isLookingRight)
            {
                GetComponent<SpriteRenderer>().flipY = true;
                GetComponent<SpriteRenderer>().flipX = true;
                isLookingRight = false;
            }
            
        }
    }
    private void Dodge()
    {

    }
    
    
}
