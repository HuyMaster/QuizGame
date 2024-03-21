using System.Diagnostics;
using System.Reflection;

namespace QuizGame {

	internal class Logger {

		public static void d(string message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			if (callerR is MethodBase caller) {
				if (caller.ReflectedType is Type type) {
					Print(type.Name, message, LogLevel.DEBUG);
					return;
				}
			}
			Print("Unknown", message, LogLevel.DEBUG);
		}

		public static void i(string message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			if (callerR is MethodBase caller) {
				if (caller.ReflectedType is Type type) {
					Print(type.Name, message, LogLevel.INFO);
					return;
				}
			}
			Print("Unknown", message, LogLevel.INFO);
		}

		public static void w(string message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			if (callerR is MethodBase caller) {
				if (caller.ReflectedType is Type type) {
					Print(type.Name, message, LogLevel.WARN);
					return;
				}
			}
			Print("Unknown", message, LogLevel.WARN);
		}

		public static void e(string message) {
			StackTrace stackTrace = new();
			StackFrame? frame = stackTrace.GetFrame(1);
			if (frame == null) { return; }
			MethodBase? callerR = frame.GetMethod();
			if (callerR is MethodBase caller) {
				if (caller.ReflectedType is Type type) {
					Print(type.Name, message, LogLevel.ERROR);
					return;
				}
			}
			Print("Unknown", message, LogLevel.ERROR);
		}

		private static void Print(string tag, string message, LogLevel level) {
			switch (level) {
				case LogLevel.DEBUG:
					Console.ForegroundColor = ConsoleColor.Blue;
					break;

				case LogLevel.INFO:
					Console.ForegroundColor = ConsoleColor.Green;
					break;

				case LogLevel.WARN:
					Console.ForegroundColor = ConsoleColor.Yellow;
					break;

				case LogLevel.ERROR:
					Console.ForegroundColor = ConsoleColor.Red;
					break;
			}
			DateTime time = DateTime.Now;
			Console.WriteLine($"[{time.Day:00}-{time.Month:00}-{time.Year:0000} {time.Hour:00}:{time.Minute:00}:{time.Second:00}] {tag} [{level}] {message}");
			Console.ResetColor();
		}

		private enum LogLevel {
			DEBUG,
			INFO,
			WARN,
			ERROR
		}
	}
}