﻿      using UnityEngine;
using UnityEngine.EventSystems;

namespace SimpleFileBrowser
{
	public class FileBrowserQuickLink : FileBrowserItem, IPointerClickHandler
	{
		#region Properties
		private string m_targetPath;
		public string TargetPath { get { return m_targetPath; } }
		#endregion
#region Initialization Functions
		public void SetQuickLink( Sprite icon, string name, string targetPath )
		{
			SetFile( icon, name, true );
			m_targetPath = targetPath;
		}
		#endregion
		

		#region Pointer Events
		public new void OnPointerClick( PointerEventData eventData )
		{
			fileBrowser.OnQuickLinkSelected( this );
		}
		#endregion

		#region Other Events
		public new void OnHandClick(FileBrowserQuickLink link) {
            fileBrowser.OnQuickLinkSelected( link );
		}
		#endregion
	}
}