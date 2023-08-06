using UnityEngine;

public class GhostDelete : MonoBehaviour
{
    [SerializeField] private GameObject parent;
    private void Update()
    {
        if (gameObject.GetComponent<SpriteRenderer>().color == new Color32(255, 255, 255, 0))
            Destroy(parent);
    }
}
