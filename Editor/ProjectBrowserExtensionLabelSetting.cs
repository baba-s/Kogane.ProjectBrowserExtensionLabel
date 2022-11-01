using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/ProjectBrowserExtensionLabelSetting.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class ProjectBrowserExtensionLabelSetting : ScriptableSingleton<ProjectBrowserExtensionLabelSetting>
    {
        [SerializeField] private bool       m_isEnable;
        [SerializeField] private Vector2Int m_offset;

        public bool       IsEnable => m_isEnable;
        public Vector2Int Offset   => m_offset;

        public void Save()
        {
            Save( true );
        }
    }
}