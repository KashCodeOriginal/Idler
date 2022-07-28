    using UnityEngine;

public class TutorialEntryCollider : MonoBehaviour
{
    [SerializeField] private Tutorial _tutorial;

    private void OnTriggerExit(Collider collider)
    {
        _tutorial.ChangeValue();
    }
}
