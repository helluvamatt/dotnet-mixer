using ProjectMixer.Data;
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
	public partial class HotkeySwitcher : Form
	{
		private ProfileManager _ProfileManager;

		public HotkeySwitcher(ProfileManager pm)
		{
			InitializeComponent();
			_ProfileManager = pm;
		}
	}
}
