using Client.Scripts.Infrustructure;

namespace Client.Scripts.Coins
{
    public class PayTrigger : CoinTriggerBase
    {
        protected override void ProcessCoins()
        {
            if(Statistic.Instance.CurrentCoins > 0)
            {
                playerCoins.RemoveCoins(coinsPerSecond);
                Statistic.Instance.AddTotalCoins(coinsPerSecond);
            }
        }
    }
}