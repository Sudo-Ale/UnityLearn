using UnityEngine;

public class GameManagerBonus : MonoBehaviour
{
    public static GameManagerBonus instance;

    private int life = 3;
    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log($"Life: {life} | Score: {score}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points) 
    {
        score += points;
        Debug.Log($"Life: {life} | Score: {score}");
    }
    public void TakeDamage(int damage)
    {
        life -= damage;
        Debug.Log($"Life: {life} | Score: {score}");

        if (life <= 0) 
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0f;
        }
    }
}
