using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Animator Anim;
    public enum PlayerState
	{
        Idle,
        Caminando,
        Saltando,
        Cayendo,
        Agachado,
        CaminandoAga
	}


    CharacterController cc;

    public GameObject refe;

    public float speed;
    public float fuerzaSalto;
    public float multGravedad;
    public float velocidadRotacion;

    public bool estaAgachado;

    Vector3 moveDirection;
    Vector3 rotateDirection;
    Vector3 ccCenter;
    public PlayerState estadoJugador;

    float alturaParado, alturaAgachado;
    public bool canJump, canCrouch;

    // Start is called before the first frame update
    void Start()
    {
        
        cc = GetComponent<CharacterController>();
        alturaParado = cc.height;
        ccCenter = cc.center;

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();        
    }

	private void LateUpdate()
	{
        PlayerRotation();        
    }

	Vector3 DirectionXZ()
    {
        if(Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
		{
            Vector3 direction = rotateDirection;
            direction.y = 0; // Ignore Y
            return direction;
        }
        else
		{
            Vector3 direction = moveDirection;
            direction.y = 0; // Ignore Y
            return direction;
        }
              
    }

    void PlayerMovement()
	{
        float yStore = moveDirection.y;

        moveDirection = ((Input.GetAxisRaw("Vertical") * speed * refe.transform.forward) + (Input.GetAxisRaw("Horizontal") * speed * refe.transform.right));
        moveDirection = moveDirection.normalized * speed;
        moveDirection.y = yStore;

        if (cc.isGrounded)
        {

            moveDirection.y = 0;
            if (Input.GetButtonDown("Jump") && canJump)
            {
                moveDirection.y = fuerzaSalto;
            }

            if(Input.GetButtonDown("Crouch") && canCrouch)
			{
                estaAgachado = !estaAgachado;
			}

            if(estaAgachado)
			{
                cc.height = 1;
                cc.center = Vector3.zero;
			}
            else
			{
                cc.height = alturaParado;
                cc.center = ccCenter;
            }

        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * multGravedad * Time.deltaTime);

        if (Input.GetAxisRaw("Vertical") == 0 && Input.GetAxisRaw("Horizontal") == 0)
        {
            rotateDirection = moveDirection;
        }

        cc.Move(moveDirection * Time.deltaTime);

        PlayerStateMachine();

    }

    void PlayerRotation()
	{
        if (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(DirectionXZ());
            transform.rotation = Quaternion.RotateTowards(transform.rotation,
                targetRotation, velocidadRotacion * Time.deltaTime);
        }
    }

    void PlayerStateMachine()
	{
        if(cc.isGrounded && cc.velocity == Vector3.zero && !estaAgachado)
		{
            estadoJugador = PlayerState.Idle;
		}
        if(cc.isGrounded && cc.velocity != Vector3.zero && !estaAgachado)
        {
            estadoJugador = PlayerState.Caminando;
        }
        if(!cc.isGrounded && cc.velocity.y > 0 && !estaAgachado || estaAgachado)
		{
            estadoJugador = PlayerState.Saltando;
        }
        if (!cc.isGrounded && cc.velocity.y < 0 && !estaAgachado || estaAgachado)
        {
            estadoJugador = PlayerState.Cayendo;
        }
        if (cc.isGrounded && cc.velocity == Vector3.zero && estaAgachado)
        {
            estadoJugador = PlayerState.Agachado;
        }
        if (cc.isGrounded && cc.velocity != Vector3.zero && estaAgachado)
        {
            estadoJugador = PlayerState.CaminandoAga;
        }


        switch (estadoJugador)
        {
            case PlayerState.Idle:
                Debug.Log("Idle");
                Anim.GetComponent<Animator>().SetBool("isIdle", true);
                Anim.GetComponent<Animator>().SetBool("isWalkActive", false);
                break;

            case PlayerState.Caminando:
                Debug.Log("Estoy caminando");
                Anim.GetComponent<Animator>().SetBool("isIdle", false);
                Anim.GetComponent<Animator>().SetBool("isWalkActive", true);

                break;

            case PlayerState.Saltando:

                break;

            case PlayerState.Cayendo:

                break;

            case PlayerState.Agachado:

                break;

            case PlayerState.CaminandoAga:

                break;
        }
    }
}
