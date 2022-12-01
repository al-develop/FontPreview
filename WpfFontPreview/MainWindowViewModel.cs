using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;

using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace WpfFontPreview
{
    public class MainWindowViewModel : BindableBase
    {

		List<FontFamily> _installedFonts;
		private ObservableCollection<string> _fonts;
		private string _selectedFont;
		
		public string SelectedFont
		{
			get { return _selectedFont; }
			set 
			{ 
				SetProperty(ref _selectedFont, value, () => SelectedFont);
			}
		}
		public ObservableCollection<string> Fonts
		{
			get { return _fonts; }
			set { SetProperty(ref _fonts, value, () => Fonts); }
		}



		public MainWindowViewModel()
		{
			this.Fonts = new ObservableCollection<string>();
			_installedFonts = new List<FontFamily>();

            using (var col = new InstalledFontCollection())
			{
				_installedFonts = col.Families.ToList();
				foreach (var font in _installedFonts)
				{
					this.Fonts.Add(font.Name);
				}
			}
		}
	}
}
