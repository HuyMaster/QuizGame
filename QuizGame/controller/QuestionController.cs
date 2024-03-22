using QuizGame.gui;
using QuizGame.@interface;

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

		public List<Result> Start() {
			List<Result> results = [];
			foreach (IQuestion item in questions) {
				Result result = new(item);
				if (item is SingleChoiceQuestion sQ) {
					GuiController.instance.Change(new SingleChoiceQuestionGui(name, sQ, ref result));
				} else if (item is MultiChoiceQuestion mQ) {
					GuiController.instance.Change(new MultiChoiceQuestionGui(name, mQ, ref result));
				} else if (item is TextAnswerQuestion tQ) {
					GuiController.instance.Change(new TextAnswerQuestionGui(name, tQ, ref result));
				} else {
					result.Correct = false;
				}
				results.Add(result);
			}
			GuiController.instance.Change(new ResultGui(results));
			return results;
		}

		public class Result {
			public readonly IQuestion Question;
			public bool Correct { get; set; }

			public Result(IQuestion Question) {
				this.Question = Question;
				Correct = false;
			}

			public override string ToString() {
				return $"{Question} : {Correct}";
			}
		}

		public class Builder(string name) {
			private readonly QuestionController questionManager = new(name);

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