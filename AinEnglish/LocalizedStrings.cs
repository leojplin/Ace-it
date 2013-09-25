using AinEnglish.Resources;

namespace AinEnglish
{
    /// <summary>
    /// Provides access to string resources.
    /// </summary>
    public class LocalizedStrings
    {
        private static AppResources _localizedResources = new AppResources();
        private static ChineseSimplified _simp = new ChineseSimplified();

        public AppResources LocalizedResources { get { return _localizedResources; } }
        
    }
}