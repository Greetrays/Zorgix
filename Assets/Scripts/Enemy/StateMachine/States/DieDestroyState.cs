public class DieDestroyState : State
{
    private void OnEnable()
    {
        Destroy(gameObject);
    }
}
