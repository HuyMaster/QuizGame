using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame {

	internal partial class MainGui : Form {

		public MainGui() {
			InitializeComponent();
		}

		private void InitializeComponent() {
			SuspendLayout();
			//
			// MainGui
			//
			ClientSize = new Size(284, 261);
			MaximizeBox = false;
			MinimizeBox = false;
			Name = "MainGui";
			ResumeLayout(false);
		}
	}
}