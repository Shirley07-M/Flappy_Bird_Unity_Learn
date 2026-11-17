using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private AudioClip pointSFX;

    [SerializeField] private BirdController birdController;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        birdController.OnPipePassed += PlayPointSFX;
    }

    private void OnDisable()
    {
        birdController.OnPipePassed -= PlayPointSFX;
    }

    private void PlayPointSFX()
    {
        audioSource.PlayOneShot(pointSFX);
    }
}