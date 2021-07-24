using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class EnemyHp : MonoBehaviour
{
    public int currentHp = 100;
    public GameObject Enemy;
    public Vector3 offcet;
    private RectTransform _rectTransform;
    private Slider _slider;
    private Camera _camera;

    public void ChangeValue(int value)
    {
        _slider.maxValue = value;
        currentHp = value;
    }

    private void Update()
    {
        _rectTransform.position = _camera.WorldToScreenPoint(Enemy.transform.position + offcet);
        _slider.value = currentHp;
    }

    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _slider = GetComponent<Slider>();
        _camera = Camera.main;
    }
}
