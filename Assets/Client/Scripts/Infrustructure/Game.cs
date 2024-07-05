using Client.Scripts.Services.Input;

namespace Client.Scripts.Infrustructure
{
    public class Game
    {
        public static IInputService InputService;

        public Game()
        {
            InputService = new InputService();
        }

    }
}