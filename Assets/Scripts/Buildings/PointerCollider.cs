using UnityEngine;

public class PointerCollider : MonoBehaviour
{
    [SerializeField] private GameObject _pointerInterface;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>() == true)
        {
            _pointerInterface.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Player>() == true)
        {
            _pointerInterface.SetActive(false);
        }
    }
}
