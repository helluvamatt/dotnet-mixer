using ProjectMixer.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMixer.UI
{
	public partial class MixerOptionsForm : Common.TrayApplication.OptionsForm
	{
		public MixerOptionsForm()
		{
			InitializeComponent();
		}

		#region Event handlers

		private void optionsFormTabControl_DrawItem(object sender, DrawItemEventArgs e)
		{
			Graphics g = e.Graphics;

			// Get the item from the collection.
			TabPage _tabPage = optionsFormTabControl.TabPages[e.Index];

			// Get the real bounds for the tab rectangle.
			Rectangle _tabBounds = optionsFormTabControl.GetTabRect(e.Index);

			// Draw background
			if (e.State == DrawItemState.Selected)
			{
				g.FillRectangle(Brushes.White, e.Bounds);
			}
			else
			{
				g.FillRectangle(new SolidBrush(BackColor), e.Bounds);
			}

			// Draw icon image
			if (_tabPage == profilesTabPage)
			{
				g.DrawImage(Resources.ic_speaker, _tabBounds.X, _tabBounds.Y, _tabBounds.Height, _tabBounds.Height);
				_tabBounds.X += _tabBounds.Height;
			}
			else if (_tabPage == settingsTabPage)
			{
				g.DrawImage(Resources.ic_action_settings, _tabBounds.X, _tabBounds.Y, _tabBounds.Height, _tabBounds.Height);
				_tabBounds.X += _tabBounds.Height;
			}
			else if (_tabPage == hotkeysTabPage)
			{
				g.DrawImage(Resources.ic_shortcuts, _tabBounds.X, _tabBounds.Y, _tabBounds.Height, _tabBounds.Height);
				_tabBounds.X += _tabBounds.Height;
			}

			// Draw string
			SolidBrush _brush = new SolidBrush(Color.Black);
			StringFormat _stringFlags = new StringFormat();
			_stringFlags.Alignment = StringAlignment.Near;
			_stringFlags.LineAlignment = StringAlignment.Center;
			g.DrawString(_tabPage.Text, e.Font, _brush, _tabBounds, new StringFormat(_stringFlags));
		}

		#endregion
	}
}
