namespace QuizGame.@interface {

	internal class IQuestion {
		public string Question = "";

		public override string ToString() {
			return Question;
		}
	}

	internal class SingleChoiceQuestion : IQuestion {
		public string[] Answers;
		public int CorrectAnswer = 0x0000;

		public SingleChoiceQuestion(string Question, string[] Answers, int CorrectAnswer) {
			this.Question = Question;
			this.Answers = Answers.Length != 4 ? ["invalid", "invalid", "invalid", "invalid"] : Answers;
			this.CorrectAnswer = (CorrectAnswer < 0 || CorrectAnswer > 0x1111) ? 0 : CorrectAnswer;
		}
	}

	internal class MultiChoiceQuestion : IQuestion {
		public string[] Answers;
		public int CorrectAnswer = 0x0000;

		public MultiChoiceQuestion(string Question, string[] Answers, int CorrectAnswer) {
			this.Question = Question;
			this.Answers = Answers.Length != 4 ? ["invalid", "invalid", "invalid", "invalid"] : Answers;
			this.CorrectAnswer = (CorrectAnswer < 0 || CorrectAnswer > 0x1111) ? 0 : CorrectAnswer;
		}
	}

	internal class TextAnswerQuestion : IQuestion {
		public string CorrectAnswer;

		public TextAnswerQuestion(string Question, string CorrectAnswer) {
			this.Question = Question;
			this.CorrectAnswer = CorrectAnswer;
		}
	}
}