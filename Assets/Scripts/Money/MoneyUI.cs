using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    public Text moneyText; //ref to show our money duh

    public PlayerMoney playerMoney;


    private void Start()
    {
        moneyText.text = playerMoney.CurrentMoney.ToString(); //we grab our currentmoney property, and can basically show it through here
    }

    public void ShowMoney()
    {
        moneyText.text = playerMoney.CurrentMoney.ToString(); //we grab our currentmoney property, and can basically show it through here
    }
}
