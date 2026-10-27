using UnityEngine;

public class SpeedUpTime : MonoBehaviour
{
    //Goal of the script: At a certain interval (cash threshold), the rate of which the timer is counting down will have sped up.

    [SerializeField]
    private GameTimer gameTimer;

    [SerializeField]
    private MoneyUI moneyUI;

    [SerializeField]
    private int nextThreshold = 100;

    [SerializeField]
    private int speedUpAmount = 1;



    private void Update()
    {
        int moneyAmount = int.TryParse(moneyUI.moneyText.text, out int moneyMade) ? moneyMade : 0;
        //Debug.Log(moneyAmount);
        if (moneyAmount < nextThreshold)
        {
            return;
        }

            OnSpeedTimeUp();
    }
    private void OnSpeedTimeUp()
    {

        nextThreshold += 100;
        gameTimer.SpeedUpTime(speedUpAmount);
    }
}
