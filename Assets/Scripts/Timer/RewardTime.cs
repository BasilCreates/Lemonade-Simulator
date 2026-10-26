using UnityEngine;

public class RewardTime : MonoBehaviour
{
    [SerializeField]    
    private OrderManager orderManager;

    [SerializeField]
    private GameTimer gameTimer;

    private int timeReward = 20; // Amount of time to reward in seconds

    public void OnEnable()
    {
        orderManager.OnOrderCompleted += HandleOrderCompleted;

    }


    private void HandleOrderCompleted()
    {
        Debug.Log("Order completed! Rewarding player with extra time.");
        gameTimer.AddTime(timeReward); // Add 30 seconds to the timer

    }

}
