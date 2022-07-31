using UnityEngine;
using UnityEngine.UI;

public class GameIsStarted : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _coinsText;
    [SerializeField] private GameObject _playerInvenory;

    [SerializeField] private Image _joystickCircle;

    [SerializeField] private GameObject _tutorialText;
    
    public void StartGame()
    {
        _player.GetComponent<CapsuleCollider>().enabled = true;
        _player.GetComponent<Animator>().SetBool("GameIsStarted", true);
        Camera.main.GetComponent<Animation>().Play("StartGame");
        _coinsText.SetActive(true);
        _playerInvenory.SetActive(true);
        _joystickCircle.color = new Color(1, 1, 1, 1);
        _tutorialText.SetActive(true);
    }
}
