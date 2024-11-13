using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class UIEnemy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtHP;
    [SerializeField] private Image HPBar;
    private EnemyHealthSystem enemyHealth;
    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealthSystem>();
    }
    private void Update()
    {
        HPBar.fillAmount = RemainHPRatio();
    }

    private float RemainHPRatio()
    {
        return (float)enemyHealth.currentHealth / (float)enemyHealth.maxHealth;
    }
}