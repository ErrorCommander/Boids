using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
   /// <summary>
   /// Resource Provider implemented through the use of the "Resources" folder.
   /// </summary>
   /// <seealso cref="IAssetProvider"/>
   public class ResourcesAssetProvider : IAssetProvider
   {
      public GameObject Load(string assetPath) => 
         Resources.Load<GameObject>(assetPath);

      public TValue LoadAs<TValue>(string assetPath) where TValue : Object => 
         Resources.Load<TValue>(assetPath);

      public TValue[] LoadAll<TValue>(string assetsPath) where TValue : Object => 
         Resources.LoadAll<TValue>(assetsPath);
   }
}