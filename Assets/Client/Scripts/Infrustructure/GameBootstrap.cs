using UnityEngine;

namespace Client.Scripts.Infrustructure
{
    public class GameBootstrap : MonoBehaviour
    {
        private Game game;

        private void Awake()
        {
            game = new Game();
            
            DontDestroyOnLoad(this);
        }
    }
}