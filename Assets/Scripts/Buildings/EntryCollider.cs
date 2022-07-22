using UnityEngine;

public class EntryCollider : MonoBehaviour
{
    [SerializeField] private GameObject _buildingInterface;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>() == true)
        {
            _buildingInterface.SetActive(true);
            for (int i = 0; i < _buildingInterface.transform.childCount; i++)
            {
                _buildingInterface.transform.GetChild(i).gameObject.SetActive(true);
            }
        }
    }
    private void OnTriggerExit(Collider collider)
    {
        if (collider.GetComponent<Player>() == true)
        {
            _buildingInterface.SetActive(false);
            for (int i = 0; i < _buildingInterface.transform.childCount; i++)
            {
                _buildingInterface.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
