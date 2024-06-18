using System.Threading.Tasks;
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
      GameObject LoadResources(string assetPath);
      
      /// <summary>
      /// Performs loading of an asset from the specified path
      /// and interpreting it as <typeparamref name="TAsset"/>.
      /// </summary>
      /// <param name="assetPath">Asset path or identifier.</param>
      /// <typeparam name="TAsset">Asset type. Must be child <see cref="Object"/></typeparam>
      /// <returns></returns>
      TAsset LoadResourcesAs<TAsset>(string assetPath) where TAsset : Object;
      
      /// <summary>
      /// Performs a load of all assets of the specified type
      /// (<typeparamref name="TAsset"/>) from the specified path.
      /// </summary>
      /// <param name="assetsPath">Assets path or identifier.</param>
      /// <typeparam name="TAsset">Asset type. Must be child <see cref="Object"/></typeparam>
      /// <returns></returns>
      TAsset[] LoadAllFromResources<TAsset>(string assetsPath) where TAsset : Object;

      /// <summary>
      /// Performs async loading of an asset from addressable 
      /// </summary>
      /// <param name="assetPath">Assets identifier.</param>
      /// <typeparam name="T">Asset type. Must be child <see cref="Object"/></typeparam>
      /// <returns></returns>
      Task<T> LoadAsyncAs<T>(string assetPath) where T : Object;
      
      /// <summary>
      /// Performs async loading of an asset from addressable 
      /// </summary>
      /// <param name="assetPath">Assets identifier.</param>
      /// <returns></returns>
      Task<GameObject> LoadGameObjectAsync(string assetPath);
   }
}