using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector]
    public bool isScored = false;

    private void Start()
    {
        Services.ball = this;
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Goal")) return;
        isScored = true;
    }

    public void Reset()
    {
        isScored = false;
    }
}
