namespace CodeBase.Services.Curtain
{
  /// <summary>
  /// Interface for awning control.
  /// </summary>
  public interface ICurtain
  {
    /// <summary>
    /// Shows the curtain.
    /// </summary>
    void Show();

    /// <summary>
    /// Hide the curtain.
    /// </summary>
    void Hide();
  }
}