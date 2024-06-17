namespace CodeBase.Infrastructure
{
   /// <summary>
   /// Defines a method to release allocated resources.
   /// </summary>
   public interface ICleanable
   {
      /// <summary>
      /// Performs application-defined tasks associated with releasing resources, or cleaned up.
      /// </summary>
      void Clear();
   }
}