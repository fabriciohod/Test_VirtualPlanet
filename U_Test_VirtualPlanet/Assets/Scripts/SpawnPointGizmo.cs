using UnityEngine;

public class SpawnPointGizmo : MonoBehaviour
{
    void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 255, 0, .3f);
        Gizmos.DrawSphere(transform.position, .1f);
    }
}
