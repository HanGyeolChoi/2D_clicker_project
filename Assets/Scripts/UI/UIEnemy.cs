using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Numerics;

public class UIEnemy : MonoBehaviour
{
    [SerializeField] private TMP_Text stageTxt;
    [SerializeField] private TMP_Text roundTxt;
    [SerializeField] private TMP_Text txtHP;
    [SerializeField] private Image HPBar;
    [SerializeField] private Image enemySprite;
    [SerializeField] private TMP_Text moneyTxt;
    private EnemyHealthSystem enemyHealth;
    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealthSystem>();
        enemyHealth.OnDeath += OnDeath;
        GameManager.Instance.OnInitialize += UpdateEnemyUI;
    }
    private void Update()
    {
        txtHP.text = $"{Util.GetNumberText(enemyHealth.currentHealth)} / {Util.GetNumberText(enemyHealth.maxHealth)}";
        HPBar.fillAmount = RemainHPRatio();
    }

    private float RemainHPRatio()
    {
        return (float)enemyHealth.currentHealth / (float)enemyHealth.maxHealth;
    }

    private void OnDeath()
    {
        enemySprite.DOFade(0f, 1f);
    }

    private void UpdateEnemyUI()
    {
        moneyTxt.text = Util.GetNumberText((BigInteger)DataManager.Instance.money)+" G";
        stageTxt.text = $"{GameManager.Instance.currentStageIndex}";
        roundTxt.text = $"{GameManager.Instance.roundIndex} / 10";
    }
}