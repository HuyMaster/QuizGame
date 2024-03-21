using QuizGame.utils;

namespace QuizGame.controller {

	internal class QuestionController {

		public static Builder Create() {
			return Create("<not-set>");
		}

		public static Builder Create(string name) {
			return new Builder(name);
		}

		private readonly string name;
		private readonly List<IQuestion> questions = [];

		private QuestionController(string name) {
			this.name = name;
		}

		public void Start() {
			foreach (IQuestion question in questions) {
				Log.i(question);
			}
		}

		public class Builder {
			private readonly QuestionController questionManager;

			public Builder(string name) {
				questionManager = new QuestionController(name);
			}

			public Builder AddQuestion(IQuestion question) {
				questionManager.questions.Add(question);
				return this;
			}

			public QuestionController Build() {
				return questionManager;
			}
		}
	}
}