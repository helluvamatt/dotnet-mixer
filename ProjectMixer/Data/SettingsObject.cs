using Common.UI.Win32Interop;
using System.Collections.Generic;
using System.ComponentModel;

namespace ProjectMixer.Data
{
	class SettingsObject
	{
		[Browsable(false), DefaultValue(false)]
		public bool HotkeysEnabled { get; set; }

		[Browsable(false)]
		public Dictionary<string, GlobalHotkeyHook.KeyCombo> Hotkeys { get; set; }

		[Browsable(false)]
		public Dictionary<string, bool> HotkeyEnabled { get; set; }
	}
}
