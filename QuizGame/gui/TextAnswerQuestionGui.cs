using QuizGame.controller;
using QuizGame.@interface;
using System.Text.RegularExpressions;

namespace QuizGame.gui {

	internal class TextAnswerQuestionGui : BaseQuestionGui {
		private readonly string name;
		private readonly TextAnswerQuestion question;
		private readonly QuestionController.Result result;

		public TextAnswerQuestionGui(string name, TextAnswerQuestion question, ref QuestionController.Result result) : base() {
			this.name = name;
			this.question = question;
			this.result = result;
			InitializeComponent();
		}

		protected override void ConfirmAction(object? sender, EventArgs e) {
			string pattern = $"[\\s]*{question.CorrectAnswer.ToLower()}[\\s]*";
			string answer = answer_text.Text.ToLower();
			int len = answer.Length;
			Match match = Regex.Match(answer, pattern);
			result.Correct = match.Value.Length == len && match.Success;
			Dispose();
		}

		private void InitializeComponent() {
			answer_text = new TextBox();
			SuspendLayout();
			//
			// answer_text
			//
			answer_text.Name = "answer_text";
			answer_text.Multiline = true;
			answer_text.Dock = DockStyle.Fill;
			//
			// TextAnswerQuestionGui
			//
			ClientSize = new Size(584, 361);
			base.question.Text = question.Question;
			answer_area.Controls.Add(answer_text);
			Text = name;
			Name = "TextAnswerQuestionGui";
			ResumeLayout(false);
		}

		private TextBox answer_text;
	}
}