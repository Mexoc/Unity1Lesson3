using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class hero : MonoBehaviour
{
    public float direction;
    public float speed = 3f;
    public int health = 100;
    public Vector3 move;
    public int right = 1;
    private SpriteRenderer flip;
    public GameObject prefFireball;
    private Vector3 startPosition;
    private Rigidbody2D _rigidbody;
    private int forceJump;
    public bool ground;
    public Collision groundCol;
    private bool fireballFlip;
    private float GUIX, GUIY;
    public Animator anim;
    public float horizontal;
    private Camera main;
    private int camSpeed = 10;
    public int Lives = 3;
    public GameObject _panel;
    private Interface _menu;

    // Start is called before the first frame update
    void Start()
    {        
        flip = gameObject.GetComponent<SpriteRenderer>();
        startPosition = new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y);  
        _rigidbody = GetComponent<Rigidbody2D>();
        forceJump = 10;
        ground = true;
        anim = GetComponent<Animator>();
        horizontal = Input.GetAxis("Horizontal");
        main = Camera.main;
        _panel = GameObject.FindGameObjectWithTag("panel");
        _menu = FindObjectOfType<Interface>();
    }

    public void Move()
    {
        transform.position += new Vector3(Time.deltaTime*speed*right, 0);        
    }

    public void Shoot()
    {        
        GameObject temp;
        if (right == 1)
        {
            temp = Instantiate(prefFireball, new Vector3(gameObject.transform.position.x + 1, gameObject.transform.position.y - 1), Quaternion.identity);
        }
        else
        {            
            temp = Instantiate(prefFireball, new Vector3(gameObject.transform.position.x - 1, gameObject.transform.position.y - 1), Quaternion.identity);
            temp.GetComponent<SpriteRenderer>().flipX = true;
        }
        temp.name = "fireball";
        temp.GetComponent<fireball>().direction = (right == 1) ? 1: -1;        
    }    

    void Fall()
    {
        if (gameObject.transform.position.y < -5)
        {
            gameObject.transform.position = startPosition;
            Lives--;
            _panel.GetComponent<panel>().LivesMinus();
            health = 100;
        }           
    }

    void Jump()
    {

        _rigidbody.AddForce(Vector3.up * forceJump, ForceMode2D.Impulse);
        
    }

    void Die()
    {
        if (health <= 0)
        {
            gameObject.transform.position = startPosition;
            Lives--;
            _panel.GetComponent<panel>().LivesMinus();
            health = 100;            
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(GUIX, Screen.height-GUIY-30, 30,20), health.ToString());
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform" || collision.gameObject.tag == "enemy")
            ground = true;        
    }    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "platform" || collision.gameObject.tag == "enemy")
            ground = false;
    }

    //Update is called once per frame
    void Update()
    {
        float X = gameObject.transform.position.x;
        float Y = gameObject.transform.position.y;
        main.transform.position = Vector3.Lerp(main.transform.position, new Vector3(X, Y, main.transform.position.z), Time.deltaTime * camSpeed);
        GUIX = Camera.main.WorldToScreenPoint(transform.position).x;
        GUIY = Camera.main.WorldToScreenPoint(transform.position).y;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        } 
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (flip.flipX == true) flip.flipX = false;
            if (right < 0) right *= -1;
            Move();
            anim.SetBool("Run", true);
        }
        else
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (flip.flipX == false) flip.flipX = true;
            if (right > 0) right *= -1;
            Move();
            anim.SetBool("Run", true);
        }
        else anim.SetBool("Run", false);
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && ground)
        {
            Jump();
            anim.SetBool("Jump", true);
        }
        else if (!ground) anim.SetBool("Jump", true);
        else anim.SetBool("Jump", false);    
        Fall();
        Die();

        if (Input.GetKeyDown(KeyCode.Escape))
        {          
            _menu.ShowMainMenu();            
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _menu.StartGame();
        }
    }
}
