namespace QuizGame.@interface {

	internal interface IQuestion {
	}

	internal class SingleChoiceQuestion : IQuestion {
		public string Question = "";
		public string[] answers = [];
		public int correctAnswer = 0x0000;
	}

	internal class MultiChoiceQuestion : IQuestion {
		public string Question = "";
		public string[] answers = [];
		public int correctAnswer = 0x0000;
	}

	internal class TextAnswerQuestion : IQuestion {
		public string Question = "";
		public string correctAnswer = "";
	}
}