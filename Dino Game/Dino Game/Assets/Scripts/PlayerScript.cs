using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public static PlayerScript instance; 
    public float JumpForce;
    public float score;

    [SerializeField]
    bool isGrounded = false;
    public bool isAlive = true;
    public GameObject gameOverpanel;

    Rigidbody2D RB;

    public TMP_Text ScoreText;
    public TMP_Text ScoreTextFinal;
    public Animator myAnim;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreText.text = "PTS: " + score.ToString("F");
        }
        Animations();

    }

    public void Animations()
    {
        if (isGrounded)
        {
            myAnim.Play("Idle");
        }
        else
        {
            if(RB.velocity.y> 0)
            {
                myAnim.Play("Jump");
            }
            else
            {
                myAnim.Play("Fall");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            if (isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
            gameOverpanel.SetActive(true);
            ScoreTextFinal.text = "PONTUAÇÃO FINAL: "+ score.ToString("F") + " PONTOS";
        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
}