using UnityEngine;

public class GameIsStarted : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    

    public void StartGame()
    {
        _player.GetComponent<CapsuleCollider>().enabled = true;
        _player.GetComponent<Animator>().SetBool("GameIsStarted", true);
        Camera.main.GetComponent<Animation>().Play("StartGame");
    }
}
