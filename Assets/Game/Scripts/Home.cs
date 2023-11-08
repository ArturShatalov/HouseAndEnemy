using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]

public class Home : MonoBehaviour
{
    private int maxVolume = 1;
    private int minVolume = 0;
    public UnityAction<float> Touched;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy player))
        {
            Touched?.Invoke(maxVolume);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Enemy>(out Enemy player))
        {
            Touched?.Invoke(minVolume);
        }
    }
}
