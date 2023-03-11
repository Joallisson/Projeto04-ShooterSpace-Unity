using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool shootManual, shootAutomatic;
    public float rotatePartsSpeed, playerShieldDuration, itemSpeed;
    [HideInInspector] public int enemyCount;
    public int maxEnemies;
    private UIController uIController;
    private Player player;
    [SerializeField] private GameObject[] items;
    private Color32 greenColorHealth = new Color32(0, 128, 0, 255), orangeColorHealth = new Color32(255, 165, 0, 255), redColorHealth = new Color32(255, 0, 0, 255);
    [HideInInspector] public int currentScore;
    [HideInInspector] public bool gameover;

    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        currentScore = 0;
        enemyCount = maxEnemies;
        uIController = FindObjectOfType<UIController>();
        player = FindObjectOfType<Player>();
        uIController.sliderPlayerHealth.maxValue = player.maxHealth;
        uIController.sliderPlayerHealth.value = player.health;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeColorSliderHealth()
    {
        UnityEngine.UI.Image fill = uIController.sliderPlayerHealth.transform.Find("Fill Area").GetComponentInChildren<UnityEngine.UI.Image>();

        if(player.health <= (player.maxHealth / player.maxHealth) * 25)
        {
            fill.color = redColorHealth;
        }

        if (player.health >= (player.maxHealth / player.maxHealth) * 50 && player.health <= (player.maxHealth / player.maxHealth) * 70)
        {
            fill.color = orangeColorHealth;
        }
    }

    public void PLayerFullHealth()
    {
        UnityEngine.UI.Image fill = uIController.sliderPlayerHealth.transform.Find("Fill Area").GetComponentInChildren<UnityEngine.UI.Image>();
        player.health = player.maxHealth;
        uIController.sliderPlayerHealth.value = player.health;
        fill.color = greenColorHealth;
    }

    public void CreateItem(Transform enemy)
    {
        int randomNumber = Random.Range(1, 101);

        if(randomNumber >= 75)
        {
            GameObject gameItem = Instantiate(items[Random.Range(0, items.Length)], enemy.transform.position, Quaternion.identity);
        }
    }

    public void GameOver()
    {
        gameover = true;
        player.gameObject.SetActive(false);
        player.health = 0;
        StartCoroutine(RestartDelay());
        GameData gameData = FindObjectOfType<GameData>();

        if(currentScore > gameData.highscore)
        {
            gameData.SaveScore(currentScore);
        }
    }

    public void RestartGame()
    {
        gameover = false;
        player.gameObject.SetActive(true);
        player.health = player.maxHealth;
        uIController.sliderPlayerHealth.value = player.health;
        currentScore = 0;
        uIController.txtScore.text = "Score: " + currentScore.ToString();
        UnityEngine.UI.Image fill = uIController.sliderPlayerHealth.transform.Find("Fill Area").GetComponentInChildren<UnityEngine.UI.Image>();
        fill.color = greenColorHealth;
    }

    public IEnumerator RestartDelay()
    {
        yield return new WaitForSeconds(3f);
        RestartGame();
    }
}
