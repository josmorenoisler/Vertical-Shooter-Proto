using Eflatun.SceneReference;
using UnityEngine;

namespace VerticalShooter
{
    public class GameManager : MonoBehaviour 
    {
        [SerializeField] SceneReference mainMenuScene;
        [SerializeField] GameObject gameOverUI;

        public static GameManager Instance { get; private set; }

        public PlayerPlane Player => player;

        PlayerPlane player;
        Boss boss;
        int score;
        float restartTimer = 3f;       

        public bool IsGameOver()
        {
            return player.GetHealthNormalized() <= 0 || player.GetFuelNormalized() <= 0 || boss.GetHealthNormalized() <= 0;
            // for now the game is over no matter if we defeat the boss or we die
        }

        void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else 
            {
                Destroy(gameObject);
            }

            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerPlane>();
            boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        }

        void Update()
        {
            if (IsGameOver())
            {
                restartTimer -= Time.deltaTime;
                if (!gameOverUI.activeSelf)
                {
                    gameOverUI.SetActive(true);
                }

                if (restartTimer <= 0)
                {
                    UnityEngine.SceneManagement.SceneManager.LoadScene(0);
                }
            }
        }

        public void AddScore(int amount)
        {
            score += amount;
        }

        public int GetScore() 
        {
            return score;
        }
    }
}
