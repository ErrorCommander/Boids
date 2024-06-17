using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
   /// <summary>
   /// Resource provider that allows you to upload assets.
   /// </summary>
   public interface IAssetProvider
   {
      /// <summary>
      /// Performs loading of an asset from the specified path.
      /// </summary>
      /// <param name="assetPath">Asset path or identifier.</param>
      /// <returns></returns>
      GameObject Load(string assetPath);
      
      /// <summary>
      /// Performs loading  of an asset from the specified path
      /// and interpreting it as <typeparamref name="TAsset"/>.
      /// </summary>
      /// <param name="assetPath">Asset path or identifier.</param>
      /// <typeparam name="TAsset">Asset type. Must be child <see cref="Object"/></typeparam>
      /// <returns></returns>
      TAsset LoadAs<TAsset>(string assetPath) where TAsset : Object;
      
      /// <summary>
      /// Performs a load of all assets of the specified type
      /// (<typeparamref name="TAsset"/>) from the specified path.
      /// </summary>
      /// <param name="assetsPath">Assets path or identifier.</param>
      /// <typeparam name="TAsset">Asset type. Must be child <see cref="Object"/></typeparam>
      /// <returns></returns>
      public TAsset[] LoadAll<TAsset>(string assetsPath) where TAsset : Object;
   }
}