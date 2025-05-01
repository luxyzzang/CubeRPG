using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] private Image image1;
    [SerializeField] private Image image2;
    [SerializeField] private Image image3;
    [SerializeField] private Image image4;
    [SerializeField] private Image image5;

    [SerializeField] private Color color;
    [SerializeField] private float duration;

    private void Start()
    {
        StartCoroutine(image1.ChangeColor(color, duration));
        StartCoroutine(image2.ChangeColor(Color.green, duration));
        StartCoroutine(image3.ChangeColor(Color.yellow, duration));
        StartCoroutine(image4.Fade(0, duration));
        StartCoroutine(image5.Fade(1, duration));
    }
}
