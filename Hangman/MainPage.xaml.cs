using System.ComponentModel;
using System.Diagnostics;

namespace Hangman;

public partial class MainPage : ContentPage, INotifyPropertyChanged
{
    #region UI Properties

    public string Spotlight { 
		get => spotlight; 
		set {
			spotlight = value; 
			OnPropertyChanged();
		}
	}

	public List<char> Letters { 
		get => letters;
		set {
			letters = value; 
			OnPropertyChanged();
		}
	}

	#endregion

    #region Fields
    List<string> words = new List<string> { "apple", "banana", "cherry", "date", "elderberry", "fig", "grape", "honeydew", "kiwi", "lemon", "mango", "nectarine", "orange", "papaya", "quince", "raspberry", "strawberry", "tangerine", "watermelon" };

	string answer = "";

    private string spotlight = "";

	private List<char> letters = new List<char>();

	List<char> guessed = new List<char>();

    #endregion

public MainPage()
{
	InitializeComponent();

	Letters.AddRange("abcdefghijklmnopqrstuvwxyz");

	BindingContext = this;

	PickWord();

	CalculateWord(answer, guessed);
}

	#region Game Engine
	private void PickWord()
	{
		answer = words[new Random().Next(words.Count)];
		Debug.WriteLine(answer);
	}

	private void CalculateWord(string answer, List<char> guessed)
	{
		var temp = answer.Select(x => (guessed.IndexOf(x) >= 0 ? x : '_')).ToArray();

		Spotlight = string.Join(' ', temp);

	}

	#endregion

}

