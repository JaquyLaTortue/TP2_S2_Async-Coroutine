using System.Collections;
using UnityEngine;

public class Ex_1 : MonoBehaviour
{
    private Coroutine _tempCoroutine;

    [SerializeField]
    private float _desiredTimeRotation = 5f;

    public void CubeTurn()
    {
        _tempCoroutine = StartCoroutine(CubeTurnCoroutine());
    }

    public void StopCubeTurn()
    {
        StopCoroutine(_tempCoroutine);
    }

    private IEnumerator CubeTurnCoroutine()
    {
        float time = 0f;
        while (true)
        {
            time += Time.deltaTime;
            if (time >= _desiredTimeRotation)
            {
                yield break;
            }

            transform.Rotate(Vector3.up, 1f);
            yield return null;
        }
    }
}
