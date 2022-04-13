public class DieEnableState : State
{
    private void OnEnable()
    {
        gameObject.SetActive(false);
    }
}
