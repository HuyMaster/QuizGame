using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizGame {

	internal class AtomicReference<Type> {
		public Type value { get; set; }

		public AtomicReference(Type value) {
			this.value = value;
		}
	}
}