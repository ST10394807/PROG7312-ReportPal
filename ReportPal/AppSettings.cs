using System;

namespace ReportPal
{
    public enum AppLanguage { English, Afrikaans, Zulu }
    public enum AppTheme { Light, Dark, System }

    public static class AppSettings
    {
        private static AppLanguage _language = AppLanguage.English;
        private static AppTheme _theme = AppTheme.Light;

        public static AppLanguage Language
        {
            get => _language;
            set { if (_language != value) { _language = value; LanguageChanged?.Invoke(null, EventArgs.Empty); } }
        }

        public static AppTheme Theme
        {
            get => _theme;
            set { if (_theme != value) { _theme = value; ThemeChanged?.Invoke(null, EventArgs.Empty); } }
        }

        public static event EventHandler LanguageChanged;
        public static event EventHandler ThemeChanged;
    }
}
