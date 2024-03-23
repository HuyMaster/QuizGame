﻿using QuizGame.gui;
using QuizGame.@interface;
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

		public class Result(IQuestion Question) {
			public readonly IQuestion Question = Question;
			public bool Correct { get; set; } = false;

			public override string ToString() {
				return $"{Question} : {Correct}";
			}
		}

		public partial class Builder(string name) : QuestionController(name) {

			public Builder AddQuestion(IQuestion question) {
				if (questions.Count >= 20) {
					Log.e("Maximum number of questions reached (max.20)");
					return this;
				}
				questions.Add(question);
				return this;
			}

			public Builder AddQuestion(string question, string answer) {
				return AddQuestion(new TextAnswerQuestion(question, answer));
			}

			public Builder AddQuestion(string question, string[] answer_title, int correctAnswer, bool multichoice) {
				return multichoice ? AddQuestion(new MultiChoiceQuestion(question, answer_title, correctAnswer)) : AddQuestion(new SingleChoiceQuestion(question, answer_title, correctAnswer));
			}

			public QuestionController Build() {
				return this;
			}
		}
	}
}