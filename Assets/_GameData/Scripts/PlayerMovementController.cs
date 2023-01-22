namespace _GameData.Scripts
{
    public class PlayerMovementController : CarMovementController
    {
        private void Update()
        {
            input = InputManager.Instance.GetInput;
        }
    }
}
