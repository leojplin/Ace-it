using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AinEnglish;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace AinEnglish.ViewModels
{
    public class FlashCardViewModel : INotifyPropertyChanged
    {
        private FlashCard _flashCard;
        public FlashCard FlashCard {
            get {
                return _flashCard;
            }
            set{
                _flashCard = value;
                onPropertyChanged();
                //Definitions = _flashCard.Definitions;
            }
        }
         
        
        //private ObservableCollection<Definition> _Definitions;
        //public ObservableCollection<Definition> Definitions
        //{
        //    get
        //    {
        //        return FlashCard == null? null : FlashCard.Definitions;
        //    }
        //    set
        //    {
        //        _Definitions = value;
        //        onPropertyChanged();
        //    }
        //}
        


        public async void getDef(string word)
        {
            FlashCard = await Dictionary.Lookup(word);
            
        }

        public FlashCardViewModel()
        {
            
        }

        private void onPropertyChanged([CallerMemberName] string s = null)
        {
            if(PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(s));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
