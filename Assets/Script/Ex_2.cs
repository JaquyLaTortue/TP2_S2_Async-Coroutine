using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Ex_2 : MonoBehaviour
{
    private CancellationTokenSource _token;
    private bool _isSpinning = false;

    [SerializeField]
    private int _desiredTimeRotation = 5;

    public void CubeTurn()
    {
        SpinCube();
    }

    public void StopCubeTurn()
    {
        _token.Cancel();
        _token.Dispose();
    }

    private async void SpinCube()
    {
        _isSpinning = true;
        _token = new CancellationTokenSource();
        await UniTask.Delay(_desiredTimeRotation * 1000, cancellationToken: _token.Token).SuppressCancellationThrow();
        _isSpinning = false;
    }

    private void Update()
    {
        if (_isSpinning)
        {
            transform.Rotate(Vector3.up, 1f);
        }
    }
}
