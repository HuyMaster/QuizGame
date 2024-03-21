namespace QuizGame {

	internal class MainProgram {
		private static readonly GuiController controller = GuiController.instance;

		public static void Main(string[] args) {
			AppDomain.CurrentDomain.ProcessExit += new EventHandler(ProcessExit);
			Logger.d($"Input args: [{string.Join(", ", args)}]");
			Logger.i("Application starting...");
			controller.Start();
			QuestionManager qM = new("Sample test");
			qM.AddQuestion(QuestionType.Multi, "Nước nào đông dân top 1 và 2?", ["Tàu khựa", "Ấn độ", "Việt Nam", ""], 0x1100);
			qM.AddQuestion(QuestionType.Single, "Câu cho điểm", ["Thanks", "Yeah", "Ko cần", "Hooray"], 0x1101);
			qM.AddQuestion(QuestionType.Single, "Test question(A correct)", ["A", "B", "C", "D"], 0x1000);
			qM.AddQuestion(QuestionType.Single, "Test question(A correct)", ["A", "B", "C", "D"], 0x1000);
			qM.AddQuestion(QuestionType.Single, "Test question(A correct)", ["A", "B", "C", "D"], 0x1000);
			qM.AddQuestion(QuestionType.Single, "Test question(A correct)", ["A", "B", "C", "D"], 0x1000);
			qM.Start();
		}

		private static void ProcessExit(object? sender, EventArgs e) {
			Logger.i("Application exit");
		}
	}
}