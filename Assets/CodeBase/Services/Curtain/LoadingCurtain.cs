using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace CodeBase.Services.Curtain
{
  /// <summary>
  /// Loading curtain allowing to display the loading process level on the screen.
  /// </summary>
  /// <seealso cref="IProgressCurtain"/>
  public class LoadingCurtain : MonoBehaviour, IProgressCurtain
  {
    public float FadeDuration
    {
      get => _fadeDuration;
      set => _fadeDuration = value <= 0 ? 0 : value;
    }

    [Range(0,2)]
    [SerializeField] private float _fadeDuration = 0.3f;
    [Tooltip("Format text loading progress.\n{0} - place progress value.\nFor percent format value use \"P0\" - {0:P0}")]
    [SerializeField] private string _loadTextFormat = "Loading {0:P0}";
    [SerializeField] private CanvasGroup _canvas;
    [SerializeField] private Slider _progressSlider;
    [SerializeField] private TMP_Text _progressText;

    private Sequence _fading;

    public void Show()
    {
      SetProgress(0);
      _fading?.Kill();
      _canvas.blocksRaycasts = true;
      _canvas.alpha = 1;
    }

    public void Hide()
    {
      _fading.Kill();
      _fading = DOTween.Sequence();
      _fading.Append(_canvas.DOFade(0, _fadeDuration))
             .AppendCallback(() => _canvas.blocksRaycasts = false);
    }

    public void SetProgress(float progress)
    {
      _progressSlider.normalizedValue = progress;
      _progressText.text = string.Format(_loadTextFormat, progress);
    }

    private void Awake()
    {
      DontDestroyOnLoad(gameObject);
      SetProgress(0);
    }
  }
}