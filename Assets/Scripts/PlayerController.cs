using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 8f; 
    public float gravity = -9.8f; 
    public float moveSpeed = 5f; 
    public float horizontalSpeed = 5f; 
    public float fastFallMultiplier = 2f; 
    private Rigidbody2D rb;
    private bool isGrounded = false; 
    private bool isFastFalling = false;
    private SpriteRenderer spriteRenderer; 
    
    public Sprite normalSprite; 
    public Sprite jumpSprite;   
    public Sprite downSprite;   

    public GameObject rushAnimation;


    public GameObject shurikenPrefab; // Prefab del shuriken
    public Transform puntoDeDisparo; // Posición desde donde se disparará
    public float shurikenSpeed = 10f; // Velocidad del shuriken

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        rb.gravityScale = 0; 
        if (rushAnimation != null)
        {
            rushAnimation.SetActive(false);
        }


    }

    void Update()
    {
        // Movimiento horizontal (izquierda/derecha)

        float horizontalInput = Input.GetAxis("Horizontal"); 
        MoveHorizontal(horizontalInput);        

        // Movimiento vertical (arriba/abajo)

        float verticalInput = Input.GetAxis("Vertical"); 
        MoveVertical(verticalInput);

        // Si el Player está en el suelo y presiona la tecla de salto, se ejecuta la acción 

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }


        // Caída rápida si está en el aire y se presiona hacia abajo

        if (!isGrounded && verticalInput < 0)
        {
            FastFall();
            spriteRenderer.sprite = downSprite; 
        }

        // Simulación de gravedad manual

        if (!isGrounded)
        {
            rb.linearVelocity += new Vector2(0, gravity * Time.deltaTime); 
        }

        // Control de cambio de sprites según el input del Player

        if (Input.GetKey(KeyCode.UpArrow))
        {
            spriteRenderer.sprite = jumpSprite;
        } 
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = downSprite;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.sprite = jumpSprite;
        }
        else if (isGrounded)
        {
            spriteRenderer.sprite = normalSprite;
        }

        // Control de la animación de la base de la tabla

        if (rushAnimation != null)
        {
            rushAnimation.SetActive(isGrounded); 
        }

        if (Input.GetKeyDown(KeyCode.F))
             {
        LanzarShuriken();
            }

    }
     
    // Control para lanzar shurikens 
    void LanzarShuriken(){
   
    GameObject shuriken = Instantiate(shurikenPrefab, puntoDeDisparo.position, Quaternion.identity);
    
  
    Rigidbody2D rb = shuriken.GetComponent<Rigidbody2D>();
    rb.linearVelocity = new Vector2(shurikenSpeed, 0);
       
}

    // Control del salto > aplica una velocidad lineal positiva y controla los vlaores del sprite y del control de suelo

    void Jump()
    {
        
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        isGrounded = false; 
        spriteRenderer.sprite = jumpSprite; 
    }

    // Control del movimiento vertical > según la entrada del jugador

    void MoveVertical(float input)
    {
        
        Vector2 movement = new Vector2(0, input * moveSpeed * Time.deltaTime);
        transform.Translate(movement);
    }

    // Control del movimiento horizontal> mueve al jugador hacia la izquierda o derecha según la entrada

    void MoveHorizontal(float input)
    {
        
        Vector2 movement = new Vector2(input * horizontalSpeed * Time.deltaTime, 0);
        transform.Translate(movement);
    }

    // Control de la mecánica de caída rápida > aplica un valor a la gravedad para acelerar la caída del sprite

    void FastFall()
    {
    
        rb.linearVelocity += new Vector2(0, gravity * fastFallMultiplier * Time.deltaTime);
        isFastFalling = true;
        
    }

    // Controles de detección de colisiones con el suelo
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
            isFastFalling = false;
        }

       
        
    

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; 
            spriteRenderer.sprite = normalSprite; 
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; 
        }

        if (collision.gameObject.CompareTag("Deadly"))
        {
            Destroy(gameObject);
        }
     
    }

    private void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Enemy") && isFastFalling)
    {
        // Busca el script Enemy en el objeto colisionado
        Enemy enemyScript = other.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.Die(); // Ejecuta la animación de muerte y, tras un retraso, destruye al enemigo
        }
        else
        {
            // Si el enemigo no tiene el script, se destruye directamente (opcional)
            Destroy(other.gameObject);
        }

    }

    if ((other.CompareTag("Enemy") || other.CompareTag("Fireball") ) && !isFastFalling)
    {
              
              
            // Si el enemigo no tiene el script, se destruye directamente (opcional)
            Destroy(gameObject);
        }
        
    

    if (other.CompareTag("Deadly"))
    {
        Destroy(gameObject);
    }

    
}

}

