using System.Text.RegularExpressions;
using Platform.Kernel.ECS.ClientEntitySystem.API;

namespace Tanks.Lobby.ClientEntrance.Impl
{
	public class EntranceValidationRulesComponent : Component
	{
		private static readonly Regex MATCH_EVERYTHING = new Regex(".+");

		private static readonly Regex MATCH_NOTHING = new Regex("(?!)");

		private Regex loginRegex = MATCH_EVERYTHING;

		private Regex loginSymbolsRegex = MATCH_EVERYTHING;

		private Regex loginBeginingRegex = MATCH_EVERYTHING;

		private Regex loginEndingRegex = MATCH_EVERYTHING;

		private Regex loginSpecTogetherRegex = MATCH_NOTHING;

		private Regex emailRegex = MATCH_NOTHING;

		private Regex passwordRegex = MATCH_EVERYTHING;

		public int minLoginLength
		{
			get;
			set;
		}

		public int maxLoginLength
		{
			get;
			set;
		}

		public int minPasswordLength
		{
			get;
			set;
		}

		public int maxPasswordLength
		{
			get;
			set;
		}

		public int maxCaptchaLength
		{
			get;
			set;
		}

		public int minEmailLength
		{
			get;
			set;
		}

		public int maxEmailLength
		{
			get;
			set;
		}

		public string LoginRegex
		{
			get
			{
				return loginRegex.ToString();
			}
			set
			{
				loginRegex = new Regex(value);
			}
		}

		public string LoginSymbolsRegex
		{
			get
			{
				return loginSymbolsRegex.ToString();
			}
			set
			{
				loginSymbolsRegex = new Regex(value);
			}
		}

		public string LoginBeginingRegex
		{
			get
			{
				return loginBeginingRegex.ToString();
			}
			set
			{
				loginBeginingRegex = new Regex(value);
			}
		}

		public string LoginEndingRegex
		{
			get
			{
				return loginEndingRegex.ToString();
			}
			set
			{
				loginEndingRegex = new Regex(value);
			}
		}

		public string LoginSpecTogetherRegex
		{
			get
			{
				return loginSpecTogetherRegex.ToString();
			}
			set
			{
				loginSpecTogetherRegex = new Regex(value);
			}
		}

		public string PasswordRegex
		{
			get
			{
				return passwordRegex.ToString();
			}
			set
			{
				passwordRegex = new Regex(value);
			}
		}

		public string EmailRegex
		{
			get
			{
				return emailRegex.ToString();
			}
			set
			{
				emailRegex = new Regex(value);
			}
		}

		public bool IsEmailValid(string email)
		{
			return emailRegex.IsMatch(email);
		}

		public bool IsLoginSymbolsValid(string login)
		{
			return loginSymbolsRegex.IsMatch(login);
		}

		public bool IsLoginBeginingValid(string login)
		{
			return loginBeginingRegex.IsMatch(login);
		}

		public bool IsLoginEndingValid(string login)
		{
			return loginEndingRegex.IsMatch(login);
		}

		public bool AreSpecSymbolsTogether(string login)
		{
			return loginSpecTogetherRegex.IsMatch(login);
		}

		public bool IsPasswordSymbolsValid(string password)
		{
			return passwordRegex.IsMatch(password);
		}

		public bool IsLoginTooShort(string login)
		{
			return login.Length < minLoginLength;
		}

		public bool IsLoginTooLong(string login)
		{
			return login.Length > maxLoginLength;
		}

		public bool IsPasswordTooShort(string password)
		{
			return password.Length < minPasswordLength;
		}

		public bool IsPasswordTooLong(string password)
		{
			return password.Length > maxPasswordLength;
		}

		public bool IsLoginValid(string login)
		{
			return !IsLoginTooShort(login) && !IsLoginTooLong(login) && IsLoginSymbolsValid(login) && IsLoginBeginingValid(login) && IsLoginEndingValid(login) && !AreSpecSymbolsTogether(login) && loginRegex.IsMatch(login);
		}
	}
}
