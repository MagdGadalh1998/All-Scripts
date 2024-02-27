using UnityEngine;
using UnityEngine.UI;

public class ATMMachine : MonoBehaviour
{
    const int precent = 20;
    const int precentForSleep = 10;
    #region SinglTone
    public static ATMMachine instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }
    #endregion

    [SerializeField] Button depositBtn;
    [SerializeField] Button withdrawBtn;
    [SerializeField] Button sleepBtn;
    [SerializeField] Text balanceText;
    [SerializeField] float accountBalance = 3000f;


    private void Start()
    {
        depositBtn.onClick.AddListener(Deposit);
        withdrawBtn.onClick.AddListener(Withdraw);
        sleepBtn.onClick.AddListener(PlayerSleep);
        
    }
    private void OnEnable()
    {
        UpdateBalanceText();
    }

    public void Withdraw()
    {
        float withdrawalAmount = CalculatePercentage(accountBalance,precent);
        accountBalance -= withdrawalAmount;
        CurrencySystem.instance.coins += Mathf.RoundToInt(withdrawalAmount);
        CurrencySystem.instance.UpdteCoinsText();
        UpdateBalanceText();
    }

    public void Deposit()
    {
        float depositAmount = CalculatePercentage(accountBalance,precent);
        accountBalance += depositAmount;
        UpdateBalanceText();
    }
    public void PlayerSleep()
    {
        float depositAmount = CalculatePercentage(accountBalance, precentForSleep);
        accountBalance += depositAmount;
        UpdateBalanceText();
    }
    private float CalculatePercentage(float amount,int per)
    {
        return amount * (per / 100f);
    }

    private void UpdateBalanceText()
    {
        balanceText.text =accountBalance.ToString("F2");
    }
}