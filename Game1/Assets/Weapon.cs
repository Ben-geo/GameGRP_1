using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector2 PointerPosition { get; set; }    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.right =(PointerPosition-(Vector2)transform.position).normalized;
    }
}
