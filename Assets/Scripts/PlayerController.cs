using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [Header("Налаштування")]
    public float gravityScale = 3f;

    [Header("UI Елементи")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI finalScoreText; // Новий текст для Game Over
    public GameObject gameOverPanel;       // Панель, де лежить кнопка рестарту

    [Header("Звуки")]
    public AudioSource audioSource;
    public AudioClip gravitySound;
    public AudioClip deathSound;

    [Header("Текстури")]
    public Sprite deathSprite; // Текстура, яка з'явиться при смерті

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private int score = 0;
    private bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.gravityScale = gravityScale;

        gameOverPanel.SetActive(false);
        if (scoreText != null) scoreText.text = "0";
    }

    void Update()
    {
        if (isDead) return;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            rb.gravityScale *= -1;
            PlaySound(gravitySound);
        }
    }

    public void AddScore()
    {
        if (!isDead)
        {
            score++;
            scoreText.text = score.ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    void Die()
    {
        if (isDead) return;
        isDead = true;

        Time.timeScale = 0;
        PlaySound(deathSound);

        // Змінюємо текстуру
        if (deathSprite != null)
        {
            spriteRenderer.sprite = deathSprite;
        }

        // Показуємо результат
        scoreText.gameObject.SetActive(false); // Ховаємо основний лічильник
        finalScoreText.text = "RESULT: " + score;
        gameOverPanel.SetActive(true);
    }

    void PlaySound(AudioClip clip)
    {
        if (audioSource != null && clip != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}