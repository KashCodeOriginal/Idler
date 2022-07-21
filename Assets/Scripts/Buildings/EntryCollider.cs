using System;
using UnityEngine;
using UnityEngine.UI;

public class EntryCollider : MonoBehaviour
{
    [SerializeField] private GameObject _buildingInterface;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Player>() == true)
        {
            _buildingInterface.GetComponent<Image>().color = new Color(1, 1, 1, 1);
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
            _buildingInterface.GetComponent<Image>().color = new Color(1, 1, 1, 0);
            for (int i = 0; i < _buildingInterface.transform.childCount; i++)
            {
                _buildingInterface.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}
