using UnityEngine;
using UnityEngine.Events;

public class Cube : MonoBehaviour
{
    [SerializeField] private InputViewCube _input;

    private int _destroyChance = 50;
    private int _chanceMax = 100;
    private int _currentChance;

    public event UnityAction Spawn;

    public void Initialize(int spawnChance)
    {
        _currentChance = spawnChance;
    }

    private void OnEnable()
    {
        _currentChance = _chanceMax;
        _input.Click += CubeDivider;
    }

    private void OnDisable()
    {
        _input.Click -= CubeDivider;
    }

    private void CubeDivider()
    {
        int currentNumber = Random.Range(0, _chanceMax + 1);

        if(currentNumber < _currentChance)
        {
            Spawn?.Invoke();
            _currentChance /= 2;
        }

        Destroy(gameObject);
    }
}
