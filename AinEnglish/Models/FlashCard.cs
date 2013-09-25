using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Windows;

namespace AinEnglish
{
    public class Definition : DependencyObject
    {


        public string PartOfSpeech
        {
            get { return (string)GetValue(PartOfSpeechProperty); }
            set { SetValue(PartOfSpeechProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PartOfSpeech.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PartOfSpeechProperty =
            DependencyProperty.Register("PartOfSpeech", typeof(string), typeof(Definition), new PropertyMetadata(0));


        public string Def
        {
            get { return (string)GetValue(DefProperty); }
            set { SetValue(DefProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Def.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DefProperty =
            DependencyProperty.Register("Def", 
            typeof(string), 
            typeof(Definition), 
            new PropertyMetadata(new PropertyChangedCallback(OnValueChanged)));

        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
 	        
        }

        public Definition(String pos, string def)
        {
            PartOfSpeech = pos;
            Def = def;
        }
    }

    public class FlashCard
    {
        public string Word { get; set; }
        public ObservableCollection<string> Definitions { get; set; }

        public FlashCard(String word, ObservableCollection<string> defs)
        {
            this.Word = word;
            this.Definitions = defs;
            if(Definitions != null)
            Definitions.CollectionChanged += Definitions_CollectionChanged;
            

        }

        void Definitions_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            
        }

    }
    
    #region old 

        //public class definition
        //{
        //    public definition(String pos, String def, String translation)
        //    {
        //        this.pos = pos;
        //        this.def = def;
        //        this.translation = translation;
        //    }
        //    public String  pos { get; set; }
        //    public String  def { get; set; }
        //    public String translation { get; set; }
        //}

        //public class FlashCard
        //{
        //    public String Word { get; set; }
        //    public ObservableCollection<definition> Definitions { get; set; }

    
        //    public FlashCard()
        //    {
        //        Word = "";
        //        Definitions = new ObservableCollection<definition>();
        //    }
        //    public FlashCard(String s) : base()
        //    {
        //        Word = s;
        //       // GetDefinition();
            
        //    }

        //    public void GetDefinition(String s)
        //    {
        //        Word = s;
        //        WebClient wc = new WebClient();
        //        wc.DownloadStringCompleted += wc_DownloadStringCompleted;
        //        wc.DownloadStringAsync(new Uri(AppConfig.Link + Word));



        //    }

        //    void wc_DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        //    {
        //        String result = e.Result;
        //        JObject json = JObject.Parse(result);

            
        //        if(json.First.First.ToString().Equals("NoTranslation")){
        //            Definitions.Add(new definition("", "No translation found", ""));
        //            return;
        //        }


        //        List<JToken> terms = new List<JToken>();
        //        for (int j = 0; ; j++)
        //        {
        //            JToken token = json["term" + j];
        //            if (token != null)
        //                terms.Add(token);
        //            else
        //                break;
        //        }

        //        List<JToken> pri = new List<JToken>();
        //        foreach (var v in terms)
        //        {
        //            pri.Add(v["PrincipalTranslations"]);

        //        }
        //        int total = 0;
        //        foreach (var v in pri)
        //            foreach (var vv in pri.Children<JToken>())
        //                total++;

        //        List<JToken> defs = new List<JToken>();
        //        int count = 0;
        //        int defindex = 0;
        //        int wanted = total < 3 ? total : 3;
        //        while (count < wanted)
        //        {
        //            foreach (var v in pri)
        //            {
        //                JToken def = v[defindex.ToString()];
        //                if (def != null)
        //                {
        //                    count++;
        //                    defs.Add(def);
        //                }

        //            }
        //            defindex++;
        //        }
            
        //        foreach (var v in defs)
        //        {
        //            JToken original = v["OriginalTerm"];
        //            JToken trans = v["FirstTranslation"];
        //            Definitions.Add(new definition(original["POS"].ToString(), original["sense"].ToString(), trans["term"].ToString()));

        //        }
           
        //    }
        //}
    #endregion
}
