using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float JumpForce;
    float score;

    [SerializeField]
    bool isGrounded = false;
    public bool isAlive = true;
    public GameObject gameOverpanel;

    Rigidbody2D RB;

    public TMP_Text ScoreTxt;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
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
            ScoreTxt.text = "SCORE: " + score.ToString("F");
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
        }
    }
}