namespace QuizGame.@interface {

	internal class IQuestion {
		public string Question = "";

		public override string ToString() {
			return Question;
		}

		protected void Repair(ref string[] strings) {
			if (strings.Length == 4) return;

			string[] fixedString = new string[4];

			if (strings.Length < 4) {
				for (int i = 0; i < fixedString.Length; i++) {
					if (strings.Length - 1 < i) {
						fixedString[i] = "<unknown>";
					} else {
						fixedString[i] = strings[i];
					}
				}
			} else {
				Array.Copy(strings, fixedString, 4);
			}
			strings = fixedString;
		}
	}

	internal class SingleChoiceQuestion : IQuestion {
		public string[] Answers;
		public int CorrectAnswer = 0x0000;

		public SingleChoiceQuestion(string Question, string[] Answers, int CorrectAnswer) {
			this.Question = Question;
			Repair(ref Answers);
			this.Answers = Answers;
			this.CorrectAnswer = (CorrectAnswer < 0 || CorrectAnswer > 0x1111) ? 0 : CorrectAnswer;
		}
	}

	internal class MultiChoiceQuestion : IQuestion {
		public string[] Answers;
		public int CorrectAnswer = 0x0000;

		public MultiChoiceQuestion(string Question, string[] Answers, int CorrectAnswer) {
			this.Question = Question;
			Repair(ref Answers);
			this.Answers = Answers;
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