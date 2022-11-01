using System.IO;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [InitializeOnLoad]
    internal static class ProjectBrowserExtensionLabel
    {
        static ProjectBrowserExtensionLabel()
        {
            EditorApplication.projectWindowItemInstanceOnGUI += OnGUI;
        }

        private static void OnGUI( int instanceID, Rect selectionRect )
        {
            if ( !ProjectBrowserExtensionLabelSetting.instance.IsEnable ) return;

            // サブアセットに拡張子を表示しようとすると表示が崩れるため
            // サブアセットには拡張子を表示しません
            if ( !AssetDatabase.TryGetGUIDAndLocalFileIdentifier( instanceID, out var guid, out long _ ) ) return;
            if ( AssetDatabase.IsSubAsset( instanceID ) ) return;

            var path = AssetDatabase.GUIDToAssetPath( guid );

            if ( AssetDatabase.IsValidFolder( path ) ) return;
            if ( string.IsNullOrWhiteSpace( path ) ) return;

            var extension = Path.GetExtension( path );

            if ( string.IsNullOrWhiteSpace( extension ) ) return;

            var fileName = Path.GetFileNameWithoutExtension( path );
            var content  = new GUIContent( fileName );
            var size     = EditorStyles.label.CalcSize( content );
            var position = selectionRect;

            // 検索中かどうかで位置の補正の仕方を変えます
            if ( string.IsNullOrWhiteSpace( ProjectBrowserInternal.SearchFieldText ) )
            {
                position.x += size.x + 15;
                position.y--;
            }
            else
            {
                position.x += size.x + 18;
            }

            EditorGUI.LabelField( position, extension );
        }
    }
}