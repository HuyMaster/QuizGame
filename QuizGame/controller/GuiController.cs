using QuizGame.utils;

namespace QuizGame.controller {

	internal class GuiController {
		public static readonly GuiController instance = new();
		private readonly AtomicReference<Form> controller = new(new MainGui());
		private bool started = false;

		private GuiController() {
			Log.i("GUI Controller starting...");
		}

		public void Start() {
			if (started) {
				Log.w("GUI Controller already started");
			} else {
				Show(controller.value);
				started = true;
			}
		}

		public void Change(Form NextForm) {
			Log.d($"Changed GUI {controller.value.GetType().Name} -> {NextForm.GetType().Name}");
			if (NextForm.GetType() == controller.value.GetType())
				Log.w("New GUI same class as current!");
			controller.value.Dispose();
			Show(NextForm);
		}

		private void Show(Form Form) {
			Log.i($"GUI {controller.value.GetType().Name} showing");
			controller.value = Form;
			Form.Disposed += GuiClose;
			controller.value.ShowDialog();
		}

		private void GuiClose(object? sender, EventArgs e) {
			if (sender is Form form)
				Log.i($"GUI {form.GetType().Name} closed");
		}
	}
}