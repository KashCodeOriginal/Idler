using UnityEngine;

public class SoundsCollider : MonoBehaviour
{
    [SerializeField] private AudioSource woodAudioSource;
    [SerializeField] private AudioClip _woodSound;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Axe")
        {
            woodAudioSource.clip = _woodSound;
            woodAudioSource.Play();
        }
    }
}
