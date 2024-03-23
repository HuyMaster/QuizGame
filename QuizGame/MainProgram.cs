using QuizGame.controller;
using QuizGame.@interface;
using QuizGame.utils;
using System.Windows.Forms;

namespace QuizGame {

	internal class MainProgram {
		private static readonly GuiController controller = GuiController.instance;

		public static void Main(string[] args) {
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(ProcessExit);
			Log.d($"Input args: [{string.Join(", ", args)}]");
			Log.i("Application starting...");
			controller.Start();
			QuestionController
				.Create()
				.AddQuestion("Hello", "")
				.AddQuestion("Hi", "")
				.AddQuestion("5", "")
				.Start();
		}

		private static void ProcessExit(object? sender, EventArgs e) {
			Log.i("Application exit");
		}
	}
}