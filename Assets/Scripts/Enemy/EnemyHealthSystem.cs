

using System;
using System.Collections;
using System.Numerics;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] private int initialHealth = 10;
    [SerializeField] private float increasePower = 1.2f;
    //public BigInteger maxHealth;
    //public BigInteger currentHealth;
    public int maxHealth;
    public int currentHealth;

    private int autoClickUpgradeId = 4003;
    private int autoClickLevel;
    public event Action OnDeath;

    private void Start()
    {
        Initialize(1);
        autoClickLevel = DataManager.UpgradeLevelDb.Get(autoClickUpgradeId).level;
        StartCoroutine(AutoClick(autoClickLevel));
    }
    public void Initialize(int stage)
    {
        float randomValue = UnityEngine.Random.Range(-0.05f, 0.05f);
        //maxHealth = (BigInteger)initialHealth * (BigInteger)(MathF.Pow(increasePower, stage) * 100) / 100;
        maxHealth = (int)(initialHealth * Mathf.Pow(increasePower, stage));
        currentHealth = maxHealth;
    }

    //public void ChangeHealth(BigInteger value)
    public void ChangeHealth(int value)
    {
        currentHealth -= value;

        if(currentHealth <= 0)
        {
            OnDeath?.Invoke();
        }
    }

    private string[] numberUnitArr = new string[] { "", "K", "M", "B", "T" };
    private string GetNumberText(BigInteger initialValue)
    {
        int placeN = 0;
        BigInteger value = initialValue;
        while (value >= 1000 && placeN < numberUnitArr.Length - 1)
        {
            value /= 1000;
            placeN++;
        }

        if (placeN > 4)
        {
            string initialValueToString = initialValue.ToString();
            string firstThreeDigit = initialValueToString.Substring(0, 3);
            string nextTwoDigit = initialValueToString.Substring(3, 2);

            return firstThreeDigit + "." + nextTwoDigit + "e" + $"{BigInteger.Log10(initialValue) - 2}";
        }
        return value.ToString() + numberUnitArr[placeN];
    }

    public void OnClick()
    {
        //BigInteger clickDamage = DataManager.Instance.clickDamage;
        int clickDamage = DataManager.Instance.clickDamage;
        ChangeHealth(clickDamage);
    }

    private void OnClick(int time)
    {
        //BigInteger clickDamage = DataManager.Instance.clickDamage * time;
        int clickDamage = DataManager.Instance.clickDamage * time;
        ChangeHealth(clickDamage);
    }

    IEnumerator AutoClick(int AutoClickLevel)
    {
        while (true)
        {
            for(int i=0; i<5; i++)
            {
                yield return new WaitForSeconds(1f);
                OnClick((AutoClickLevel - i) / 5);      // 매 초 마다 자동클릭 레벨에 따라 자동클릭 하기
                                                        // 
            }
            
        }
    }

    private void ChangeAutoClickLevel()
    {
        StopCoroutine(AutoClick(autoClickLevel));
        autoClickLevel = DataManager.UpgradeLevelDb.Get(autoClickUpgradeId).level;
        StartCoroutine(AutoClick(autoClickLevel));
    }
}