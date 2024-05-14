using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPun
{
    [Header ("Movimiento")]
    [SerializeField] private int vida;
    [SerializeField] public float  speed;
    private bool Speedactive = false;


    private float baseVelocidad;
    public float timeTemporaly;
    private bool Juumpactive = false;



    private Rigidbody  rb;
    private float posX;
    private float posZ;
    private Vector3 movimiento;




    [Header ("Jump")]
    [SerializeField] private float JumpBase;
    [SerializeField] public float forceJump;

    [SerializeField] private LayerMask layer;
    [SerializeField] private bool isCollider;

    public GameObject goCanvas;

    private float camRayDistance = 1000f;


    private void Awake(){
     rb = GetComponent<Rigidbody>();
        baseVelocidad = speed;
        JumpBase = forceJump;

        if(photonView.IsMine)
        {
            goCanvas.SetActive(true);

        }

    }
    

    private void Move() {
          posX = Input.GetAxis("Horizontal");
        posZ = Input.GetAxis("Vertical");

        movimiento.Set(posX, 0, posZ);
        movimiento = movimiento.normalized * speed * Time.deltaTime;
        rb.MovePosition(transform.position + movimiento);

    }

   private void Jump() {

        RaycastHit hit;
        isCollider = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 2, layer );
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.green);

        if(Input.GetKeyDown(KeyCode.Space) && isCollider)
        {
            rb.velocity = new Vector3(rb.velocity.x, JumpBase, rb.velocity.z);
        }
            Debug.Log(hit.transform.name);
            Destroy(hit.transform);
    }

    private void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorhit;

        if(Physics.Raycast(camRay, out floorhit, camRayDistance, layerMask:layer))
        {
            Vector3 PlayerToMouse = floorhit.point - transform.position;
            PlayerToMouse.y = 0;
            Quaternion newRotation = Quaternion.LookRotation(PlayerToMouse);
            rb.MoveRotation(newRotation);

        }


    }

  
    // Update is called once per frame
    void Update()
    {
    
        // {   
        //     transform.Translate(
        //     0,
        //     0,
        //     speed * Time.deltaTime
        //     );
        // }   
        Move();
        Jump();
        Turning();
      

    }

     public void BrincoAumentado(float brincoAumentado)
    {
        ChangeColor(Color.yellow);
        JumpBase = brincoAumentado;
        Juumpactive = true;
        StartCoroutine(ResetJumpAfter());
        
    }
      public void VelocidadAumentada(float velocidaddAumentada)
    {
        ChangeColor(Color.green);
        baseVelocidad = velocidaddAumentada;
        Speedactive = true;
        StartCoroutine(ResetSpeedAfter());
    }

     internal void ChangeColor(Color color)
    {
        Renderer playerRenderer = GetComponent<Renderer>();
        if (playerRenderer != null)
        {
            playerRenderer.material.color = color;
        }
        else
        {
            Debug.LogError("No se encontró el componente Renderer en el jugador.");
        }
    }


      IEnumerator ResetJumpAfter()
    {
        yield return new WaitForSeconds(timeTemporaly); 
        Juumpactive = false; 
        JumpBase = forceJump;
        ChangeColor(Color.red);
        Debug.Log("El brinco se ha recuperado a: " + JumpBase);
    }

       IEnumerator ResetSpeedAfter()
    {
        yield return new WaitForSeconds(timeTemporaly); 
        Speedactive = false; 
        baseVelocidad = speed;
        ChangeColor(Color.red);
        Debug.Log("La velocidad se ha recuperado a: " + speed);
    }
}

