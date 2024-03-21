using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame {

	internal struct Question {
		public QuestionType type;
		public string question;
		public string[] answers;
		public int correctAnswer;
	}

	internal enum QuestionType {
		Multi,
		Single
	}
}