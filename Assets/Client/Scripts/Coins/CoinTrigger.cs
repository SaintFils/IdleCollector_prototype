namespace Client.Scripts.Coins
{
    public class CoinTrigger : CoinTriggerBase
    {
        protected override void ProcessCoins()
        {
            playerCoins.AddCoins(coinsPerSecond);
            PlayEffect();
        }
    }
}