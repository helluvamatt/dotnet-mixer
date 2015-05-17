using Common.TrayApplication;
using Common.UI.Hotkeys;
using ProjectMixer.Data;
using ProjectMixer.Properties;
using ProjectMixer.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMixer
{
	class MixerTrayApplicationContext : Common.TrayApplication.TrayApplicationContext<SettingsObject>
	{
		private HotkeyManager _HotkeyManager;

		#region TrayApplicationContext implementation

		protected override void OnInitializeContext()
		{
			_HotkeyManager = new HotkeyManager();
			// TODO
		}

		protected override OptionsForm OnBuildOptionsForm()
		{
			MixerOptionsForm form = new MixerOptionsForm();
			form.OptionChanged += MixerOptionsForm_OptionChanged;
			return form;
		}

		protected override void OnBuildContextMenu(ContextMenuStrip menu)
		{
			// TODO

			// Build the context menu: exitMenuItem
			ToolStripMenuItem exitMenuItem = new ToolStripMenuItem(Resources.MenuItemExit);
			exitMenuItem.Click += exitMenuItem_Click;

			// Build contextMenu
			//menu.Items.Add(new ToolStripSeparator());
			menu.Items.Add(exitMenuItem);
		}

		protected override Icon ApplicationIcon
		{
			get
			{
				return new Icon(GetType(), "appicon.ico");
			}
		}

		protected override string ApplicationName
		{
			get
			{
				return Resources.ApplicationName;
			}
		}

		protected override string AppDataPath
		{
			get
			{
				return Path.GetDirectoryName(Path.GetFullPath(Uri.UnescapeDataString(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath)));
			}
		}

		protected override void Dispose(bool disposing)
		{
			_HotkeyManager.Dispose();
			base.Dispose(disposing);
		}

		#endregion

		#region Event handlers

		private void MixerOptionsForm_OptionChanged(object sender, OptionChangedEventArgs args)
		{
			// TODO
		}

		private void exitMenuItem_Click(object sender, EventArgs e)
		{
			ExitThread();
		}

		#endregion
	}
}
