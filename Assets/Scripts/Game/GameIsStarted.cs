using UnityEngine;

public class GameIsStarted : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _coinsText;
    [SerializeField] private GameObject _playerInvenory;
    
    public void StartGame()
    {
        _player.GetComponent<CapsuleCollider>().enabled = true;
        _player.GetComponent<Animator>().SetBool("GameIsStarted", true);
        Camera.main.GetComponent<Animation>().Play("StartGame");
        _coinsText.SetActive(true);
        _playerInvenory.SetActive(true);
    }
}
