using UnityEngine;

public class CelebrationCanvas : MonoBehaviour
{
    [SerializeField] private GameObject celebrationCanvas;
    [SerializeField] private AudioSource celebrationSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        celebrationCanvas.SetActive(false);
    }

    public void newPB()
    {
        celebrationCanvas.SetActive(true);
        celebrationSound.Play();
    }

    public void endPB()
    {
        celebrationCanvas.SetActive(false);
        celebrationSound.Stop();
    }
}
