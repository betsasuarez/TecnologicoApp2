namespace TecnologicoApp.Models
{
    public static class Settings
    {
        public static bool IsAuthenticated
        {
            get => Preferences.Default.Get(nameof(IsAuthenticated), false);
            set => Preferences.Default.Set(nameof(IsAuthenticated), value);
        }

        //public static bool IsAuthenticated { get; set; }
        public static string Email
        {
            get => Preferences.Default.Get(nameof(Email), string.Empty);
            set => Preferences.Default.Set(nameof(Email), value);

            public static string RegistroEmail
            {
              get => Preferences.Default.Get(nameof(IsAuthenticated), false);
               set => Preferences.Default.Set(nameof(IsAuthenticated), value);

            }

              public static string RegistroPassword
              {
                 get => Preferences.Default.Get(nameof(IsAuthenticated), false);
                 set => Preferences.Default.Set(nameof(IsAuthenticated), value);
              }


    }
    
}
