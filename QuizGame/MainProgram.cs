using QuizGame.controller;
using QuizGame.utils;

namespace QuizGame {

	internal class MainProgram {
		private static readonly GuiController controller = GuiController.instance;

		public static void Main(string[] args) {
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(ProcessExit);
			Log.d($"Input args: [{string.Join(", ", args)}]");
			Log.i("Application starting...");
			controller.Start();
			QuestionController.Create()
				.Build().Start();
		}

		private static void ProcessExit(object? sender, EventArgs e) {
			Log.i("Application exit");
		}
	}
}