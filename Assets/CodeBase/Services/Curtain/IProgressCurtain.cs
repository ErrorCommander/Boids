namespace CodeBase.Services.Curtain
{
  /// <summary>
  /// A curtain with the ability to show progress.
  /// </summary>
  /// <seealso cref="ICurtain"/>
  public interface IProgressCurtain : ICurtain
  {
    /// <summary>
    /// Set the displayed progress bar.
    /// </summary>
    /// <param name="progress">Displayed progress, value between 0 and 1.</param>
    void SetProgress(float progress);

    /// <summary>
    /// Duration of the fade to hide the curtain.
    /// </summary>
    float FadeDuration { get; set; }
  }
}