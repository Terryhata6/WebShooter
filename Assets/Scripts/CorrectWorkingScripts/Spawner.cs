using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject[] FallingObjects;
	public GameObject Coin;
	public Vector3 StartThrownigPosition;
	public int MaxCoins;
	public int AmountOfThrowingObject;
	public int TimeBeforeThrownig;
	public bool IsBonusRound;
	public bool IsStckmanRound;


	private MainGameController _mainGameController;
	private Counter _counter;
	private LvlPreset _currentLvlPreset;
	private GameObject _throwedObject;
	private ThrowingObject _throwedObjectScript;
	private Vector2 _minScreenPosition, _maxScreenPosition;
	private int _numberOfObject;
	private float _timeBeforeThrowing;
	private float _widthOfScreen;

	private void Awake()
	{
		_mainGameController = FindObjectOfType<MainGameController>();
		_counter = FindObjectOfType<Counter>();
	}
	private void Start()
	{
		_minScreenPosition = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		_maxScreenPosition = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); 
		_widthOfScreen = _maxScreenPosition.x * 2;
	}
	public void StartSpawner(LvlPreset lvlPreset = null)
	{
		if (!IsBonusRound)
		{
			_currentLvlPreset = lvlPreset;
			_counter.SetMaxAmountOfObjects(_currentLvlPreset.TrowingObjects.Length);
			for (int i = 0; i < _currentLvlPreset.TrowingObjects.Length; i++)
			{
				_timeBeforeThrowing += _currentLvlPreset.TrowingObjects[i].TimeBeforeThrowing;
				Invoke("SpawnObject", _timeBeforeThrowing);
				if (i == _currentLvlPreset.TrowingObjects.Length - 1)
				{
					_timeBeforeThrowing += 5;
					Invoke("StartBonusPart", _timeBeforeThrowing);
				}
			}
		}
		else
		{
			_timeBeforeThrowing = 0f;
			for (int i = 0; i < MaxCoins; i++)
			{
				_timeBeforeThrowing += 0.2f;
				Invoke("SpawnCoin", _timeBeforeThrowing);
				if (i == MaxCoins - 1)
				{
					_timeBeforeThrowing += 5;
					Invoke("EndLvl", _timeBeforeThrowing);
				}
			}
		}
	}
	private void SpawnCoin()
	{
		StartThrownigPosition.x = _minScreenPosition.x + _widthOfScreen * Random.Range(0f, 1f);
		_throwedObject = Instantiate(Coin, StartThrownigPosition, Quaternion.identity);
		//NumberOfObject++;
		_throwedObjectScript = _throwedObject.GetComponent<ThrowingObject>();
		_throwedObjectScript.SetCounter(_counter);
		_throwedObjectScript.SetForce(Random.Range(3000f, 3501f));
		_throwedObjectScript.TrowObjectUp();
	}
	private void SpawnObject()
	{
		StartThrownigPosition.x = _minScreenPosition.x + _widthOfScreen * _currentLvlPreset.TrowingObjects[_numberOfObject].PositionOfThrowing;
		_throwedObject = Instantiate(FallingObjects[Random.Range(0, FallingObjects.Length)], StartThrownigPosition, Quaternion.identity);
		_numberOfObject++;
		_throwedObjectScript = _throwedObject.GetComponent<ThrowingObject>();
		_throwedObjectScript.SetCounter(_counter);
		_throwedObjectScript.SetForce(_currentLvlPreset.TrowingObjects[_numberOfObject - 1].ForceOfThrowing);
		_throwedObjectScript.TrowObjectUp();
	}
	private void StartBonusPart()
	{
		IsBonusRound = true;
		StartSpawner();
	}
	private void EndLvl()
	{
		_mainGameController.EndGame();
	}
}
