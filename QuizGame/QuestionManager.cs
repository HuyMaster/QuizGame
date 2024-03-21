using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame {

	internal class QuestionManager {
		private readonly List<Question> questions = [];
		private string name = "Test";

		public QuestionManager(string name) {
			this.name = name;
		}

		public void AddQuestion(QuestionType type, string question, string[] answers, int correctAnswer) {
			Question q = new();
			if (answers.Length != 4) {
				q.answers = ["Invalid", "Invalid", "Invalid", "Invalid"];
			}
			if (correctAnswer < 0 || correctAnswer > 0x1111) {
				q.correctAnswer = 0;
			}
			q.type = type;
			q.question = question;
			q.answers = answers;
			q.correctAnswer = correctAnswer;

			questions.Add(q);
		}

		public void Start() {
			int num = 0;
			List<string> result = [];
			foreach (Question question in questions) {
				Logger.d($"Question {questions.IndexOf(question)}/{questions.Count - 1}");
				bool r = false;
				switch (question.type) {
					case QuestionType.Single:
						GuiController.instance.Change(new SingleChoiceQuestion($"{name} ({questions.IndexOf(question) + 1}/{questions.Count})", question, res => r = res));
						break;

					case QuestionType.Multi:
						GuiController.instance.Change(new MultiChoiceQuestion($"{name} ({questions.IndexOf(question) + 1}/{questions.Count})", question, res => r = res));
						break;
				}
				num += r ? 1 : 0;
				result.Add(r ? "OK" : "FAILED");
			}
			MessageBox.Show(string.Join("\n", result), $"Correct {num}/{questions.Count}");
			Logger.i(string.Join(", ", result));
		}
	}
}