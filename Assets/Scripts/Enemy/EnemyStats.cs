

using System.Numerics;
using TMPro;
using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] private int initialHealth = 10;
    [SerializeField] private float increasePower = 1.2f;
    private BigInteger maxHealth;
    private BigInteger currentHealth;
    
    public void Initialize(int stage)
    {
        float randomValue = Random.Range(-0.05f, 0.05f);
        maxHealth = initialHealth;
        currentHealth = maxHealth;
    }

    public void ChangeHealth(BigInteger value)
    {
        currentHealth -= value;
    }

    private string[] numberUnitArr = new string[] { "", "K", "M", "B", "T" };
    private string GetNumberText(BigInteger value)
    {
        int placeN = 0;
        while (value >= 1000 && placeN < numberUnitArr.Length - 1)
        {
            value /= 1000;
            placeN++;
        }
        return value.ToString() + numberUnitArr[placeN];
    }
}